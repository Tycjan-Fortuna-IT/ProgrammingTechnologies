using Data.API;

namespace Data.Implementation
{
    public class SupplyEvent : IEvent
    {
        public SupplyEvent(string? guid, IState state, IUser user, int quantity)
        {
            this.guid = guid ?? System.Guid.NewGuid().ToString();
            this.state = state;
            this.user = user;
            this.quantity = quantity;
            this.occurrenceDate = DateTime.Now;

            this.Action();
        }

        public string guid { get; }

        public IState state { get; }

        public IUser user { get; }

        public DateTime occurrenceDate { get; }

        public int quantity;

        public void Action()
        {
            if (quantity <= 0)
                throw new Exception("Can not supply with this amount!");

            this.state.productQuantity += this.quantity;
        }
    }
}
