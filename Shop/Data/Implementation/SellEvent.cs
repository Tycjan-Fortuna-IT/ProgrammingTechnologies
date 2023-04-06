namespace Shop.Data
{
    public class SellEvent : IEvent
    {
        public SellEvent(string? Guid, IState State, IUser User) {
            this.Guid = Guid ?? System.Guid.NewGuid().ToString();
            this.State = State;
            this.User = User;
            this.OccurrenceDate = DateTime.Now;

            this.Action();
        }

        public string Guid { get; }

        public IState State { get; }

        public IUser User { get; }

        public DateTime OccurrenceDate { get; }

        public void Action() {
            
        }
    }
}