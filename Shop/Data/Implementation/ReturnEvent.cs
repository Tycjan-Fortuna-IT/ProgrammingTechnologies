namespace Shop.Data
{
    public class ReturnEvent : IEvent
    {
        public ReturnEvent(string? Guid, IState State, IUser User) {
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

        public void Action()
        {
            if (!this.User.ProductLibrary.ContainsKey(this.State.Product.Guid))
                throw new Exception("You dont have this Product!");

            this.State.ProductQuantity++;
            this.User.Balance += this.State.Product.Price;
            this.User.ProductLibrary.Remove(this.State.Product.Guid);
        }
    }
}