using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;

namespace Presentation.Model.Implementation
{
    internal class ProductDTOModel : IProductDTOModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Pegi { get; set; }

        public ProductDTOModel(int id, string name, double price, int pegi)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Pegi = pegi;
        }
    }
}
