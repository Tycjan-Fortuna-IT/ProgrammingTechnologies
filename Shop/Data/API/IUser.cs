namespace Data.API
{
    public interface IUser
    {
        string guid { get; }

        string name { get; set; }

        string surname { get; set; }

        string email { get; set; }

        double balance { get; set; }

        DateTime dateOfBirth { get; set; }

        int phoneNumber { get; set; }

        Dictionary<string, IProduct> productLibrary { get; set; }
    }
}