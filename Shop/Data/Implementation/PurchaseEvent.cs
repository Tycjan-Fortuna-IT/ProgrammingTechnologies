using Data.API;

namespace Data.Implementation
{
    internal class PurchaseEvent : IEvent
    {
        public PurchaseEvent(string? guid, string stateGuid, string userGuid) 
        {
            this.guid = guid ?? System.Guid.NewGuid().ToString();
            this.stateGuid = stateGuid;
            this.userGuid = userGuid;
            this.occurrenceDate = DateTime.Now;
        }

        public string guid { get; }

        public string stateGuid { get; }

        public string userGuid { get; }

        public DateTime occurrenceDate { get; }

        public void Action(IDataRepository dataRepository) 
        {
            IUser user = dataRepository.GetUser(this.userGuid);
            IState state = dataRepository.GetState(this.stateGuid);
            IProduct product = dataRepository.GetProduct(state.productGuid);

            if (user.productLibrary.ContainsKey(product.guid))
                throw new Exception("You already have this product!");   

            if (product is Game)
                if (DateTime.Now.Year - user.dateOfBirth.Year < ((Game)product).pegi)
                    throw new Exception("You are not old enough to purchase this game!");

            if (state.productQuantity == 0)
                throw new Exception("Product unavailable, please check later!");

            if (user.balance < product.price)
                throw new Exception("Not enough money to purchase this product!");

            state.productQuantity--;
            user.balance -= product.price;
            user.productLibrary.Add(product.guid, product);
        }
    }
}