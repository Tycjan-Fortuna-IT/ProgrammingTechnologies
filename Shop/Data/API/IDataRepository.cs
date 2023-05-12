﻿using Data.Implementation;

namespace Data.API;

public interface IDataRepository
{
    static IDataRepository CreateDatabase(IDataContext? dataContext = null)
    {
        return new DataRepository(dataContext ?? new DataContext());
    }

    #region User CRUD

    Task AddUserAsync(int id, string nickname, string email, double balance, DateTime dateOfBirth);

    Task<IUser> GetUserAsync(int id);

    Task UpdateUserAsync(int id, string nickname, string email, double balance, DateTime dateOfBirth);

    Task DeleteUserAsync(int id);

    Task<Dictionary<int, IUser>> GetAllUsersAsync();

    Task<int> GetUsersCountAsync();

    #endregion User CRUD


    #region Product CRUD

    Task AddProductAsync(int id, string name, double price, int pegi);

    Task<IProduct> GetProductAsync(int id);

    Task UpdateProductAsync(int id, string name, double price, int pegi);

    Task DeleteProductAsync(int id);

    Task<Dictionary<int, IProduct>> GetAllProductsAsync();

    Task<int> GetProductsCountAsync();

    #endregion


    #region State CRUD

    Task AddStateAsync(int id, int productId, int productQuantity);

    Task<IState> GetStateAsync(int id);

    Task UpdateStateAsync(int id, int productId, int productQuantity);

    Task DeleteStateAsync(int id);

    Task<Dictionary<int, IState>> GetAllStatesAsync();

    Task<int> GetStatesCountAsync();

    #endregion


    #region Event CRUD

    Task AddEventAsync(int id, int stateId, int userId, string type, int quantity = 0);

    Task<IEvent> GetEventAsync(int id, string type);

    Task UpdateEventAsync(int id, int stateId, int userId, string type, int? quantity);

    Task DeleteEventAsync(int id);

    Task<Dictionary<int, IEvent>> GetAllEventsAsync();

    Task<int> GetEventsCountAsync();

    #endregion


    #region Utils

    Task<bool> CheckIfUserExists(int id);

    Task<bool> CheckIfProductExists(int id);

    Task<bool> CheckIfStateExists(int id);

    Task<bool> CheckIfEventExists(int id, string type);

    //Task<IEvent> GetLastProductEvent(int productId);
    
    //Task<Dictionary<int, IEvent>> GetProductEventHistory(int productId);
    
    //Task<IState> GetProductState(int productId);
    
    #endregion
}
