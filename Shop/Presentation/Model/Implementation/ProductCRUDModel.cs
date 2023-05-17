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
    internal class ProductCRUDModel : IProductCRUDModel
    {
        private IDataRepository _repository;

        public ProductCRUDModel(IDataRepository repository)
        {
            this._repository = repository;
        }

        private IProductDTOModel Map(IProduct product)
        {
            return new ProductDTOModel(product.Id, product.Name, product.Price, product.Pegi);
        }

        public async Task AddProductAsync(int id, string name, double price, int pegi)
        {
            await this._repository.AddProductAsync(id, name, price, pegi);
        }

        public async Task<IProductDTOModel> GetProductAsync(int id)
        {
            return this.Map(await this._repository.GetProductAsync(id));
        }

        public async Task UpdateProductAsync(int id, string name, double price, int pegi)
        {
            await this._repository.UpdateProductAsync(id, name, price, pegi);
        }

        public async Task DeleteProductAsync(int id)
        {
            await this._repository.DeleteProductAsync(id);
        }

        public async Task<Dictionary<int, IProductDTOModel>> GetAllProductsAsync()
        {
            Dictionary<int, IProductDTOModel> result = new Dictionary<int, IProductDTOModel>();

            foreach (IProduct product in (await this._repository.GetAllProductsAsync()).Values)
            {
                result.Add(product.Id, this.Map(product));
            }

            return result;
        }

        public async Task<int> GetProductsCountAsync()
        {
            return await this._repository.GetProductsCountAsync();
        }
    }
}
