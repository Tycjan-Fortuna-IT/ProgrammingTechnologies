using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;

namespace Presentation.Model.Implementation
{
    internal class StateDTOModel : IStateDTOModel
    {
        public int Id { get; set; }

        public int productId { get; set; }

        public int productQuantity { get; set; }

        public StateDTOModel(int id, int productId, int productQuantity)
        {
            this.Id = id;
            this.productId = productId;
            this.productQuantity = productQuantity;
        }
    }
}
