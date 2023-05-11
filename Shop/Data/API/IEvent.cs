namespace Data.API
{
    public interface IEvent
    {
        int id { get; set; }

        string guid { get; }

        string stateGuid { get; }

        string userGuid { get; }

        DateTime occurrenceDate { get; }

        void Action(IDataRepository dataRepository);
    }
}
