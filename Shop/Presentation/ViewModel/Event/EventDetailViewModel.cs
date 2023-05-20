﻿using Service.API;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Data.API;

namespace Presentation.ViewModel;

internal class EventDetailViewModel : IViewModel
{
    public ICommand UpdateEvent { get; set; }

    private IEventCRUD _service { get; set; }

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

    private DateTime _occurrenceDate;

    public DateTime OccurrenceDate
    {
        get => _occurrenceDate;
        set
        {
            _occurrenceDate = value;
            OnPropertyChanged(nameof(OccurrenceDate));
        }
    }

    private string _type;

    public string Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged(nameof(Type));
        }
    }

    private int? _quantity;

    public int? Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
        }
    }

    public EventDetailViewModel()
    {
        this.UpdateEvent = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._service = IEventCRUD.CreateEventCRUD(IDataRepository.CreateDatabase());
    }

    public EventDetailViewModel(int id, int stateId, int userId, DateTime occurrenceDate, string type, int? quantity)
    {
        this.UpdateEvent = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._service = IEventCRUD.CreateEventCRUD(IDataRepository.CreateDatabase());

        this.Id = id;
        this.StateId = stateId;
        this.UserId = userId;
        this.OccurrenceDate = occurrenceDate;
        this.Type = type;
        this.Quantity = quantity;
    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._service.UpdateEventAsync(this.Id, this.StateId, this.UserId, this.OccurrenceDate, this.Type, this.Quantity);
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.OccurrenceDate.ToString())
        );
    }
}
