namespace Shop.Data
{
    public class Studio : IProducer
    {
        public Studio(string? Guid, string Name) {
            this.Guid = Guid ?? System.Guid.NewGuid().ToString();
            this.Name = Name;
        }
        public string Guid { get; }

        public string Name { get; set; }
    }
}
