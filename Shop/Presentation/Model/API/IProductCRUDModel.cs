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
//    public interface IProductCRUDModel
//    {
//        static IProductCRUDModel CreateProductCRUD(IDataRepository? dataRepository)
//        {
//            return new ProductCRUDModel(dataRepository ?? IDataRepository.CreateDatabase());
//        }

//        Task AddProductAsync(int id, string name, double price, int pegi);

//        Task<IProductDTOModel> GetProductAsync(int id);

//        Task UpdateProductAsync(int id, string name, double price, int pegi);

//        Task DeleteProductAsync(int id);

//        Task<Dictionary<int, IProductDTOModel>> GetAllProductsAsync();

//        Task<int> GetProductsCountAsync();
//    }
//}
