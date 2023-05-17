using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.API;
using Presentation.Model.Implementation;

namespace Presentation.Model.API
{
    public interface IUserCRUDModel
    {
        static IUserCRUDModel CreateUserCRUD(IDataRepository? dataRepository)
        {
            return new UserCRUDModel(dataRepository ?? IDataRepository.CreateDatabase());
        }

        Task AddUserAsync(int id, string nickname, string email, double balance, DateTime dateOfBirth);

        Task<IUserDTOModel> GetUserAsync(int id);

        Task UpdateUserAsync(int id, string nickname, string email, double balance, DateTime dateOfBirth);

        Task DeleteUserAsync(int id);

        Task<Dictionary<int, IUserDTOModel>> GetAllUsersAsync();

        Task<int> GetUsersCountAsync();
    }
}
