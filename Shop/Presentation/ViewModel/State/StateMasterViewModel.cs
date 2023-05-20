using Presentation.API;
using Presentation.Model.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class StateMasterViewModel : IViewModel
{
    public ICommand SwitchToUserMasterPage { get; set; }

    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToEventMasterPage { get; set; }

    public ICommand CreateState { get; set; }

    public ICommand RemoveState { get; set; }

    private readonly IStateModelOperation _modelOperation;

    private readonly IErrorInformer _informer;

    private ObservableCollection<StateDetailViewModel> _states;

    public ObservableCollection<StateDetailViewModel> States
    {
        get => _states;
        set
        {
            _states = value;
            OnPropertyChanged(nameof(States));
        }
    }

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

    private int _productId;

    public int ProductId
    {
        get => _productId;
        set
        {
            _productId = value;
            OnPropertyChanged(nameof(ProductId));
        }
    }

    private int _productQuantity;

    public int ProductQuantity
    {
        get => _productQuantity;
        set
        {
            _productQuantity = value;
            OnPropertyChanged(nameof(ProductQuantity));
        }
    }

    private bool _isStateSelected;

    public bool IsStateSelected
    {
        get => _isStateSelected;
        set
        {
            this.IsStateDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isStateSelected = value;
            OnPropertyChanged(nameof(IsStateSelected));
        }
    }

    private Visibility _isStateDetailVisible;

    public Visibility IsStateDetailVisible
    {
        get => _isStateDetailVisible;
        set
        {
            _isStateDetailVisible = value;
            OnPropertyChanged(nameof(IsStateDetailVisible));
        }
    }

    private StateDetailViewModel _selectedDetailViewModel;

    public StateDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsStateSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public StateMasterViewModel(IStateModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.SwitchToUserMasterPage = new SwitchViewCommand("UserMasterView");
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");
        this.SwitchToEventMasterPage = new SwitchViewCommand("EventMasterView");

        this.CreateState = new OnClickCommand(e => this.StoreState(), c => this.CanStoreState());
        this.RemoveState = new OnClickCommand(e => this.DeleteState());

        this.States = new ObservableCollection<StateDetailViewModel>();

        this._modelOperation = IStateModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();

        this.IsStateSelected = false;

        Task.Run(this.LoadStates);
    }

    private bool CanStoreState()
    {
        return !(
            string.IsNullOrWhiteSpace(this.ProductId.ToString()) ||
            string.IsNullOrWhiteSpace(this.ProductQuantity.ToString()) ||
            this.ProductQuantity < 0
        );
    }

    private void StoreState()
    {
        Task.Run(async () =>
        {
            int lastId = await this._modelOperation.GetCountAsync() + 1;

            await this._modelOperation.AddAsync(lastId, this.ProductId, this.ProductQuantity);

            this.LoadStates();

            this._informer.InformSuccess("State successfully created!");
        });
    }

    private void DeleteState()
    {
        Task.Run(async () =>
        {
            await this._modelOperation.DeleteAsync(this.SelectedDetailViewModel.Id);

            this.LoadStates();

            this._informer.InformSuccess("State successfully deleted!");
        });
    }

    private async void LoadStates()
    {
        Dictionary<int, IStateModel> States = await this._modelOperation.GetAllAsync();

        Application.Current.Dispatcher.Invoke(() =>
        {
            this._states.Clear();

            foreach (IStateModel s in States.Values)
            {
                this._states.Add(new StateDetailViewModel(s.Id, s.productId, s.productQuantity));
            }
        });

        OnPropertyChanged(nameof(States));
    }
}
