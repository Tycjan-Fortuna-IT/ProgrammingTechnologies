namespace Data.API
{
    public interface IDataContext
    {
        public Dictionary<string, IUser> users { get; set; }

        public Dictionary<string, IProduct> products { get; set; }

        public Dictionary<string, IState> states { get; set; }

        public Dictionary<string, IEvent> events { get; set; }
    }
}