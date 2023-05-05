namespace Data.API
{
    public interface IUser
    {
        string guid { get; }

        string nickname { get; set; }

        string email { get; set; }

        double balance { get; set; }

        DateTime dateOfBirth { get; set; }

        Dictionary<string, IProduct> productLibrary { get; set; }
    }
}