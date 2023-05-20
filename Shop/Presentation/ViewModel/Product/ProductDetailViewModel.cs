using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.Model.API;

namespace Presentation.ViewModel;

internal class ProductDetailViewModel : IViewModel
{
    public ICommand UpdateProduct { get; set; }

    private readonly IProductModelOperation _modelOperation;

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

    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    private double _price;

    public double Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged(nameof(Price));
        }
    }

    private int _pegi;

    public int Pegi
    {
        get => _pegi;
        set
        {
            _pegi = value;
            OnPropertyChanged(nameof(Pegi));
        }
    }

    public ProductDetailViewModel()
    {
        this.UpdateProduct = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IProductModelOperation.CreateModelOperation();
    }

    public ProductDetailViewModel(int id, string name, double price, int pegi)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.Pegi = pegi;

        this.UpdateProduct = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IProductModelOperation.CreateModelOperation();
    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._modelOperation.UpdateAsync(this.Id, this.Name, this.Price, this.Pegi);
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Name) ||
            string.IsNullOrWhiteSpace(this.Price.ToString()) ||
            string.IsNullOrWhiteSpace(this.Pegi.ToString()) ||
            this.Price == 0 ||
            this.Pegi == 0
        );
    }
}
