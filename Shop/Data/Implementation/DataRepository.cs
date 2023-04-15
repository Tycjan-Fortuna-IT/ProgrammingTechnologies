using Data.API;
using System;

namespace Data.Implementation
{
    public class DataRepository : IDataRepository
    {
        private IDataContext _context;

        public DataRepository(IDataContext context) 
        {
            this._context = context;
        }

        // --- User ---
        public void AddUser(IUser user)
        {
            IUser? duplicateUser = this._context.Users.Find(element => element.Guid == user.Guid);

            if (duplicateUser is not null)
                throw new Exception("This user already exists!");

            this._context.Users.Add(user);
        }

        public IUser GetUser(string guid)
        {
            IUser? foundUser = this._context.Users.Find(element => element.Guid == guid);

            if (foundUser is null)
                throw new Exception("This user does not exist!");

            return foundUser;
        }

        public bool CheckIfUserExists(string guid)
        {
            return this._context.Users.Exists(element => element.Guid == guid);
        }

        public void UpdateUser(IUser user)
        {
            IUser? userToUpdate = this._context.Users.Find(element => element.Guid == user.Guid);

            if (userToUpdate is null)
                throw new Exception("This user does not exist!");

            userToUpdate = user;
        }

        public void DeleteUser(string guid) 
        {
            IUser? userToDelete = this._context.Users.Find(element => element.Guid == guid);

            if (userToDelete is null)
                throw new Exception("This user does not exist!");

            this._context.Users.Remove(userToDelete);
        }

        public List<IUser> GetAllUsers()
        {
            return this._context.Users;
        }

        public int GetUserCount() 
        {
            return this._context.Users.Count;
        }


        // --- Product ---
        public void AddProduct(IProduct product) 
        {
            IProduct? duplicateProduct = this._context.Products.Find(element => element.Guid == product.Guid);

            if (duplicateProduct is not null)
                throw new Exception("This product already exists!");

            this._context.Products.Add(product);
        }

        public IProduct GetProduct(string guid) 
        {
            IProduct? foundProduct = this._context.Products.Find(element => element.Guid == guid);

            if (foundProduct is null)
                throw new Exception("This product does not exist!");

            return foundProduct;
        }

        public bool CheckIfProductExists(string guid)
        {
            return this._context.Products.Exists(element => element.Guid == guid);
        }

        public void UpdateProduct(IProduct product) 
        {
            IProduct? productToUpdate = this._context.Products.Find(element => element.Guid == product.Guid);

            if (productToUpdate is null)
                throw new Exception("This user does not exist!");

            productToUpdate = product;
        }

        public void DeleteProduct(string guid) 
        {
            IProduct? productToDelete = this._context.Products.Find(element => element.Guid == guid);

            if (productToDelete is null)
                throw new Exception("This product does not exist!");

            this._context.Products.Remove(productToDelete);
        }

        public List<IProduct> GetAllProducts() 
        {
            return this._context.Products;
        }

        public int GetProductCount() 
        {
            return this._context.Products.Count;
        }


        // --- State ---
        public void AddState(IState product) 
        {
            IState? duplicateState = this._context.States.Find(element => element.Guid == product.Guid);

            if (duplicateState is not null)
                throw new Exception("This state already exists!");

            this._context.States.Add(product);
        }

        public IState GetState(string guid) 
        {
            IState? foundState = this._context.States.Find(element => element.Guid == guid);

            if (foundState is null)
                throw new Exception("This state does not exist!");

            return foundState;
        }

        public void DeleteState(string guid) 
        {
            IState? stateToDelete = this._context.States.Find(element => element.Guid == guid);

            if (stateToDelete is null)
                throw new Exception("This state does not exist!");

            this._context.States.Remove(stateToDelete);
        }

        public List<IState> GetAllStates() 
        {
            return this._context.States;
        }

        public int GetStateCount()
        {
            return this._context.States.Count;
        }


        // --- Event ---
        public void AddEvent(IEvent shopEvent) 
        {
            IEvent? duplicateEvent = this._context.Events.Find(element => element.Guid == shopEvent.Guid);

            if (duplicateEvent is not null)
                throw new Exception("This event already exists!");

            this._context.Events.Add(shopEvent);
        }

        public IEvent GetEvent(string guid) 
        {
            IEvent? foundEvent = this._context.Events.Find(element => element.Guid == guid);

            if (foundEvent is null)
                throw new Exception("This event does not exist!");

            return foundEvent;
        }

        public void DeleteEvent(string guid) 
        {
            IEvent? eventToDelete = this._context.Events.Find(element => element.Guid == guid);

            if (eventToDelete is null)
                throw new Exception("This event does not exist!");

            this._context.Events.Remove(eventToDelete);
        }

        public List<IEvent> GetAllEvents() 
        {
            return this._context.Events;
        }

        public int GetEventCount() 
        {
            return this._context.Events.Count;
        }


        public IEvent GetLastProductEvent(string productGuid)
        {
            List<IEvent> productEvents = this._context.Events.FindAll(element => element.State.Product.Guid == productGuid);

            IEvent? lastProductEvent = null;

            foreach (IEvent productEvent in productEvents)
                if (lastProductEvent is not null && lastProductEvent.OccurrenceDate < productEvent.OccurrenceDate)
                    lastProductEvent = productEvent;
                else
                    lastProductEvent = productEvent;

            if (lastProductEvent is null)
                throw new Exception("There have been no events for this product!");

            return lastProductEvent;
        }

        public List<IEvent> GetProductEventHistory(string productGuid)
        {
            return this._context.Events.FindAll(element => element.State.Product.Guid == productGuid);
        }

        public IState GetProductState(string productGuid) 
        {
            IState? state = this._context.States.Find(element => element.Product.Guid == productGuid);

            if (state is null)
                throw new Exception("There is no state for this product!");

            return state;
        }
    }
}
