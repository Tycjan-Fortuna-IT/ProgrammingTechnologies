namespace Shop.Data
{
    public class State : IState
    {
        public State(string? Guid, string ProductGuid, int ProductQuantity = 0) {
            this.Guid = Guid ?? System.Guid.NewGuid().ToString();
            this.ProductGuid = ProductGuid;
            this.ProductQuantity = ProductQuantity;
        }

        public string Guid { get; }

        public string ProductGuid { get; }

        public int ProductQuantity { get; set; }
    }
}
