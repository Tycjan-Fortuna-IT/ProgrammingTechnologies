using Service.API;

namespace PresentationTests;

internal class FakeProduct : IProductDTO
{
    public FakeProduct(int id, string name, double price, int pegi)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.Pegi = pegi;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public int Pegi { get; set; }
}
