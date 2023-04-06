namespace Shop.Data
{
    public interface IUser : IElement
    {
        string Name { get; set; }

        string Surname { get; set; }

        string Email { get; set; }

        double Balance { get; set; }

        DateTime DateOfBirth { get; set; }

        int PhoneNumber { get; set; }
    }
}