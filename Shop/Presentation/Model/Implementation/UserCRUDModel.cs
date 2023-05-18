//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Data.API;
//using Service.API;
//using Presentation.Model.API;

//namespace Presentation.Model.Implementation
//{
//    internal class UserCRUDModel : IUserCRUDModel
//    {
//        private IDataRepository _repository;

//        public UserCRUDModel(IDataRepository repository)
//        {
//            this._repository = repository;
//        }

//        private IUserDTOModel Map(IUser user)
//        {
//            return new UserDTOModel(user.Id, user.Nickname, user.Email, user.Balance, user.DateOfBirth);
//        }

//        public async Task AddUserAsync(int id, string nickname, string email, double balance, DateTime dateOfBirth)
//        {
//            await this._repository.AddUserAsync(id, nickname, email, balance, dateOfBirth);
//        }

//        public async Task<IUserDTOModel> GetUserAsync(int id)
//        {
//            return this.Map(await this._repository.GetUserAsync(id));
//        }

//        public async Task UpdateUserAsync(int id, string nickname, string email, double balance, DateTime dateOfBirth)
//        {
//            await this._repository.UpdateUserAsync(id, nickname, email, balance, dateOfBirth);
//        }

//        public async Task DeleteUserAsync(int id)
//        {
//            await this._repository.DeleteUserAsync(id);
//        }

//        public async Task<Dictionary<int, IUserDTOModel>> GetAllUsersAsync()
//        {
//            Dictionary<int, IUserDTOModel> result = new Dictionary<int, IUserDTOModel>();

//            foreach (IUser user in (await this._repository.GetAllUsersAsync()).Values)
//            {
//                result.Add(user.Id, this.Map(user));
//            }

//            return result;
//        }

//        public async Task<int> GetUsersCountAsync()
//        {
//            return await this._repository.GetUsersCountAsync();
//        }
//    }
//}
