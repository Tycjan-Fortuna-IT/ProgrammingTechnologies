namespace Shop.Data
{
    public interface IEvent
    {
        string Guid { get; }

        string StateGuid { get; }

        string UserGuid { get; }

        DateTime OccurrenceDate { get; }

        void Action();
    }
}
