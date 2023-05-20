namespace Data.API;

public interface IEvent
{
    int Id { get; set; }

    int stateId { get; set; }

    int userId { get; set; }

    //string Type { get; set; }

    DateTime occurrenceDate { get; set; }
}
