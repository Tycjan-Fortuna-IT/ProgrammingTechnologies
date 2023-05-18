using Data.API;

namespace Data.Implementation;

internal class SupplyEvent : IEvent
{
    public SupplyEvent(int id, int stateId, int userId, DateTime occurrenceDate, int quantity)
    {
        this.Id = id;
        this.stateId = stateId;
        this.userId = userId;
        this.quantity = quantity;
        this.occurrenceDate = occurrenceDate;
    }

    public int Id { get; set; }

    public int stateId { get; set; }

    public int userId { get; set; }

    public DateTime occurrenceDate { get; set; }

    public int quantity { get; set; }

}
