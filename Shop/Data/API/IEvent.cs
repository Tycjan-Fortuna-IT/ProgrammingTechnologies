namespace Data.API
{
    public interface IEvent
    {
        string guid { get; }

        IState state { get; }

        IUser user { get; }

        DateTime occurrenceDate { get; }

        void Action();
    }
}
