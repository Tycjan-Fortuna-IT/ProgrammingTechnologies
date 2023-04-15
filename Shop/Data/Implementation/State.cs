using Data.API;

namespace Data.Implementation
{
    public class State : IState
    {
        public State(string? Guid, IProduct Product, int ProductQuantity = 0) {
            this.Guid = Guid ?? System.Guid.NewGuid().ToString();
            this.Product = Product;
            this.ProductQuantity = ProductQuantity;
        }

        public string Guid { get; }

        public IProduct Product { get; }

        public int ProductQuantity { get; set; }
    }
}
