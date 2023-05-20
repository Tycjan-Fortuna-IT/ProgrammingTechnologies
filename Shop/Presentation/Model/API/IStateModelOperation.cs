using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation.Model.Implementation;

namespace Presentation.Model.API;

public interface IStateModelOperation
{
    static IStateModelOperation CreateModelOperation()
    {
        return new StateModelOperation();
    }

    Task AddAsync(int id, int productId, int productQuantity);

    Task<IStateModel> GetAsync(int id);

    Task UpdateAsync(int id, int productId, int productQuantity);

    Task DeleteAsync(int id);

    Task<Dictionary<int, IStateModel>> GetAllAsync();

    Task<int> GetCountAsync();
}
