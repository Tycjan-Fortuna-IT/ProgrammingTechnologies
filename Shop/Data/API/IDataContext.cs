using Microsoft.EntityFrameworkCore;

namespace Data.API;

public interface IDataContext
{
    //public Dictionary<string, IUser> users { get; set; }

    //public Dictionary<string, IProduct> products { get; set; }

    //public Dictionary<string, IState> states { get; set; }

    //public Dictionary<string, IEvent> events { get; set; }

    public IQueryable<IUser> Users { get; }

    public IQueryable<IProduct> Products { get; }

    #region User CRUD

    Task AddUserAsync(IUser user);

    Task<IUser?> GetUserAsync(int id);

    Task UpdateUserAsync(IUser user);

    Task DeleteUserAsync(int id);

    Task<Dictionary<int, IUser>> GetAllUsersAsync();

    Task<int> GetUsersCountAsync();

    #endregion User CRUD


    #region Product CRUD

    Task AddProductAsync(IProduct product);

    Task<IProduct?> GetProductAsync(int id);

    Task UpdateProductAsync(IProduct product);

    Task DeleteProductAsync(int id);

    Task<Dictionary<int, IProduct>> GetAllProductsAsync();

    Task<int> GetProductsCountAsync();

    #endregion


    #region Utils

    Task<bool> CheckIfUserExists(int id);

    Task<bool> CheckIfProductExists(int id);

    #endregion
}
