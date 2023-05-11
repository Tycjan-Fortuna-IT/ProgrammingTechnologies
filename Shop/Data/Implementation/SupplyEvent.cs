using Data.API;

namespace Data.Implementation
{
    internal class SupplyEvent : IEvent
    {
        public SupplyEvent(string? guid, string stateGuid, string userGuid, int quantity)
        {
            this.guid = guid ?? System.Guid.NewGuid().ToString();
            this.stateGuid = stateGuid;
            this.userGuid = userGuid;
            this.quantity = quantity;
            this.occurrenceDate = DateTime.Now;
        }

        public int id { get; set; }

        public string guid { get; }

        public string stateGuid { get; }

        public string userGuid { get; }

        public DateTime occurrenceDate { get; }

        public int quantity;

        public void Action(IDataRepository dataRepository)
        {
            //IState state = dataRepository.GetState(this.stateGuid);

            //if (quantity <= 0)
            //    throw new Exception("Can not supply with this amount!");

            //state.productQuantity += this.quantity;
        }
    }
}
