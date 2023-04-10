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
            if (!this.User.ProductLibrary.ContainsValue(this.State.Product))
                throw new Exception("You do not have this Product!");

            this.State.ProductQuantity++;
            this.User.Balance += this.State.Product.Price;
            foreach (KeyValuePair<string, IProduct> item in this.User.ProductLibrary) 
                if (item.Value == this.State.Product)
                {
                    this.User.ProductLibrary.Remove(item.Key);
                    break;
                }
            
            //this.User.ProductLibrary.Remove(this.State.Product.Guid);
        }
    }
}