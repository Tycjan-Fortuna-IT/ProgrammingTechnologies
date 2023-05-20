﻿using Service.API;
using System.Threading.Tasks;
using System.Windows.Input;
using Data.API;

namespace Presentation.ViewModel;

internal class StateDetailViewModel : IViewModel
{
    public ICommand UpdateState { get; set; }

    private IStateCRUD _service { get; set; }

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

    public StateDetailViewModel()
    {
        this.UpdateState = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._service = IStateCRUD.CreateStateCRUD(IDataRepository.CreateDatabase());
    }

    public StateDetailViewModel(int id, int productId, int productQuantity)
    {
        this.Id = id;
        this.ProductId = productId;
        this.ProductQuantity = productQuantity;

        this.UpdateState = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._service = IStateCRUD.CreateStateCRUD(IDataRepository.CreateDatabase());
    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._service.UpdateStateAsync(this.Id, this.ProductId, this.ProductQuantity);
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.ProductQuantity.ToString()) ||
            this.ProductQuantity < 0
        );
    }
}
