namespace Data.API
{
    public interface IState
    {
        string Guid { get; }

        IProduct Product { get; }

        int ProductQuantity{ get; set; }   
    }
}
