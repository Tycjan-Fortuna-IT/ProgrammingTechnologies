namespace Shop.Data
{
    public class SellEvent : IEvent
    {
        public SellEvent(string StateGuid, string UserGuid) {
            this.Guid = Guid ?? System.Guid.NewGuid().ToString();
            this.StateGuid = StateGuid;
            this.UserGuid = UserGuid;
            this.OccurrenceDate = DateTime.Now;
        }

        public string Guid { get; }

        public string StateGuid { get; }

        public string UserGuid { get; }

        public DateTime OccurrenceDate { get; }

        public void Action() {
            
        }
    }
}