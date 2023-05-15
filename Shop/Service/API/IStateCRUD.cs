using Data.API;

namespace Service.API;

public interface IStateCRUD
{
    Task AddStateAsync(int id, int productId, int productQuantity);

    Task<IStateDTO> GetStateAsync(int id);

    Task UpdateStateAsync(int id, int productId, int productQuantity);

    Task DeleteStateAsync(int id);

    Task<Dictionary<int, IStateDTO>> GetAllStatesAsync();

    Task<int> GetStatesCountAsync();
}
