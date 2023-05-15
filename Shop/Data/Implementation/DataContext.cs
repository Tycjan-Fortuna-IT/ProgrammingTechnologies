﻿using Data.API;
using Data.Database;

namespace Data.Implementation;

internal partial class DataContext : IDataContext
{
    public DataContext()
    {

    }

    private readonly string ConnectionString =
        "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\tycja\\Desktop\\ProgrammingTechnologies\\Shop\\Data\\Database\\Shop.mdf;Integrated Security=True";

    #region User CRUD

    public async Task AddUserAsync(IUser user)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.User entity = new Database.User()
            {
                id = user.Id,
                nickname = user.Nickname,
                email = user.Email,
                balance = (decimal)user.Balance,
                dateOfBirth = user.DateOfBirth,
            };

            context.Users.InsertOnSubmit(entity);

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<IUser?> GetUserAsync(int id)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.User? user = await Task.Run(() =>
            {
                IQueryable<Database.User> query =
                    from u in context.Users
                    where u.id == id
                    select u;

                return query.FirstOrDefault();
            });
        
            return user is not null ? new User(user.id, user.nickname, user.email, (double)user.balance, user.dateOfBirth) : null;
        }
    }

    public async Task UpdateUserAsync(IUser user)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.User current = context.Users.FirstOrDefault(u => u.id == user.Id)!;

            current.nickname = user.Nickname;
            current.email = user.Email;
            current.balance = (decimal)user.Balance;
            current.dateOfBirth = user.DateOfBirth;

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task DeleteUserAsync(int id)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.User toDelete = context.Users.FirstOrDefault(u => u.id == id)!;

            context.Users.DeleteOnSubmit(toDelete);

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<Dictionary<int, IUser>> GetAllUsersAsync()
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            IQueryable<IUser> usersQuery = from u in context.Users
                select
                    new User(u.id, u.nickname, u.email, (double)u.balance, u.dateOfBirth) as IUser;

            return await Task.Run(() => usersQuery.ToDictionary(k => k.Id));
        }
    }

    public async Task<int> GetUsersCountAsync()
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            return await Task.Run(() => context.Users.Count());
        }
    }

    #endregion


    #region Product CRUD

    public async Task AddProductAsync(IProduct product)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.Product entity = new Database.Product()
            {
                id = product.Id,
                name = product.Name,
                price = product.Price,
                pegi = product.Pegi,
            };

            context.Products.InsertOnSubmit(entity);

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<IProduct?> GetProductAsync(int id)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.Product? product = await Task.Run(() =>
            {
                IQueryable<Database.Product> query =
                    from p in context.Products
                    where p.id == id
                    select p;

                return query.FirstOrDefault();
            });

            return product is not null ? new Game(product.id, product.name, (double)product.price, product.pegi) : null;
        }
    }

    public async Task UpdateProductAsync(IProduct product)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.Product current = context.Products.FirstOrDefault(p => p.id == product.Id)!;

            current.name = product.Name;
            current.price = product.Price;
            current.pegi = product.Pegi;

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task DeleteProductAsync(int id)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.Product toDelete = context.Products.FirstOrDefault(p => p.id == id)!;

            context.Products.DeleteOnSubmit(toDelete);

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<Dictionary<int, IProduct>> GetAllProductsAsync()
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            IQueryable<IProduct> productQuery = from p in context.Products
                select
                    new Game(p.id, p.name, (double)p.price, p.pegi) as IProduct;

            return await Task.Run(() => productQuery.ToDictionary(k => k.Id));
        }
    }

    public async Task<int> GetProductsCountAsync()
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            return await Task.Run(() => context.Products.Count());
        }
    }

    #endregion


    #region State CRUD

    public async Task AddStateAsync(IState state)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.State entity = new Database.State()
            {
                id = state.Id,
                productId = state.productId,
                productQuantity = state.productQuantity
            };

            context.States.InsertOnSubmit(entity);

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<IState?> GetStateAsync(int id)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.State? state = await Task.Run(() =>
            {
                IQueryable<Database.State> query =
                    from s in context.States
                    where s.id == id
                    select s;

                return query.FirstOrDefault();
            });

            return state is not null ? new State(state.id, state.productId, state.productQuantity) : null;
        }
    }

    public async Task UpdateStateAsync(IState state)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.State current = context.States.FirstOrDefault(s => s.id == state.Id)!;

            current.productId = state.productId;
            current.productQuantity = state.productQuantity;

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task DeleteStateAsync(int id)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.State toDelete = context.States.FirstOrDefault(s => s.id == id)!;

            context.States.DeleteOnSubmit(toDelete);

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<Dictionary<int, IState>> GetAllStatesAsync()
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            IQueryable<IState> stateQuery = from s in context.States
                select
                    new State(s.id, s.productId, s.productQuantity) as IState;

            return await Task.Run(() => stateQuery.ToDictionary(k => k.Id));
        }
    }

    public async Task<int> GetStatesCountAsync()
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            return await Task.Run(() => context.States.Count());
        }
    }

    #endregion


    #region Event CRUD

    public async Task AddEventAsync(IEvent even, string type)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.Event entity = new Database.Event()
            {
                id = even.Id,
                stateId = even.stateId,
                userId = even.userId,
                occurrenceDate = even.occurrenceDate,
                type = type,
            };

            context.Events.InsertOnSubmit(entity);

            await Task.Run(() => context.SubmitChanges());
        }
    }    

    public async Task<IEvent?> GetEventAsync(int id, string type)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.Event? even = await Task.Run(() =>
            {
                IQueryable<Database.Event> query =
                    from e in context.Events
                    where e.id == id
                    select e;

                return query.FirstOrDefault();
            });

            IEvent newEvent;

            if (even is null)
                return null;

            switch (type)
            {
                case "PurchaseEvent":
                    newEvent = new PurchaseEvent(even.id, even.stateId, even.userId, even.occurrenceDate); break;
                case "ReturnEvent":
                    newEvent = new ReturnEvent(even.id, even.stateId, even.userId, even.occurrenceDate); break;
                case "SupplyEvent":
                    newEvent = new SupplyEvent(even.id, even.stateId, even.userId, even.occurrenceDate, (int)even.quantity!); break;
                default:
                    throw new Exception("This event type does not exist!");
            }

            return newEvent;
        }
        
    }    

    public async Task UpdateEventAsync(IEvent even)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.Event current = context.Events.FirstOrDefault(e => e.id == even.Id)!;

            current.stateId = even.stateId;
            current.userId = even.userId;
            current.occurrenceDate = even.occurrenceDate;

            await Task.Run(() => context.SubmitChanges());
        }
    }    

    public async Task DeleteEventAsync(int id)
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            Database.Event toDelete = context.Events.FirstOrDefault(e => e.id == id)!;

            context.Events.DeleteOnSubmit(toDelete);

            await Task.Run(() => context.SubmitChanges());
        }
    }    

    public async Task<Dictionary<int, IEvent>> GetAllEventsAsync()
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            IQueryable<IEvent> eventQuery = from e in context.Events
                select
                    new PurchaseEvent(e.id, e.stateId, e.userId, e.occurrenceDate) as IEvent;

            return await Task.Run(() => eventQuery.ToDictionary(k => k.Id));
        }
    }    

    public async Task<int> GetEventsCountAsync()
    {
        using (ShopDataContext context = new ShopDataContext(this.ConnectionString))
        {
            return await Task.Run(() => context.Events.Count());
        }
    }    

    #endregion


    #region Utils

    public async Task<bool> CheckIfUserExists(int id)
    {
        return (await this.GetUserAsync(id)) != null;
    }

    public async Task<bool> CheckIfProductExists(int id)
    {
        return (await this.GetProductAsync(id)) != null;
    }

    public async Task<bool> CheckIfStateExists(int id)
    {
        return (await this.GetStateAsync(id)) != null;
    }

    public async Task<bool> CheckIfEventExists(int id, string type)
    {
        return (await this.GetEventAsync(id, type)) != null;
    }

    #endregion
}

