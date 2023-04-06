namespace Shop.Data
{
    public interface IState : IElement
    {
        IProduct Product { get; }

        int ProductQuantity{ get; set; }   
    }
}
