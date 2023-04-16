using Data.API;
using Data.Implementation;

namespace Test
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void FixedGeneratorTests()
        {
            IDataContext context = new DataContext();

            IGenerator generator = new FixedGenerator();

            generator.Generate(context);

            Assert.AreEqual(10, context.users.Count);
        }

        [TestMethod]
        public void RandomGeneratorTests()
        {
            IDataContext context = new DataContext();

            IGenerator generator = new RandomGenerator();

            generator.Generate(context);

            Assert.ThrowsException<ArgumentException>(() => { RandomGenerator.RandomNumber<int>(-1); });
        }
    }
}
