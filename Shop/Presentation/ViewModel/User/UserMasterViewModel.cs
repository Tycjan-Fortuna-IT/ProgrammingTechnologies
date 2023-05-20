﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Presentation.Model.API;

namespace Presentation.ViewModel;

internal class UserMasterViewModel : IViewModel
{
    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToStateMasterPage { get; set; }

    public ICommand SwitchToEventMasterPage { get; set; }

    public ICommand CreateUser { get; set; }

    public ICommand RemoveUser { get; set; }

    private readonly IUserModelOperation _modelOperation;

    private ObservableCollection<UserDetailViewModel> _users;

    public ObservableCollection<UserDetailViewModel> Users
    {
        get => _users;
        set
        {
            _users = value;
            OnPropertyChanged(nameof(Users));
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

    private bool _isUserSelected;

    public bool IsUserSelected
    {
        get => _isUserSelected;
        set
        {
            this.IsUserDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isUserSelected = value;
            OnPropertyChanged(nameof(IsUserSelected));
        }
    }

    private Visibility _isUserDetailVisible;

    public Visibility IsUserDetailVisible
    {
        get => _isUserDetailVisible;
        set
        {
            _isUserDetailVisible = value;
            OnPropertyChanged(nameof(IsUserDetailVisible));
        }
    }

    private UserDetailViewModel _selectedDetailViewModel;

    public UserDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsUserSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public UserMasterViewModel()
    {
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");
        this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");
        this.SwitchToEventMasterPage = new SwitchViewCommand("EventMasterView");

        this.CreateUser = new OnClickCommand(e => this.StoreUser(), c => this.CanStoreUser());
        this.RemoveUser = new OnClickCommand(e => this.DeleteUser());

        this.Users = new ObservableCollection<UserDetailViewModel>();
        this._modelOperation = IUserModelOperation.CreateModelOperation();

        this.IsUserSelected = false;

        Task.Run(this.LoadUsers);
    }

    private bool CanStoreUser()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Nickname) ||
            string.IsNullOrWhiteSpace(this.Email) ||
            string.IsNullOrWhiteSpace(this.Balance.ToString()) ||
            string.IsNullOrWhiteSpace(this.DateOfBirth.ToString())
        );
    }

    private void StoreUser()
    {
        Task.Run(async () =>
        {
            int lastId = await this._modelOperation.GetCountAsync() + 1;

            await this._modelOperation.AddAsync(lastId, this.Nickname, this.Email, this.Balance, this.DateOfBirth);

            this.LoadUsers();
        });
    }

    private void DeleteUser()
    {
        Task.Run(async () =>
        {
            await this._modelOperation.DeleteAsync(this.SelectedDetailViewModel.Id);

            this.LoadUsers();
        });
    }

    private async void LoadUsers()
    {
        Dictionary<int, IUserModel> Users = await this._modelOperation.GetAllAsync();

        Application.Current.Dispatcher.Invoke(() =>
        {
            this._users.Clear();

            foreach (IUserModel u in Users.Values)
            {
                this._users.Add(new UserDetailViewModel(u.Id, u.Nickname, u.Email, u.Balance, u.DateOfBirth));
            }
        });

        OnPropertyChanged(nameof(Users));
    }
}
