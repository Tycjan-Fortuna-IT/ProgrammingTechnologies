﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IProductDTOModel
    {
        int Id { get; set; }

        string Name { get; set; }

        double Price { get; set; }

        int Pegi { get; set; }
    }
}
