using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation.Model.Implementation;

namespace Presentation.Model.API;

public interface IProductModelOperation
{
    static IProductModelOperation CreateModelOperation()
    {
        return new ProductModelOperation();
    }

    Task AddAsync(int id, string name, double price, int pegi);

    Task<IProductModel> GetAsync(int id);

    Task UpdateAsync(int id, string name, double price, int pegi);

    Task DeleteAsync(int id);

    Task<Dictionary<int, IProductModel>> GetAllAsync();

    Task<int> GetCountAsync();
}
