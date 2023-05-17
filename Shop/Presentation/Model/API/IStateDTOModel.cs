using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IStateDTOModel
    {
        int Id { get; set; }

        int productId { get; set; }

        int productQuantity { get; set; }
    }
}
