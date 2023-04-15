using Data.API;

namespace Data.Implementation
{
    public class DataContext : IDataContext
    {
        public List<IUser> Users { get; set; }

        public List<IProduct> Products { get; set; }

        public List<IState> States { get; set; }

        public List<IEvent> Events { get; set; }

        public DataContext()
        {
            this.Users = new List<IUser>();

            this.Products = new List<IProduct>();

            this.States = new List<IState>();

            this.Events = new List<IEvent>();
        }
    }
}
