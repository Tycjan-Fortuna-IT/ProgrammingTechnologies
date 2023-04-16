using Data.API;

namespace Data.Implementation
{
    public class State : IState
    {
        public State(string? guid, IProduct product, int productQuantity = 0) 
        {
            this.guid = guid ?? System.Guid.NewGuid().ToString();
            this.product = product;
            this.productQuantity = productQuantity;
        }

        public string guid { get; }

        public IProduct product { get; }

        public int productQuantity { get; set; }
    }
}
