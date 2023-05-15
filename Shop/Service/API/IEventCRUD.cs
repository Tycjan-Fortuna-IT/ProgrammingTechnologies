using Data.API;

namespace Service.API;

public interface IEventCRUD
{
    Task AddEventAsync(int id, int stateId, int userId, string type, int quantity = 0);

    Task<IEventDTO> GetEventAsync(int id, string type);

    Task UpdateEventAsync(int id, int stateId, int userId, string type, int? quantity);

    Task DeleteEventAsync(int id);

    Task<Dictionary<int, IEventDTO>> GetAllEventsAsync();

    Task<int> GetEventsCountAsync();
}
