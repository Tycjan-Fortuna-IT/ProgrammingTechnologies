namespace Shop.Data
{
    public interface IDataRepository
    {
        void AddUser(IUser user);
        IUser GetUser(string guid);
        void UpdateUser(string guid, IUser user);
        void DeleteUser(string guid);
        Dictionary<string, IUser> GetAllUsers();
        int GetUsersCount();
    }
}
