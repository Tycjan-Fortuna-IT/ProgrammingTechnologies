namespace Data.API
{
    public interface IState
    {
        int id { get; set; }

        string guid { get; }

        string productGuid { get; }

        int productQuantity{ get; set; }   
    }
}
