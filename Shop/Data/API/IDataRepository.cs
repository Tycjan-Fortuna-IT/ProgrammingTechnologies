using Data.Implementation;

namespace Data.API
{
    public interface IDataRepository
    {
        static IDataRepository CreateDatabase(IDataContext dataContext)
        {
            return new DataRepository(dataContext);
        }

        // --- User ---
        void AddUser(IUser user);
        IUser GetUser(string guid);
        bool CheckIfUserExists(string guid);
        void UpdateUser(IUser user);
        void DeleteUser(string guid);
        List<IUser> GetAllUsers();
        int GetUserCount();

        // --- Product ---
        void AddProduct(IProduct product);
        IProduct GetProduct(string guid);
        bool CheckIfProductExists(string guid);
        void UpdateProduct(IProduct product);
        void DeleteProduct(string guid);
        List<IProduct> GetAllProducts();
        int GetProductCount();

        // --- State ---
        void AddState(IState product);
        IState GetState(string guid);
        void DeleteState(string guid);
        List<IState> GetAllStates();
        int GetStateCount();

        // --- Event ---
        void AddEvent(IEvent shopEvent);
        IEvent GetEvent(string guid);
        void DeleteEvent(string guid);
        List<IEvent> GetAllEvents();
        int GetEventCount();

        IEvent GetLastProductEvent(string productGuid);
        List<IEvent> GetProductEventHistory(string productGuid);
        IState GetProductState(string productGuid);
    }
}
