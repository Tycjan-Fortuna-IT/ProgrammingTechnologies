using Data.API;

namespace Data.Implementation
{
    internal class State : IState
    {
        public State(string? guid, string productGuid, int productQuantity = 0) 
        {
            this.guid = guid ?? System.Guid.NewGuid().ToString();
            this.productGuid = productGuid;
            this.productQuantity = productQuantity;
        }

        public int id { get; set; }

        public string guid { get; }

        public string productGuid { get; }

        public int productQuantity { get; set; }
    }
}
