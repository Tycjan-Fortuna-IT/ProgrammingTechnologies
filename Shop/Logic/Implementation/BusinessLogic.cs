using Shop.Data;

namespace Shop.Logic
{
    public class BusinessLogic : IBusinessLogic
    {
        private IDataRepository Repository;

        public BusinessLogic(IDataRepository Repository) {
            this.Repository = Repository;
        }

        public void Purchase(IUser User, IState State) {
            if (this.Repository.Get<IProduct>(State.Product.Guid) is not null)
                this.Repository.Add<IEvent>(new PurchaseEvent(null, State, User));
        }

        public void Return(IUser User, IState State) {
            if (this.Repository.Get<IProduct>(State.Product.Guid) is not null)
                this.Repository.Add<IEvent>(new ReturnEvent(null, State, User));
        }

        // --- REGISTER ---
        public void RegisterUser(IUser User) {
            this.Repository.Add<IUser>(User);
        }

        public void RegisterProduct(IProduct Product) {
            this.Repository.Add<IProduct>(Product);
        }

        // --- GET ---
        public IUser GetUser(string Guid) {
            return this.Repository.Get<IUser>(Guid);
        }

        public IProduct GetProduct(string Guid) {
            return this.Repository.Get<IProduct>(Guid);
        }

        // --- GET ALL ---
        public Dictionary<string, IUser> GetAllUsers() {
            return this.Repository.GetAll<IUser>();
        }

        public Dictionary<string, IProduct> GetAllProducts() {
            return this.Repository.GetAll<IProduct>();
        }

        // --- GET COUNT ---
        public int GetUsersCount() {
            return this.Repository.GetCount<IUser>();
        }

        public int GetProductsCount() {
            return this.Repository.GetCount<IProduct>();
        }

        // --- UPDATE ---
        public void UpdateUser(string Guid, IUser User) {
            this.Repository.Update<IUser>(Guid, User);
        }

        public void UpdateProduct(string Guid, IProduct Product) {
            this.Repository.Update<IProduct>(Guid, Product);
        }

        // --- DELETE ---
        public void DeleteUser(string Guid) {
            this.Repository.Delete<IUser>(Guid);
        }

        public void DeleteProduct(string Guid) {
            this.Repository.Delete<IProduct>(Guid);
        }

        // --- EVENTS ---
        public IEvent GetLastProductEvent(string Guid) {
            return this.Repository.GetLastProductEvent(Guid);
        }

        public List<IEvent> GetProductEventHistory(string Guid) {
            return this.Repository.GetProductEventHistory(Guid);
        }
    }
}
