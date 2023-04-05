namespace Shop.Data
{
    public interface IDataContext
    {
        Dictionary<string, IUser> Users { get; set; }

        Dictionary<string, IProduct> Products { get; set; }

        Dictionary<string, IEvent> Events { get; set; }
        
        Dictionary<string, IState> States { get; set; }
    }
}
