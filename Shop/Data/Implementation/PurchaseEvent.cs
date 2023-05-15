using Data.API;

namespace Data.Implementation;

internal class PurchaseEvent : IEvent
{
    public PurchaseEvent(int id, int stateId, int userId, DateTime occurrenceDate) 
    {
        this.Id = id;
        this.stateId = stateId;
        this.userId = userId;
        this.occurrenceDate = occurrenceDate;
    }

    public int Id { get; set; }

    public int stateId { get; set; }

    public int userId { get; set; }

    public DateTime occurrenceDate { get; set; }
}
