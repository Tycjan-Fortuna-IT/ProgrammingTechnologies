namespace Shop.Data
{
    public interface IState
    {
        string Guid { get; }

        int ProductQuantity{ get; set; }   
    }
}
