namespace Shop.Data
{
    public class DataContext : IDataContext
    {
        public DataContext() {
            this.Users = new Dictionary<string, IUser>();
            this.Products = new Dictionary<string, IProduct>();
            this.Events = new Dictionary<string, IEvent>();
            this.States = new Dictionary<string, IState>();
        }

        // public Dictionary<Type, object> Elements = new Dictionary<Type, object> {
        //     {
        //         typeof(IUser), new Dictionary<string, IUser>()
        //     },
        //     {
        //         typeof(IProduct), new Dictionary<string, IProduct>()
        //     },
        //     {
        //         typeof(IEvent), new Dictionary<string, IEvent>()
        //     },
        //     {
        //         typeof(IState), new Dictionary<string, IState>()
        //     }
        // };

        public Dictionary<string, IUser> Users { get; set; }

        public Dictionary<string, IProduct> Products { get; set; }

        public Dictionary<string, IEvent> Events { get; set; }
        
        public Dictionary<string, IState> States { get; set; }
    }
}
