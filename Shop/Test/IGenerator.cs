using Shop.Data;

namespace Shop.Test
{
    public interface IGenerator
    {
        void Generate(IDataContext Context);
    }
}
