//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Data.API;
//using Service.API;
//using Presentation.Model.API;

//namespace Presentation.Model.Implementation
//{
//    internal class EventCRUDModel : IEventCRUDModel
//    {
//        private IDataRepository _repository;

//        public EventCRUDModel(IDataRepository repository)
//        {
//            this._repository = repository;
//        }

//        public IEventDTOModel Map(IEvent even)
//        {
//            return new EventDTOModel(even.Id, even.stateId, even.userId, even.occurrenceDate);
//        }

//        public async Task AddEventAsync(int id, int stateId, int userId, string type, int quantity = 0)
//        {
//            await this._repository.AddEventAsync(id, stateId, userId, type, quantity);
//        }

//        public async Task<IEventDTOModel> GetEventAsync(int id, string type)
//        {
//            return this.Map(await this._repository.GetEventAsync(id, type));
//        }

//        public async Task UpdateEventAsync(int id, int stateId, int userId, string type, int? quantity)
//        {
//            await this._repository.UpdateEventAsync(id, stateId, userId, type, quantity);
//        }

//        public async Task DeleteEventAsync(int id)
//        {
//            await this._repository.DeleteEventAsync(id);
//        }

//        public async Task<Dictionary<int, IEventDTOModel>> GetAllEventsAsync()
//        {
//            Dictionary<int, IEventDTOModel> result = new Dictionary<int, IEventDTOModel>();

//            foreach (IEvent even in (await this._repository.GetAllEventsAsync()).Values)
//            {
//                result.Add(even.Id, this.Map(even));
//            }

//            return result;
//        }

//        public async Task<int> GetEventsCountAsync()
//        {
//            return await this._repository.GetEventsCountAsync();
//        }
//    }
//}
