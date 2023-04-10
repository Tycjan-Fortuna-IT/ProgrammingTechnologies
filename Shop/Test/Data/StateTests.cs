using Shop.Data;

namespace Shop.Test.Data
{
    [TestClass]
    public class StateTests
    {
        [TestMethod]
        public void StateGettersAndSettersTest()
        {
            IProduct game = new Game(null, "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            IState state = new State(null, (Game)game, 3);

            Assert.IsNotNull(state.Guid);

            Assert.AreEqual(game, state.Product);
            Assert.AreEqual(3, state.ProductQuantity);

            state.ProductQuantity = 7;

            Assert.AreEqual(7, state.ProductQuantity);
        }
    }
}