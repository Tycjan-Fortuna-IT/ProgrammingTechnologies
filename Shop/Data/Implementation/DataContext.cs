using Data.API;

namespace Data.Implementation
{
    public class DataContext : IDataContext
    {
        public List<IUser> users { get; set; }

        public List<IProduct> products { get; set; }

        public List<IState> states { get; set; }

        public List<IEvent> events { get; set; }

        public DataContext()
        {
            this.users = new List<IUser>();

            this.products = new List<IProduct>();

            this.states = new List<IState>();

            this.events = new List<IEvent>();
        }
    }
}
