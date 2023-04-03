namespace Shop.Data
{
    public interface IProduct
    {
        string Guid { get; }

        string Name { get; set; }

        double Price { get; set; }

        int Quantity { get; set; }

        DateTime RelaseDate { get; set; }
    }
}
