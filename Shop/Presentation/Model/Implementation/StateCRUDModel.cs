using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.API;
using Presentation.Model.API;

namespace Presentation.Model.Implementation
{
    internal class StateCRUDModel : IStateCRUDModel
    {
        private IDataRepository _repository;

        public StateCRUDModel(IDataRepository repository)
        {
            this._repository = repository;
        }

        private IStateDTOModel Map(IState state)
        {
            return new StateDTOModel(state.Id, state.productId, state.productQuantity);
        }

        public async Task AddStateAsync(int id, int productId, int productQuantity)
        {
            await _repository.AddStateAsync(id, productId, productQuantity);
        }

        public async Task<IStateDTOModel> GetStateAsync(int id)
        {
            return this.Map(await this._repository.GetStateAsync(id));
        }

        public async Task UpdateStateAsync(int id, int productId, int productQuantity)
        {
            await this._repository.UpdateStateAsync(id, productId, productQuantity);
        }

        public async Task DeleteStateAsync(int id)
        {
            await this._repository.DeleteStateAsync(id);
        }

        public async Task<Dictionary<int, IStateDTOModel>> GetAllStatesAsync()
        {
            Dictionary<int, IStateDTOModel> result = new Dictionary<int, IStateDTOModel>();

            foreach (IState state in (await this._repository.GetAllStatesAsync()).Values)
            {
                result.Add(state.Id, this.Map(state));
            }

            return result;
        }

        public async Task<int> GetStatesCountAsync()
        {
            return await this._repository.GetStatesCountAsync();
        }
    }
}
