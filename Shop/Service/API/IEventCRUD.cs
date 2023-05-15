using Data.API;
using Service.Implementation;

namespace Service.API;

public interface IEventCRUD
{
    static IEventCRUD CreateEventCRUD(IDataRepository? dataRepository)
    {
        return new EventCRUD(dataRepository ?? IDataRepository.CreateDatabase());
    }

    Task AddEventAsync(int id, int stateId, int userId, string type, int quantity = 0);

    Task<IEventDTO> GetEventAsync(int id, string type);

    Task UpdateEventAsync(int id, int stateId, int userId, string type, int? quantity);

    Task DeleteEventAsync(int id);

    Task<Dictionary<int, IEventDTO>> GetAllEventsAsync();

    Task<int> GetEventsCountAsync();
}
