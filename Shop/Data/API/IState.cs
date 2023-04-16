namespace Data.API
{
    public interface IState
    {
        string guid { get; }

        IProduct product { get; }

        int productQuantity{ get; set; }   
    }
}
