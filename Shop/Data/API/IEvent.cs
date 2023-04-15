namespace Data.API
{
    public interface IEvent
    {
        string Guid { get; }

        IState State { get; }

        IUser User { get; }

        DateTime OccurrenceDate { get; }

        void Action();
    }
}
