using Shop.Data;

namespace Shop.Test.Data
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GameGettersAndSettersTest() 
        {
            Game game = new Game(null, "Witcher 3", 129.99, new DateTime(2015, 5, 18), 18);

            Assert.IsNotNull(game.Guid);

            Assert.AreEqual("Witcher 3", game.Name);
            Assert.AreEqual(129.99, game.Price);
            Assert.AreEqual(new DateTime(2015, 5, 18), game.ReleaseDate);
            Assert.AreEqual(18, game.PEGI);

            game.Name = "SimCity 3000";
            game.Price = 79.99;
            game.ReleaseDate = new DateTime(1999, 1, 31);
            game.PEGI = 3;

            Assert.AreEqual("SimCity 3000", game.Name);
            Assert.AreEqual(79.99, game.Price);
            Assert.AreEqual(new DateTime(1999, 1, 31), game.ReleaseDate);
            Assert.AreEqual(3, game.PEGI);
        }
    }
}
