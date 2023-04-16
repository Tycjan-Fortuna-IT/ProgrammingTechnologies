using Data.API;

namespace Data.Implementation
{
    public class PurchaseEvent : IEvent
    {
        public PurchaseEvent(string? guid, IState state, IUser user) 
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
            if (this.user.productLibrary.ContainsKey(this.state.product.guid))
                throw new Exception("You already have this Product!");   

            if (this.state.product is Game)
                if (DateTime.Now.Year - this.user.dateOfBirth.Year < ((Game)this.state.product).pegi)
                    throw new Exception("You are not old enough to purchase this game!");

            if (this.state.productQuantity == 0)
                throw new Exception("Product unavailable, please check later!");

            if (this.user.balance < this.state.product.price)
                throw new Exception("Not enough money to purchase this Product!");

            this.state.productQuantity--;
            this.user.balance -= this.state.product.price;
            this.user.productLibrary.Add(this.state.product.guid, this.state.product);
        }
    }
}