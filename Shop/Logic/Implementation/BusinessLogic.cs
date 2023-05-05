using Data.API;
using Logic.API;

namespace Shop.Logic
{
    internal class BusinessLogic : IBusinessLogic
    {
        private IDataRepository repository;

        public BusinessLogic(IDataRepository repository)
        {
            this.repository = repository;
        }

        public void Purchase(string stateGuid, string userGuid)
        {
            IState state = repository.GetState(stateGuid);

            if (!this.repository.CheckIfProductExists(state.productGuid))
                throw new Exception("This product is not registered in our system!");

            if (!this.repository.CheckIfUserExists(userGuid))
                throw new Exception("This user is not registered in our system!");

            this.repository.AddEvent(null, stateGuid, userGuid, "PurchaseEvent");
        }

        public void Return(string stateGuid, string userGuid) 
        {
            IState state = repository.GetState(stateGuid);

            if (!this.repository.CheckIfProductExists(state.productGuid))
                throw new Exception("This product is not registered in our system!");

            if (!this.repository.CheckIfUserExists(userGuid))
                throw new Exception("This user is not registered in our system!");

            this.repository.AddEvent(null, stateGuid, userGuid, "ReturnEvent");
        }

        public void Supply(string stateGuid, string userGuid, int quantity)
        {
            IState state = repository.GetState(stateGuid);

            if (!this.repository.CheckIfProductExists(state.productGuid))
                throw new Exception("This product is not registered in our system!");

            if (!this.repository.CheckIfUserExists(userGuid))
                throw new Exception("This user is not registered in our system!");

            this.repository.AddEvent(null, stateGuid, userGuid, "SupplyEvent", quantity);
        }
    }
}
