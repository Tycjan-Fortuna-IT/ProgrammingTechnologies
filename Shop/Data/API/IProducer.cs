namespace Shop.Data
{
    public interface IProducer
    {
        string Guid { get; }

        string Name { get; set; }
    }
}
