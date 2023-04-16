using Data.API;

namespace Data.Implementation
{
    public class ReturnEvent : IEvent
    {
        public ReturnEvent(string? guid, IState state, IUser user)
        {
            this.guid = guid ?? System.Guid.NewGuid().ToString();
            this.state = state;
            this.user = user;
            this.occurrenceDate = DateTime.Now;

            this.Action();
        }

        public string guid { get; }

        public IState state { get; }

        public IUser user { get; }

        public DateTime occurrenceDate { get; }

        public void Action()
        {
            if (!this.user.productLibrary.ContainsKey(this.state.product.guid))
                throw new Exception("You do not have this Product!");

            this.state.productQuantity++;
            this.user.balance += this.state.product.price;
            this.user.productLibrary.Remove(this.state.product.guid);
        }
    }
}