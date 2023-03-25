namespace Shop.Data
{
    public class User : IUser
    {
        public User(string? Guid, string Name, string Surname, string Email,
            double Balance, DateTime DateOfBirth, int PhoneNumber)
        {
            this.Guid = Guid ?? System.Guid.NewGuid().ToString();
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Balance = Balance;
            this.DateOfBirth = DateOfBirth;
            this.PhoneNumber = PhoneNumber;
        }

        public string Guid { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public double Balance { get; set; } = 0;

        public DateTime DateOfBirth { get; set; }

        public int PhoneNumber { get; set; }
    }
}