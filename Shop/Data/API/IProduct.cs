namespace Shop.Data
{
    public interface IProduct
    {
        string Guid { get; }

        string Name { get; set; }

        double Price { get; set; }

        int Quantity { get; set; }

        IProducer Producer { get; set; }

        int Genre { get; set; }

        DateTime RelaseDate { get; set; }

        int PEGI { get; set; }

        string GetGenre();
    }
}
