using Data.API;

namespace Shop.Test
{
    public interface IGenerator
    {
        void Generate(IDataContext Context);
    }
}
