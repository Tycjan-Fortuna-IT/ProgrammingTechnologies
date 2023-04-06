using Shop.Data;

namespace Shop.Logic
{
    interface IBusinessLogic
    {
        void Purchase(IUser User, IState State);

        void Return(IUser User, IState State);

        IUser GetUser(string Guid);

        IProduct GetProduct(string Guid);

        Dictionary<string, IUser> GetAllUsers();

        Dictionary<string, IProduct> GetAllProducts();

        int GetUsersCount();

        int GetProductsCount();

        void UpdateUser(string Guid, IUser User);

        void UpdateProduct(string Guid, IProduct Product);

        void DeleteUser(string Guid);

        void DeleteProduct(string Guid);

        IEvent GetLastProductEvent(string Guid);

        List<IEvent> GetProductEventHistory(string Guid);
    }
}
