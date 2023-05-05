using Data.API;

namespace Data.Implementation
{
    internal class Game : IProduct
    {
        public Game(string? guid, string name, double price, int pegi)
        {
            this.guid = guid ?? System.Guid.NewGuid().ToString();
            this.name = name;
            this.price = price;
            this.pegi = pegi;
        }

        public string guid { get; }

        public string name { get; set; }

        public double price { get; set; }

        public int pegi { get; set; }
    }
}
