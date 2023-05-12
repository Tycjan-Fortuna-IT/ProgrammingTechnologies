//using Data.API;

//namespace Test
//{
//    [TestClass]
//    public class GeneratorTests
//    {
//        [TestMethod]
//        public void FixedGeneratorTests()
//        {
//            IDataRepository dataRepository = IDataRepository.CreateDatabase();

//            IGenerator generator = new FixedGenerator();

//            generator.Generate(dataRepository);

//            Assert.AreEqual(10, dataRepository.GetUserCount());
//        }

//        [TestMethod]
//        public void RandomGeneratorTests()
//        {
//            IDataRepository dataRepository = IDataRepository.CreateDatabase();

//            IGenerator generator = new RandomGenerator();

//            generator.Generate(dataRepository);

//            Assert.ThrowsException<ArgumentException>(() => { RandomGenerator.RandomNumber<int>(-1); });
//        }
//    }
//}
