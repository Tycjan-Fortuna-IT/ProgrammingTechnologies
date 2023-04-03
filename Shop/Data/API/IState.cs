namespace Shop.Data
{
    public interface IState
    {
        string ProductGuid { get; }
        string StateGuid { get; set; }

        bool ProductQuantity{ get; set; }
    }
}
