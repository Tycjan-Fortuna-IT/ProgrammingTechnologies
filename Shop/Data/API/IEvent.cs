namespace Shop.Data
{
    public interface IEvent : IElement
    {
        IState State { get; }

        IUser User { get; }

        DateTime OccurrenceDate { get; }

        void Action();
    }
}
