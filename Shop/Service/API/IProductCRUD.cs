using Data.API;

namespace Service.API;

public interface IProductCRUD
{
    Task AddProductAsync(int id, string name, double price, int pegi);

    Task<IProductDTO> GetProductAsync(int id);

    Task UpdateProductAsync(int id, string name, double price, int pegi);

    Task DeleteProductAsync(int id);

    Task<Dictionary<int, IProductDTO>> GetAllProductsAsync();

    Task<int> GetProductsCountAsync();
}
