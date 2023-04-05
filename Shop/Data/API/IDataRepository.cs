namespace Shop.Data
{
    public interface IDataRepository
    {
        // void Add<T>(T element);
        // T Get<T>(string Guid);
        // void Update<T>(string Guid, T element);
        // void DeleteUser<T>(string Guid);
        // Dictionary<string, T> GetAll<T>();
        // int GetCount<T>();

        void AddUser(IUser User);
        IUser GetUser(string Guid);
        void UpdateUser(string Guid, IUser User);
        void DeleteUser(string Guid);
        Dictionary<string, IUser> GetAllUsers();
        int GetUsersCount();

        // void AddProduct(IProduct Product);
        // IProduct GetProduct(string Guid);
        // void UpdateProduct(string Guid, IProduct Product);
        // void DeleteProduct(string Guid);
        // Dictionary<string, IProduct> GetAllProducts();
        // int GetProductsCount();

        // void AddEvent(IEvent Event);
        // IEvent GetEvent(string Guid);
        // void UpdateEvent(string Guid, IEvent Event);
        // void DeleteEvent(string Guid);
        // Dictionary<string, IEvent> GetAllEvents();
        // int GetEventsCount();

        // void AddState(IState State);
        // IState GetState(string Guid);
        // void UpdateState(string Guid, IState State);
        // void DeleteState(string Guid);
        // Dictionary<string, IState> GetAllStates();
        // int GetStatesCount();
    }
}
