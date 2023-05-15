namespace Service.API;

public interface IUserCRUD
{
    Task AddUserAsync(int id, string nickname, string email, double balance, DateTime dateOfBirth);

    Task<IUserDTO> GetUserAsync(int id);

    Task UpdateUserAsync(int id, string nickname, string email, double balance, DateTime dateOfBirth);

    Task DeleteUserAsync(int id);

    Task<Dictionary<int, IUserDTO>> GetAllUsersAsync();

    Task<int> GetUsersCountAsync();
}
