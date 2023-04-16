namespace Data.API
{
    public interface IProduct
    {
        string guid { get; }

        string name { get; set; }

        double price { get; set; }

        DateTime releaseDate { get; set; }
    }
}
