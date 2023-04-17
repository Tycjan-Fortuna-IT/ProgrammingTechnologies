namespace Data.API
{
    public interface IDataContext
    {
        public List<IUser> users {get; set;}

        public List<IProduct> products { get; set; }

        public List<IState> states { get; set; }

        public List<IEvent> events { get; set; }
    }
}