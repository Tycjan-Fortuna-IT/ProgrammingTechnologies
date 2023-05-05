using Data.Implementation;

namespace Data.API
{
    public interface IDataRepository
    {
        static IDataRepository CreateDatabase(IDataContext dataContext = null)
        {
            return new DataRepository(dataContext ?? new DataContext());
        }

        // --- User ---
        void AddUser(string? guid, string nickname, string email, double balance, DateTime dateOfBirth);
        IUser GetUser(string guid);
        bool CheckIfUserExists(string guid);
        void UpdateUser(string guid, string nickname, string email, double balance, DateTime dateOfBirth);
        void DeleteUser(string guid);
        Dictionary<string, IUser> GetAllUsers();
        int GetUserCount();

        // --- Product ---
        void AddProduct(string? guid, string name, double price, int pegi);
        IProduct GetProduct(string guid);
        bool CheckIfProductExists(string guid);
        void UpdateProduct(string guid, string name, double price, int pegi);
        void DeleteProduct(string guid);
        Dictionary<string, IProduct> GetAllProducts();
        int GetProductCount();

        // --- State ---
        void AddState(string? guid, string productGuid, int productQuantity = 0);
        IState GetState(string guid);
        void DeleteState(string guid);
        Dictionary<string, IState> GetAllStates();
        int GetStateCount();

        // --- Event ---
        void AddEvent(string? guid, string stateGuid, string userGuid, string type, int quantity = 0);
        IEvent GetEvent(string guid);
        bool CheckIfEventExists(string guid);
        void DeleteEvent(string guid);
        Dictionary<string, IEvent> GetAllEvents();
        int GetEventCount();

        IEvent GetLastProductEvent(string productGuid);
        Dictionary<string, IEvent> GetProductEventHistory(string productGuid);
        IState GetProductState(string productGuid);
    }
}
