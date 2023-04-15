using Data.API;
using Data.Implementation;
using Logic.API;

namespace Shop.Logic
{
    public class BusinessLogic : IBusinessLogic
    {
        private IDataRepository Repository;

        public BusinessLogic(IDataRepository Repository)
        {
            this.Repository = Repository;
        }

        public void Purchase(IState State, IUser User)
        {
            if (!this.Repository.CheckIfProductExists(State.Product.Guid))
                throw new Exception("This product is not registered in our system!");

            if (!this.Repository.CheckIfUserExists(User.Guid))
                throw new Exception("This user is not registered in our system!");

            this.Repository.AddEvent(new PurchaseEvent(null, State, User));
        }

        public void Return(IState State, IUser User) 
        {
            if (!this.Repository.CheckIfProductExists(State.Product.Guid))
                throw new Exception("This product is not registered in our system!");

            if (!this.Repository.CheckIfUserExists(User.Guid))
                throw new Exception("This user is not registered in our system!");

            this.Repository.AddEvent(new ReturnEvent(null, State, User));
        }
    }
}
