namespace Shop.Data
{
    public class DataRepository : IDataRepository
    {
        public DataRepository(IDataContext context) {
            this.context = context;
        }

        private IDataContext context;

        public void Add<T>(T element) {
            // if (!this.context.Elements[typeof(T)].ContainsKey(User.Guid)) {

            // }
        }

        public T Get<T>(string Guid) {

        }

        public void Update<T>(string Guid, T element) {

        }

        public void DeleteUser<T>(string Guid) {

        }

        public Dictionary<string, T> GetAll<T>() {

        }

        public int GetCount<T>() {

        }

        // public void AddUser(IUser User) {
        //     if (!this.context.Users.ContainsKey(User.Guid)) {
        //         this.context.Users.Add(User.Guid, User);
        //     } else {
        //         throw new Exception("This User already exists!");
        //     }
        // }

        // public IUser GetUser(string Guid) {
        //     if (this.context.Users.ContainsKey(Guid)) { 
        //         return this.context.Users[Guid]; 
        //     } else {
        //         throw new Exception("This User does not exist!");
        //     }
        // }

        // public void UpdateUser(string Guid, IUser User) {
        //     if (this.context.Users.ContainsKey(Guid))
        //     {
        //         this.context.Users[Guid] = User;
        //     } else {
        //         throw new Exception("This User does not exist!");
        //     }
        // }
        
        // public void DeleteUser(string Guid) {
        //     if (this.context.Users.ContainsKey(Guid))
        //     {
        //         this.context.Users.Remove(Guid);
        //     } else {
        //         throw new Exception("This User does not exist!");
        //     }
        // }

        // public Dictionary<string, IUser> GetAllUsers() {
        //     return this.context.Users;
        // }
        
        // public int GetUsersCount() {
        //     return this.context.Users.Count();
        // }

        // --------------------------------------------------------------------
    
    
    }
}
