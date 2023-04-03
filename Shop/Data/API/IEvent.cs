namespace Shop.Data
{
    public interface IEvent
    {
        string StateGuid { get; }
        string UserGuid { get; }
    }
}
