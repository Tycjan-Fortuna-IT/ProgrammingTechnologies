using Service.API;

namespace Service.Implementation;

internal class EventDTO : IEventDTO
{
    public int Id { get; set; }

    public int stateId { get; set; }

    public int userId { get; set; }

    public DateTime occurrenceDate { get; set; }

    public EventDTO(int id, int stateId, int userId, DateTime occurrenceDate)
    {
        this.Id = id;
        this.stateId = stateId;
        this.userId = userId;
        this.occurrenceDate = occurrenceDate;
    }
}
