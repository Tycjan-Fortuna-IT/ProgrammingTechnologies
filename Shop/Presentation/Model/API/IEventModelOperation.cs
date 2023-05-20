using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Presentation.Model.Implementation;

namespace Presentation.Model.API;

public interface IEventModelOperation
{
    static IEventModelOperation CreateModelOperation()
    {
        return new EventModelOperation();
    }

    Task AddAsync(int id, int stateId, int userId, string type, int quantity = 0);

    Task<IEventModel> GetAsync(int id, string type);

    Task UpdateAsync(int id, int stateId, int userId, DateTime occurrenceDate, string type, int? quantity);

    Task DeleteAsync(int id);

    Task<Dictionary<int, IEventModel>> GetAllAsync();

    Task<int> GetCountAsync();
}
