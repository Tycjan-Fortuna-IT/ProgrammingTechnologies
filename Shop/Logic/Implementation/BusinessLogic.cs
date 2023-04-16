using Data.API;
using Data.Implementation;
using Logic.API;

namespace Shop.Logic
{
    public class BusinessLogic : IBusinessLogic
    {
        private IDataRepository repository;

        public BusinessLogic(IDataRepository repository)
        {
            this.repository = repository;
        }

        public void Purchase(IState state, IUser user)
        {
            if (!this.repository.CheckIfProductExists(state.product.guid))
                throw new Exception("This product is not registered in our system!");

            if (!this.repository.CheckIfUserExists(user.guid))
                throw new Exception("This user is not registered in our system!");

            this.repository.AddEvent(new PurchaseEvent(null, state, user));
        }

        public void Return(IState state, IUser user) 
        {
            if (!this.repository.CheckIfProductExists(state.product.guid))
                throw new Exception("This product is not registered in our system!");

            if (!this.repository.CheckIfUserExists(user.guid))
                throw new Exception("This user is not registered in our system!");

            this.repository.AddEvent(new ReturnEvent(null, state, user));
        }
    }
}
