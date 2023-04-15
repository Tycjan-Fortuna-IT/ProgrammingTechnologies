using Data.API;
using Shop.Logic;

namespace Logic.API
{
    public interface IBusinessLogic
    {
        static IBusinessLogic CreateLogic(IDataRepository DataRepository)
        {
            return new BusinessLogic(DataRepository);
        }

        void Purchase(IState State, IUser User);

        void Return(IState State, IUser User);
    }
}
