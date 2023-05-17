using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.API;
using Presentation.Model.Implementation;

namespace Presentation.Model.API
{
    public interface IStateCRUDModel
    {
        static IStateCRUDModel CreateStateCRUD(IDataRepository? dataRepository)
        {
            return new StateCRUDModel(dataRepository ?? IDataRepository.CreateDatabase());
        }

        Task AddStateAsync(int id, int productId, int productQuantity);

        Task<IStateDTOModel> GetStateAsync(int id);

        Task UpdateStateAsync(int id, int productId, int productQuantity);

        Task DeleteStateAsync(int id);

        Task<Dictionary<int, IStateDTOModel>> GetAllStatesAsync();

        Task<int> GetStatesCountAsync();
    }
}
