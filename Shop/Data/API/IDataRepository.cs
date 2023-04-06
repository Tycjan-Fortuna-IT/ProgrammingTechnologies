namespace Shop.Data
{
    public interface IDataRepository
    {
        void Add<T>(T element) where T : IElement;
        T Get<T>(string Guid) where T : IElement;
        void Update<T>(string Guid, T element) where T : IElement;
        void Delete<T>(string Guid) where T : IElement;
        Dictionary<string, T> GetAll<T>() where T : IElement;
        int GetCount<T>() where T : IElement;
    }
}
