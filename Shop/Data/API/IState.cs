namespace Data.API
{
    public interface IState
    {
        string guid { get; }

        string productGuid { get; }

        int productQuantity{ get; set; }   
    }
}
