using Data.API;

namespace Data.Implementation
{
    public class User : IUser
    {
        public User(string? guid, string name, string surname, string email,
            double balance, DateTime dateOfBirth, int phoneNumber, Dictionary<string, IProduct>? productLibrary)
        {
            this.guid = guid ?? System.Guid.NewGuid().ToString();
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.balance = balance;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.productLibrary = productLibrary ?? new Dictionary<string, IProduct>();
        }

        public string guid { get; }

        public string name { get; set; }

        public string surname { get; set; }

        public string email { get; set; }

        public double balance { get; set; } = 0;

        public DateTime dateOfBirth { get; set; }

        public int phoneNumber { get; set; }

        public Dictionary<string, IProduct> productLibrary { get; set; }
    }
}