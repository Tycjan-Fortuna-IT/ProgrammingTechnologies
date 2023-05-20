using System;
using Data.API;
using Presentation.ViewModel.Command;
using Service.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class EventMasterViewModel : IViewModel
{
    public ICommand SwitchToUserMasterPage { get; set; }

    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToStateMasterPage { get; set; }

    public ICommand CreateEvent { get; set; }

    public ICommand RemoveEvent { get; set; }

    private IEventCRUD _service { get; set; }

    private ObservableCollection<EventDetailViewModel> _events;

    public ObservableCollection<EventDetailViewModel> Events
    {
        get => _events;
        set
        {
            _events = value;
            OnPropertyChanged(nameof(Events));
        }
    }

    private int _stateId;

    public int StateId
    {
        get => _stateId;
        set
        {
            _stateId = value;
            OnPropertyChanged(nameof(StateId));
        }
    }

    private int _userId;

    public int UserId
    {
        get => _userId;
        set
        {
            _userId = value;
            OnPropertyChanged(nameof(UserId));
        }
    }

    private int _quantity;

    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
        }
    }

    private bool _isEventSelected;

    public bool IsEventSelected
    {
        get => _isEventSelected;
        set
        {
            this.IsEventDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isEventSelected = value;
            OnPropertyChanged(nameof(IsEventSelected));
        }
    }

    private Visibility _isEventDetailVisible;

    public Visibility IsEventDetailVisible
    {
        get => _isEventDetailVisible;
        set
        {
            _isEventDetailVisible = value;
            OnPropertyChanged(nameof(IsEventDetailVisible));
        }
    }

    private EventDetailViewModel _selectedDetailViewModel;

    public EventDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsEventSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public EventMasterViewModel()
    {
        this.SwitchToUserMasterPage = new SwitchViewCommand("UserMasterView");
        this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");

        this.CreateEvent = new OnClickCommand(e => this.StoreEvent(), c => this.CanStoreEvent());
        this.RemoveEvent = new OnClickCommand(e => this.DeleteEvent());

        this.Events = new ObservableCollection<EventDetailViewModel>();
        this._service = IEventCRUD.CreateEventCRUD(IDataRepository.CreateDatabase());

        this.IsEventSelected = false;

        Task.Run(this.LoadEvents);
    }

    private bool CanStoreEvent()
    {
        return !(
            string.IsNullOrWhiteSpace(this.StateId.ToString()) ||
            string.IsNullOrWhiteSpace(this.UserId.ToString())
        );
    }

    private void StoreEvent()
    {
        Task.Run(async () =>
        {
            int lastId = await this._service.GetEventsCountAsync() + 1;

            await this._service.AddEventAsync(lastId, this.StateId, this.UserId, "SupplyEvent", this.Quantity);

            this.LoadEvents();
        });
    }

    private void DeleteEvent()
    {
        Task.Run(async () =>
        {
            await this._service.DeleteEventAsync(this.SelectedDetailViewModel.Id);

            this.LoadEvents();
        });
    }

    private async void LoadEvents()
    {
        Dictionary<int, IEventDTO> Events = (await this._service.GetAllEventsAsync());

        Application.Current.Dispatcher.Invoke(() =>
        {
            this._events.Clear();

            foreach (IEventDTO e in Events.Values)
            {
                this._events.Add(new EventDetailViewModel(e.Id, e.stateId, e.userId, e.occurrenceDate));
            }
        });

        OnPropertyChanged(nameof(Events));
    }
}
