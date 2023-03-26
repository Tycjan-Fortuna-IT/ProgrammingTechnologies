namespace Shop.Data
{
    public class DataRepository : IDataRepository
    {
        public DataRepository(IDataContext context) {
            this.context = context;
        }

        private IDataContext context;

        public void AddUser(IUser User) {
            if (!this.context.Users.ContainsKey(User.Guid)) {
                this.context.Users.Add(User.Guid, User);
            } else {
                throw new Exception("This User already exists!");
            }
        }

        public IUser GetUser(string guid) {
            if (this.context.Users.ContainsKey(guid)) { 
                return this.context.Users[guid]; 
            } else {
                throw new Exception("This User does not exist!");
            }
        }

        public void UpdateUser(string guid, IUser User) {
            if (this.context.Users.ContainsKey(guid))
            {
                this.context.Users[guid] = User;
            } else {
                throw new Exception("This User does not exist!");
            }
        }
        
        public void DeleteUser(string guid) {
            if (this.context.Users.ContainsKey(guid))
            {
                this.context.Users.Remove(guid);
            } else {
                throw new Exception("This User does not exist!");
            }
        }

        public Dictionary<string, IUser> GetAllUsers() {
            return this.context.Users;
        }
        
        public int GetUsersCount() {
            return this.context.Users.Count();
        }
    }
}
