namespace Shop.Data
{
    public class User : IUser
    {
        public User(string? Guid, string Name, string Surname, string Email,
            double Balance, DateTime DateOfBirth, int PhoneNumber, Dictionary<string, IProduct>? ProductLibrary)
        {
            this.Guid = Guid ?? System.Guid.NewGuid().ToString();
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Balance = Balance;
            this.DateOfBirth = DateOfBirth;
            this.PhoneNumber = PhoneNumber;
            this.ProductLibrary = ProductLibrary ?? new Dictionary<string, IProduct>();
        }

        public string Guid { get; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public double Balance { get; set; } = 0;

        public DateTime DateOfBirth { get; set; }

        public int PhoneNumber { get; set; }

        public Dictionary<string, IProduct> ProductLibrary { get; set; }
    }
}