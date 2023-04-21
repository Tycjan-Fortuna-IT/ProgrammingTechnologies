using Data.API;

namespace Data.Implementation
{
    internal class ReturnEvent : IEvent
    {
        public ReturnEvent(string? guid, string stateGuid, string userGuid)
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

            if (!user.productLibrary.ContainsKey(product.guid))
                throw new Exception("You do not have this Product!");

            state.productQuantity++;
            user.balance += product.price;
            user.productLibrary.Remove(product.guid);
        }
    }
}