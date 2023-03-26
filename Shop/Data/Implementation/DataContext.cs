namespace Shop.Data
{
    public class DataContext : IDataContext
    {
        public DataContext() {
            this.Users = new Dictionary<string, IUser>();
        }

        public Dictionary<string, IUser> Users { get; set; }
    }
}
