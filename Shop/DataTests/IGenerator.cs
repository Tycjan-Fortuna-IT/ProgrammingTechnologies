using Data.API;

namespace Test
{
    public interface IGenerator
    {
        void Generate(IDataRepository dataRepository);
    }
}
