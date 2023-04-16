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
            IUser? duplicateUser = this._context.users.Find(element => element.guid == user.guid);

            if (duplicateUser is not null)
                throw new Exception("This user already exists!");

            this._context.users.Add(user);
        }

        public IUser GetUser(string guid)
        {
            IUser? foundUser = this._context.users.Find(element => element.guid == guid);

            if (foundUser is null)
                throw new Exception("This user does not exist!");

            return foundUser;
        }

        public bool CheckIfUserExists(string guid)
        {
            return this._context.users.Exists(element => element.guid == guid);
        }

        public void UpdateUser(IUser user)
        {
            IUser? userToUpdate = this._context.users.Find(element => element.guid == user.guid);

            if (userToUpdate is null)
                throw new Exception("This user does not exist!");

            userToUpdate = user;
        }

        public void DeleteUser(string guid) 
        {
            IUser? userToDelete = this._context.users.Find(element => element.guid == guid);

            if (userToDelete is null)
                throw new Exception("This user does not exist!");

            this._context.users.Remove(userToDelete);
        }

        public List<IUser> GetAllUsers()
        {
            return this._context.users;
        }

        public int GetUserCount() 
        {
            return this._context.users.Count;
        }


        // --- Product ---
        public void AddProduct(IProduct product) 
        {
            IProduct? duplicateProduct = this._context.products.Find(element => element.guid == product.guid);

            if (duplicateProduct is not null)
                throw new Exception("This product already exists!");

            this._context.products.Add(product);
        }

        public IProduct GetProduct(string guid) 
        {
            IProduct? foundProduct = this._context.products.Find(element => element.guid == guid);

            if (foundProduct is null)
                throw new Exception("This product does not exist!");

            return foundProduct;
        }

        public bool CheckIfProductExists(string guid)
        {
            return this._context.products.Exists(element => element.guid == guid);
        }

        public void UpdateProduct(IProduct product) 
        {
            IProduct? productToUpdate = this._context.products.Find(element => element.guid == product.guid);

            if (productToUpdate is null)
                throw new Exception("This user does not exist!");

            productToUpdate = product;
        }

        public void DeleteProduct(string guid) 
        {
            IProduct? productToDelete = this._context.products.Find(element => element.guid == guid);

            if (productToDelete is null)
                throw new Exception("This product does not exist!");

            this._context.products.Remove(productToDelete);
        }

        public List<IProduct> GetAllProducts() 
        {
            return this._context.products;
        }

        public int GetProductCount() 
        {
            return this._context.products.Count;
        }


        // --- State ---
        public void AddState(IState product) 
        {
            IState? duplicateState = this._context.states.Find(element => element.guid == product.guid);

            if (duplicateState is not null)
                throw new Exception("This state already exists!");

            this._context.states.Add(product);
        }

        public IState GetState(string guid) 
        {
            IState? foundState = this._context.states.Find(element => element.guid == guid);

            if (foundState is null)
                throw new Exception("This state does not exist!");

            return foundState;
        }

        public void DeleteState(string guid) 
        {
            IState? stateToDelete = this._context.states.Find(element => element.guid == guid);

            if (stateToDelete is null)
                throw new Exception("This state does not exist!");

            this._context.states.Remove(stateToDelete);
        }

        public List<IState> GetAllStates() 
        {
            return this._context.states;
        }

        public int GetStateCount()
        {
            return this._context.states.Count;
        }


        // --- Event ---
        public void AddEvent(IEvent shopEvent) 
        {
            IEvent? duplicateEvent = this._context.events.Find(element => element.guid == shopEvent.guid);

            if (duplicateEvent is not null)
                throw new Exception("This event already exists!");

            this._context.events.Add(shopEvent);
        }

        public IEvent GetEvent(string guid) 
        {
            IEvent? foundEvent = this._context.events.Find(element => element.guid == guid);

            if (foundEvent is null)
                throw new Exception("This event does not exist!");

            return foundEvent;
        }

        public void DeleteEvent(string guid) 
        {
            IEvent? eventToDelete = this._context.events.Find(element => element.guid == guid);

            if (eventToDelete is null)
                throw new Exception("This event does not exist!");

            this._context.events.Remove(eventToDelete);
        }

        public List<IEvent> GetAllEvents() 
        {
            return this._context.events;
        }

        public int GetEventCount() 
        {
            return this._context.events.Count;
        }


        public IEvent GetLastProductEvent(string productGuid)
        {
            List<IEvent> productEvents = this._context.events.FindAll(element => element.state.product.guid == productGuid);

            IEvent? lastProductEvent = null;

            foreach (IEvent productEvent in productEvents)
                if (lastProductEvent is not null && lastProductEvent.occurrenceDate < productEvent.occurrenceDate)
                    lastProductEvent = productEvent;
                else
                    lastProductEvent = productEvent;

            if (lastProductEvent is null)
                throw new Exception("There have been no events for this product!");

            return lastProductEvent;
        }

        public List<IEvent> GetProductEventHistory(string productGuid)
        {
            return this._context.events.FindAll(element => element.state.product.guid == productGuid);
        }

        public IState GetProductState(string productGuid) 
        {
            IState? state = this._context.states.Find(element => element.product.guid == productGuid);

            if (state is null)
                throw new Exception("There is no state for this product!");

            return state;
        }
    }
}
