using System;
using Service.API;
using System.Threading.Tasks;
using System.Windows.Input;
using Data.API;

namespace Presentation.ViewModel;

internal class UserDetailViewModel : IViewModel
{
    public ICommand UpdateUser { get; set; }

    private IUserCRUD _service { get; set; }

    private int _id;

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    private string _nickname;

    public string Nickname
    {
        get => _nickname;
        set
        {
            _nickname = value;
            OnPropertyChanged(nameof(Nickname));
        }
    }

    private string _email;

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    private double _balance;

    public double Balance
    {
        get => _balance;
        set
        {
            _balance = value;
            OnPropertyChanged(nameof(Balance));
        }
    }

    private DateTime _dateOfBirth;

    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            _dateOfBirth = value;
            OnPropertyChanged(nameof(DateOfBirth));
        }
    }

    public UserDetailViewModel()
    {
        this.UpdateUser = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._service = IUserCRUD.CreateUserCRUD(IDataRepository.CreateDatabase());
    }

    public UserDetailViewModel(int id, string nickname, string email, double balance, DateTime dateOfBirth)
    {
        this.Id = id;
        this.Nickname = nickname;
        this.Email = email;
        this.Balance = balance;
        this.DateOfBirth = dateOfBirth;

        this.UpdateUser = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._service = IUserCRUD.CreateUserCRUD(IDataRepository.CreateDatabase());
    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._service.UpdateUserAsync(this.Id, this.Nickname, this.Email, this.Balance, this.DateOfBirth);
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Nickname) ||
            string.IsNullOrWhiteSpace(this.Email) ||
            string.IsNullOrWhiteSpace(this.Balance.ToString()) ||
            string.IsNullOrWhiteSpace(this.DateOfBirth.ToString()) ||
            this.Balance == 0
        );
    }
}
