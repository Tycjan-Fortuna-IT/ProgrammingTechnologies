using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IUserDTOModel
    {
        int Id { get; set; }

        string Nickname { get; set; }

        string Email { get; set; }

        double Balance { get; set; }

        DateTime DateOfBirth { get; set; }
    }
}
