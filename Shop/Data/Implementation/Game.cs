namespace Shop.Data
{
    public class Game : IProduct
    {
        public Game(string? Guid, string Name, double Price, DateTime ReleaseDate, int PEGI)
        {
            this.Guid = Guid ?? System.Guid.NewGuid().ToString();
            this.Name = Name;
            this.Price = Price;
            this.ReleaseDate = ReleaseDate;
            this.PEGI = PEGI;
        }

        public string Guid { get; }

        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int PEGI { get; set; }
    }
}
