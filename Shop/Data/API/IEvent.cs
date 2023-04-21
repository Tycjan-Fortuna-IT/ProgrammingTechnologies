namespace Data.API
{
    public interface IEvent
    {
        string guid { get; }

        string stateGuid { get; }

        string userGuid { get; }

        DateTime occurrenceDate { get; }

        void Action(IDataRepository dataRepository);
    }
}
