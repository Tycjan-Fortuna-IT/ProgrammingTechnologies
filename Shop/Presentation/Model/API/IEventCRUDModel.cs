//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Data.API;
//using Service.API;
//using Presentation.Model.Implementation;

//namespace Presentation.Model.API
//{
//    public interface IEventCRUDModel
//    {
//        static IEventCRUDModel CreateEventCRUD(IDataRepository? dataRepository)
//        {
//            return new EventCRUDModel(dataRepository ?? IDataRepository.CreateDatabase());
//        }

//        Task AddEventAsync(int id, int stateId, int userId, string type, int quantity = 0);

//        Task<IEventDTOModel> GetEventAsync(int id, string type);

//        Task UpdateEventAsync(int id, int stateId, int userId, string type, int? quantity);

//        Task DeleteEventAsync(int id);

//        Task<Dictionary<int, IEventDTOModel>> GetAllEventsAsync();

//        Task<int> GetEventsCountAsync();
//    }
//}
