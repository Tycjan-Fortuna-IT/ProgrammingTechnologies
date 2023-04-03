namespace Shop.Data
{
    public class Game : IProduct
    {
        public Game(string? Guid, string Name, double Price, int Quantity, DateTime RelaseDate, int PEGI)
        {
            this.Guid = Guid ?? System.Guid.NewGuid().ToString();
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
            this.RelaseDate = RelaseDate;
            this.PEGI = PEGI;
        }

        public string Guid { get; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public DateTime RelaseDate { get; set; }

        public int PEGI { get; set; }
    }
}
