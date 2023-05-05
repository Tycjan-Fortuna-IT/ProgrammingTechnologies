using Data.API;

namespace Data.Implementation
{
    internal class User : IUser
    {
        public User(string? guid, string nickname, string email, double balance, DateTime dateOfBirth, 
            Dictionary<string, IProduct>? productLibrary = null)
        {
            this.guid = guid ?? System.Guid.NewGuid().ToString();
            this.nickname = nickname;
            this.email = email;
            this.balance = balance;
            this.dateOfBirth = dateOfBirth;
            this.productLibrary = productLibrary ?? new Dictionary<string, IProduct>();
        }

        public string guid { get; }

        public string nickname { get; set; }

        public string email { get; set; }

        public double balance { get; set; } = 0;

        public DateTime dateOfBirth { get; set; }

        public Dictionary<string, IProduct> productLibrary { get; set; }
    }
}