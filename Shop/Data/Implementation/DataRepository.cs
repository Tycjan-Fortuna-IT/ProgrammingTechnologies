using Data.API;
using Data.Implementation.DTO;
using System.Diagnostics;

namespace Data.Implementation;

internal class DataRepository : IDataRepository
{
    private IDataContext _context;

    public DataRepository(IDataContext context) 
    {
        this._context = context;
    }

    #region User CRUD

    public async Task AddUserAsync(string nickname, string email, double balance, DateTime dateOfBirth)
    {
        IUser user = new User(-1, nickname, email, balance, dateOfBirth);

        await this._context.AddUserAsync(user);
    }

    public async Task<IUser> GetUserAsync(int id)
    {
        IUser? user = await this._context.GetUserAsync(id);

        if (user is null)
            throw new Exception("This user does not exist!");

        return user;
    }

    public async Task UpdateUserAsync(int id, string nickname, string email, double balance, DateTime dateOfBirth)
    {
        IUser user = new User(id, nickname, email, balance, dateOfBirth);

        if (!await this.CheckIfUserExists(user.Id))
            throw new Exception("This user does not exist");

        await this._context.UpdateUserAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        if (!await this.CheckIfUserExists(id))
            throw new Exception("This user does not exist");

        await this._context.DeleteUserAsync(id);
    }

    public async Task<Dictionary<int, IUser>> GetAllUsersAsync()
    {
        return await this._context.GetAllUsersAsync();
    }

    public async Task<int> GetUsersCountAsync()
    {
        return await this._context.GetUsersCountAsync();
    }

    #endregion


    #region Product CRUD

    public async Task AddProductAsync(string name, double price, int pegi)
    {
        IProduct product = new Game(-1, name, price, pegi);

        await this._context.AddProductAsync(product);
    }

    public async Task<IProduct> GetProductAsync(int id)
    {
        IProduct? product = await this._context.GetProductAsync(id);

        if (product is null)
            throw new Exception("This product does not exist!");

        return product;
    }

    public async Task UpdateProductAsync(int id, string name, double price, int pegi)
    {
        IProduct product = new Game(id, name, price, pegi);

        if (!await this.CheckIfProductExists(product.Id))
            throw new Exception("This product does not exist");

        await this._context.UpdateProductAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        if (!await this.CheckIfProductExists(id))
            throw new Exception("This product does not exist");

        await this._context.DeleteProductAsync(id);
    }

    public async Task<Dictionary<int, IProduct>> GetAllProductsAsync()
    {
        return await this._context.GetAllProductsAsync();
    }

    public async Task<int> GetProductsCountAsync()
    {
        return await this._context.GetProductsCountAsync();
    }

    #endregion


    #region State CRUD

    public async Task AddStateAsync(int productId, int productQuantity)
    {
        if (!await this._context.CheckIfProductExists(productId))
            throw new Exception("This product does not exist!");

        if (productQuantity <= 0)
            throw new Exception("Product's quantity must be number greater that 0!");

        IState state = new State(-1, productId, productQuantity);

        await this._context.AddStateAsync(state);
    }

    public async Task<IState> GetStateAsync(int id)
    {
        IState? state = await this._context.GetStateAsync(id);

        if (state is null)
            throw new Exception("This state does not exist!");

        return state;
    }

    public async Task UpdateStateAsync(int id, int productId, int productQuantity)
    {
        if (!await this._context.CheckIfProductExists(productId))
            throw new Exception("This product does not exist!");

        if (productQuantity <= 0)
            throw new Exception("Product's quantity must be number greater that 0!");

        IState state = new State(id, productId, productQuantity);

        if (!await this.CheckIfStateExists(state.Id))
            throw new Exception("This state does not exist");

        await this._context.UpdateStateAsync(state);
    }

    public async Task DeleteStateAsync(int id)
    {
        if (!await this.CheckIfStateExists(id))
            throw new Exception("This state does not exist");

        await this._context.DeleteStateAsync(id);
    }

    public async Task<Dictionary<int, IState>> GetAllStatesAsync()
    {
        return await this._context.GetAllStatesAsync();
    }

    public async Task<int> GetStatesCountAsync()
    {
        return await this._context.GetStatesCountAsync();
    }

    #endregion


    #region Event CRUD

    public async Task AddEventAsync(int id, int stateId, int userId, string type, int quantity = 0)
    {
        IEvent newEvent;

        switch (type)
        {
            case "PurchaseEvent":
                newEvent = new PurchaseEvent(id, stateId, userId, DateTime.Now); break;
            case "ReturnEvent":
                newEvent = new ReturnEvent(id, stateId, userId, DateTime.Now); break;
            case "SupplyEvent":
                newEvent = new SupplyEvent(id, stateId, userId, DateTime.Now, quantity); break;
            default:
                throw new Exception("This event type does not exist!");
        }

        newEvent.Action(this);

        await this._context.AddEventAsync(newEvent);
    }

    public async Task<IEvent> GetEventAsync(int id, string type)
    {
        IEvent? even = await this._context.GetEventAsync(id, type);

        if (even is null)
            throw new Exception("This event does not exist!");

        return even;
    }

    public async Task UpdateEventAsync(int id, int stateId, int userId, string type, int? quantity)
    {
        IEvent newEvent;

        switch (type)
        {
            case "PurchaseEvent":
                newEvent = new PurchaseEvent(id, stateId, userId, DateTime.Now); break;
            case "ReturnEvent":
                newEvent = new ReturnEvent(id, stateId, userId, DateTime.Now); break;
            case "SupplyEvent":
                newEvent = new SupplyEvent(id, stateId, userId, DateTime.Now, (int)quantity!); break;
            default:
                throw new Exception("This event type does not exist!");
        }

        if (!await this.CheckIfEventExists(newEvent.Id, type))
            throw new Exception("This event does not exist");

        await this._context.UpdateEventAsync(newEvent);
    }

    public async Task DeleteEventAsync(int id)
    {
        if (!await this.CheckIfEventExists(id, "NotRelevant"))
            throw new Exception("This event does not exist");

        await this._context.DeleteEventAsync(id);
    }

    public async Task<Dictionary<int, IEvent>> GetAllEventsAsync()
    {
        return await this._context.GetAllEventsAsync();
    }

    public async Task<int> GetEventsCountAsync()
    {
        return await this._context.GetEventsCountAsync();
    }

    #endregion


    #region Utils

    public async Task<bool> CheckIfUserExists(int id)
    {
        return await this._context.CheckIfUserExists(id);
    }

    public async Task<bool> CheckIfProductExists(int id)
    {
        return await this._context.CheckIfProductExists(id);
    }

    public async Task<bool> CheckIfStateExists(int id)
    {
        return await this._context.CheckIfStateExists(id);
    }

    public async Task<bool> CheckIfEventExists(int id, string type)
    {
        return await this._context.CheckIfEventExists(id, type);
    }

    //public async Task<IEvent> GetLastProductEvent(int productId)

    //}

    //public async Task<Dictionary<int, IEvent>> GetProductEventHistory(int productId)
    //{

    //}

    //public async Task<IState> GetProductState(int productId)
    //{

    //}

    #endregion
}
