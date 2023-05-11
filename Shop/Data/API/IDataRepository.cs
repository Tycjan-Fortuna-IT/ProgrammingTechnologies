using Data.Implementation;

namespace Data.API;

public interface IDataRepository
{
    static IDataRepository CreateDatabase(IDataContext dataContext = null)
    {
        return new DataRepository(dataContext ?? new DataContext());
    }

    // --- User ---
    //void AddUser(string? guid, string nickname, string email, double balance, DateTime dateOfBirth);
    //IUser GetUser(string guid);
    //bool CheckIfUserExists(string guid);
    //void UpdateUser(string guid, string nickname, string email, double balance, DateTime dateOfBirth);
    //void DeleteUser(string guid);
    //Dictionary<string, IUser> GetAllUsers();
    //int GetUserCount();

    #region User CRUD

    Task AddUserAsync(string nickname, string email, double balance, DateTime dateOfBirth);

    Task<IUser> GetUserAsync(int id);

    Task UpdateUserAsync(int id, string nickname, string email, double balance, DateTime dateOfBirth);

    Task DeleteUserAsync(int id);

    Task<Dictionary<int, IUser>> GetAllUsersAsync();

    Task<int> GetUsersCountAsync();

    #endregion User CRUD


    #region Product CRUD

    Task AddProductAsync(string name, double price, int pegi);

    Task<IProduct> GetProductAsync(int id);

    Task UpdateProductAsync(int id, string name, double price, int pegi);

    Task DeleteProductAsync(int id);

    Task<Dictionary<int, IProduct>> GetAllProductsAsync();

    Task<int> GetProductsCountAsync();

    #endregion


    #region Utils

    Task<bool> CheckIfUserExists(int id);

    Task<bool> CheckIfProductExists(int id);

    #endregion

    //// --- Product ---
    //void AddProduct(string? guid, string name, double price, int pegi);
    //IProduct GetProduct(string guid);
    //bool CheckIfProductExists(string guid);
    //void UpdateProduct(string guid, string name, double price, int pegi);
    //void DeleteProduct(string guid);
    //Dictionary<string, IProduct> GetAllProducts();
    //int GetProductCount();

    //// --- State ---
    //void AddState(string? guid, string productGuid, int productQuantity = 0);
    //IState GetState(string guid);
    //void DeleteState(string guid);
    //Dictionary<string, IState> GetAllStates();
    //int GetStateCount();

    //// --- Event ---
    //void AddEvent(string? guid, string stateGuid, string userGuid, string type, int quantity = 0);
    //IEvent GetEvent(string guid);
    //bool CheckIfEventExists(string guid);
    //void DeleteEvent(string guid);
    //Dictionary<string, IEvent> GetAllEvents();
    //int GetEventCount();

    //IEvent GetLastProductEvent(string productGuid);
    //Dictionary<string, IEvent> GetProductEventHistory(string productGuid);
    //IState GetProductState(string productGuid);
}
