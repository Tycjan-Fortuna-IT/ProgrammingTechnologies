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

        void Purchase(string stateGuid, string userGuid);

        void Return(string stateGuid, string userGuid);

        void Supply(string stateGuid, string userGuid, int quantity);
    }
}
