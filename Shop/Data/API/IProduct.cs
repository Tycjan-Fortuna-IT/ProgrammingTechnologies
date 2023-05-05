namespace Data.API
{
    public interface IProduct
    {
        string guid { get; }

        string name { get; set; }

        double price { get; set; }

        int pegi { get; set; }
    }
}
