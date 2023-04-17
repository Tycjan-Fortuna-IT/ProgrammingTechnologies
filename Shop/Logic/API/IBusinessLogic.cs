using Data.API;
using Shop.Logic;

namespace Logic.API
{
    public interface IBusinessLogic
    {
        static IBusinessLogic CreateLogic(IDataRepository dataRepository)
        {
            return new BusinessLogic(dataRepository);
        }

        void Purchase(IState state, IUser user);

        void Return(IState state, IUser user);

        void Supply(IState state, IUser user, int quantity);
    }
}
