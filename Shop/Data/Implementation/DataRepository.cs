using Data.API;

namespace Data.Implementation
{
    internal class DataRepository : IDataRepository
    {
        private IDataContext context;

        public DataRepository(IDataContext context) 
        {
            this.context = context;
        }

        // --- User ---
        public void AddUser(string? guid, string nickname, string email, double balance, DateTime dateOfBirth)
        {
            if (guid is not null && this.CheckIfUserExists(guid))
                throw new Exception("This user already exists!");

            IUser newUser = new User(guid, nickname, email, balance, dateOfBirth);

            this.context.users.Add(newUser.guid, newUser);
        }

        public IUser GetUser(string guid)
        {
            if (!this.CheckIfUserExists(guid))
                throw new Exception("This user does not exist!");

            return this.context.users[guid];
        }

        public bool CheckIfUserExists(string guid)
        {
            return this.context.users.ContainsKey(guid);
        }

        public void UpdateUser(string guid, string nickname, string email, double balance, DateTime dateOfBirth)
        {
            if (!this.CheckIfUserExists(guid))
                throw new Exception("This user does not exist!");

            IUser userToUpdate = this.GetUser(guid);

            userToUpdate.nickname = nickname;
            userToUpdate.email = email;
            userToUpdate.balance = balance;
            userToUpdate.dateOfBirth = dateOfBirth;
        }

        public void DeleteUser(string guid) 
        {
            if (!this.CheckIfUserExists(guid))
                throw new Exception("This user does not exist!");

            this.context.users.Remove(guid);
        }

        public Dictionary<string, IUser> GetAllUsers()
        {
            return this.context.users;
        }

        public int GetUserCount() 
        {
            return this.context.users.Count;
        }


        // --- Product ---
        public void AddProduct(string? guid, string name, double price, int pegi) 
        {
            if (guid is not null && this.CheckIfProductExists(guid))
                throw new Exception("This product already exists!");

            IProduct newProduct = new Game(guid, name, price, pegi);

            this.context.products.Add(newProduct.guid, newProduct);
        }

        public IProduct GetProduct(string guid) 
        {
            if (!this.CheckIfProductExists(guid))
                throw new Exception("This product does not exist!");

            return this.context.products[guid];
        }

        public bool CheckIfProductExists(string guid)
        {
            return this.context.products.ContainsKey(guid);
        }

        public void UpdateProduct(string guid, string name, double price, int pegi) 
        {
            if (!this.CheckIfProductExists(guid))
                throw new Exception("This product does not exist!");

            IProduct productToUpdate = this.GetProduct(guid);

            productToUpdate.name = name;
            productToUpdate.price = price;
            productToUpdate.pegi = pegi;
        }

        public void DeleteProduct(string guid) 
        {
            if (!this.CheckIfProductExists(guid))
                throw new Exception("This product does not exist!");

            this.context.products.Remove(guid);
        }

        public Dictionary<string, IProduct> GetAllProducts() 
        {
            return this.context.products;
        }

        public int GetProductCount() 
        {
            return this.context.products.Count;
        }


        // --- State ---
        public void AddState(string? guid, string productGuid, int productQuantity = 0) 
        {
            if (guid is not null && this.CheckIfStateExists(guid))
                throw new Exception("This state already exists!");

            IState newState = new State(guid, productGuid, productQuantity);

            this.context.states.Add(newState.guid, newState);
        }

        public IState GetState(string guid) 
        {
            if (!this.CheckIfStateExists(guid))
                throw new Exception("This state does not exist!");

            return this.context.states[guid];
        }

        public bool CheckIfStateExists(string guid)
        {
            return this.context.states.ContainsKey(guid);
        }

        public void DeleteState(string guid) 
        {
            if (!this.CheckIfStateExists(guid))
                throw new Exception("This state does not exist!");

            this.context.states.Remove(guid);
        }

        public Dictionary<string, IState> GetAllStates() 
        {
            return this.context.states;
        }

        public int GetStateCount()
        {
            return this.context.states.Count;
        }


        // --- Event ---
        public void AddEvent(string? guid, string stateGuid, string userGuid, string type, int quantity = 0) 
        {
            if (guid is not null && this.CheckIfEventExists(guid))
                throw new Exception("This event already exists!");

            IEvent newEvent;

            switch (type)
            {
                case "PurchaseEvent":
                    newEvent = new PurchaseEvent(guid, stateGuid, userGuid); break;
                case "ReturnEvent":
                    newEvent = new ReturnEvent(guid, stateGuid, userGuid); break;
                case "SupplyEvent":
                    newEvent = new SupplyEvent(guid, stateGuid, userGuid, quantity); break;
                default:
                    throw new Exception("This event type does not exist!");
            }

            newEvent.Action(this);

            this.context.events.Add(newEvent.guid, newEvent);
        }

        public IEvent GetEvent(string guid) 
        {
            if (!this.CheckIfEventExists(guid))
                throw new Exception("This event does not exist!");

            return this.context.events[guid];
        }

        public bool CheckIfEventExists(string guid)
        {
            return this.context.events.ContainsKey(guid);
        }

        public void DeleteEvent(string guid) 
        {
            if (!this.CheckIfEventExists(guid))
                throw new Exception("This event does not exist!");

            this.context.events.Remove(guid);
        }

        public Dictionary<string, IEvent> GetAllEvents() 
        {
            return this.context.events;
        }

        public int GetEventCount() 
        {
            return this.context.events.Count;
        }


        public IEvent GetLastProductEvent(string productGuid)
        {   
            Dictionary<string, IEvent> productEvents = this.context.events
                .Where(
                    kvp => this.GetState(kvp.Value.stateGuid).productGuid == productGuid
                )
                .ToDictionary(
                    kvp => kvp.Key, kvp => kvp.Value
                );

            IEvent? lastProductEvent = null;

            foreach (KeyValuePair<string, IEvent> productEvent in productEvents)
                if (lastProductEvent is not null && lastProductEvent.occurrenceDate < productEvent.Value.occurrenceDate)
                    lastProductEvent = productEvent.Value;
                else
                    lastProductEvent = productEvent.Value;

            if (lastProductEvent is null)
                throw new Exception("There have been no events for this product!");

            return lastProductEvent;
        }

        public Dictionary<string, IEvent> GetProductEventHistory(string productGuid)
        {
            return this.context.events
                .Where(
                    kvp => this.GetState(kvp.Value.stateGuid).productGuid == productGuid
                )
                .ToDictionary(
                    kvp => kvp.Key, kvp => kvp.Value
                );
        }

        public IState GetProductState(string productGuid)
        {
            if (!this.CheckIfProductExists(productGuid))
                throw new Exception("This product does not exist!");

            IState state = this.context.states
                .First(
                    kvp => kvp.Value.productGuid == productGuid
                )
                .Value;

            return state;
        }
    }
}
