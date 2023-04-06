namespace Shop.Data
{
    public interface IEvent : IElement
    {
        string StateGuid { get; }

        string UserGuid { get; }

        DateTime OccurrenceDate { get; }

        void Action();
    }
}
