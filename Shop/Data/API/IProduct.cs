namespace Shop.Data
{
    public interface IProduct : IElement
    {
        string Name { get; set; }

        double Price { get; set; }

        DateTime ReleaseDate { get; set; }
    }
}
