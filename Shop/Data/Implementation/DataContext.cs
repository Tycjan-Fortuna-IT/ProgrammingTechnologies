using Data.API;

namespace Data.Implementation
{
    internal class DataContext : IDataContext
    {
        public Dictionary<string, IUser> users { get; set; }

        public Dictionary<string, IProduct> products { get; set; }

        public Dictionary<string, IState> states { get; set; }

        public Dictionary<string, IEvent> events { get; set; }

        public DataContext()
        {
            this.users = new Dictionary<string, IUser>();

            this.products = new Dictionary<string, IProduct>();

            this.states = new Dictionary<string, IState>();

            this.events = new Dictionary<string, IEvent>();
        }
    }
}
