namespace Shop.Data
{
    public interface IProduct : IElement
    {
        string Name { get; set; }

        double Price { get; set; }

        int Quantity { get; set; }

        DateTime RelaseDate { get; set; }
    }
}
