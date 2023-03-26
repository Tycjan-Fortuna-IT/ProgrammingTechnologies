namespace Shop.Data
{
    public interface IDataContext
    {
        Dictionary<string, IUser> Users { get; set; }
    }
}
