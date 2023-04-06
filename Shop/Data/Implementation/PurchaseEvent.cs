namespace Shop.Data
{
    public class PurchaseEvent : IEvent
    {
        public PurchaseEvent(string? Guid, IState State, IUser User) {
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
            if (this.User.ProductLibrary.ContainsKey(this.State.Product.Guid))
                throw new Exception("You already have this Product!");   

            if (this.State.Product is Game)
                if (DateTime.Now.Year - this.User.DateOfBirth.Year > ((Game)this.State.Product).PEGI)
                    throw new Exception("You are not old enough to purchase this game!");

            if (this.State.ProductQuantity == 0)
                throw new Exception("Product unavailable, please check later!");

            if (this.User.Balance < this.State.Product.Price)
                throw new Exception("Not enough money to purchase this Product!");

            this.State.ProductQuantity--;
            this.User.Balance -= this.State.Product.Price;
            this.User.ProductLibrary.Add(this.State.Product.Guid, this.State.Product);
        }
    }
}