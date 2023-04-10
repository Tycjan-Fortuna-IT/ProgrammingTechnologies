using Shop.Data;
using System.Runtime.Intrinsics.X86;

namespace Shop.Test.Data
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void PurchaseGettersTest()
        {
            Game game = new Game("1", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            IState state = new State("1", game, 2);
            IUser user = new User("1", "Eivor", "Raventhrope", "e_raventhrope@gmail.com", 200, new DateTime(1996, 12, 25), 542123567, null);

            PurchaseEvent Buy = new PurchaseEvent(null, state, user);

            Assert.IsNotNull(Buy.Guid);
            Assert.AreEqual(state, Buy.State);
            Assert.AreEqual(user, Buy.User);
            Assert.IsNotNull(Buy.OccurrenceDate);
            Assert.AreEqual(138.01, user.Balance);
            Assert.AreEqual(1, state.ProductQuantity);
            Assert.IsTrue(user.ProductLibrary.ContainsValue(game));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))] 
        public void PurchaseAlreadyPurchasedExceptionTest()
        {
            Game game1 = new Game("1", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            IState state1 = new State("1", game1, 2);
            IUser user1 = new User("1", "Eivor", "Raventhrope", "e_raventhrope@gmail.com", 200, new DateTime(2015, 12, 25), 542123567, new Dictionary<string, IProduct>() { { "1", game1 } });

            PurchaseEvent Buy1 = new PurchaseEvent(null, state1, user1);

            Assert.ThrowsException<Exception>(() => Buy1.Action());
            Assert.AreEqual(2, state1.ProductQuantity);
            Assert.AreEqual(200, user1.Balance);
            Assert.IsFalse(user1.ProductLibrary.ContainsValue(game1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PurchaseAgeExceptionTest()
        {
            Game game2 = new Game("1", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            IState state2 = new State("1", game2, 3);
            IUser user2 = new User("2", "Sigmund", "Ledercestaire", "s_ledercestaire@gmail.com", 100, new DateTime(2016, 10, 3), 543903567, null);

            PurchaseEvent Buy2 = new PurchaseEvent(null, state2, user2);

            Assert.ThrowsException<Exception>(() => Buy2.Action());
            Assert.AreEqual(3, state2.ProductQuantity);
            Assert.AreEqual(100, user2.Balance);
            Assert.IsFalse(user2.ProductLibrary.ContainsValue(game2));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PurchaseUnavailabilityExceptionTest()
        {
            Game game3 = new Game("1", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            IState state3 = new State("3", game3, 0);
            IUser user3 = new User("3", "Havi", "Odinson", "h_odinson@asgard.com", 500, new DateTime(1993, 11, 10), 982374901, null);

            PurchaseEvent Buy3 = new PurchaseEvent(null, state3, user3);

            Assert.ThrowsException<Exception>(() => Buy3.Action());
            Assert.AreEqual(0, state3.ProductQuantity);
            Assert.AreEqual(500, user3.Balance);
            Assert.IsFalse(user3.ProductLibrary.ContainsValue(game3));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PurchaseBalanceExceptionTest()
        {
            Game game4 = new Game("1", "Cyberpunk 2077", 299.99, new DateTime(2020, 12, 10), 18);
            IState state4 = new State("4", game4, 20);
            IUser user4 = new User("4", "Keanu", "Reeves", "k_reeves@wick.com", 200, new DateTime(1980, 11, 10), 982994901, null);

            PurchaseEvent Buy4 = new PurchaseEvent(null, state4, user4);

            Assert.ThrowsException<Exception>(() => Buy4.Action());
            Assert.AreEqual(20, state4.ProductQuantity);
            Assert.AreEqual(200, user4.Balance);
            Assert.IsFalse(user4.ProductLibrary.ContainsValue(game4));

        }

        [TestMethod]
        public void ReturnGettersTest() 
        {
            Game game = new Game("2", "The Sims 3", 109.99, new DateTime(2009, 6, 12), 7);
            IState state = new State("1", game, 4);
            IUser user = new User("5", "Eivor", "Raventhrope", "e_raventhrope@gmail.com", 100, new DateTime(1996, 12, 25), 542123567, new Dictionary<string, IProduct>() { { "1", game } });

            ReturnEvent Undo = new ReturnEvent(null, state, user);

            Assert.IsNotNull(Undo.Guid);
            Assert.AreEqual(state, Undo.State);
            Assert.AreEqual(user, Undo.User);
            Assert.IsNotNull(Undo.OccurrenceDate);
            Assert.AreEqual(209.99, user.Balance);
            Assert.AreEqual(5, state.ProductQuantity);
            Assert.IsFalse(user.ProductLibrary.ContainsValue(game));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReturnOwnershipExceptionTest()
        {
            Game game1 = new Game(null, "Witcher 3", 129.99, new DateTime(2015, 5, 18), 18);
            IState state1 = new State("1", game1, 8);
            IUser user1 = new User("5", "Ezio", "Auditore", "e_auditore@dafirenze.com", 90, new DateTime(1987, 7, 25), 542177567, null);

            ReturnEvent Undo1 = new ReturnEvent(null, state1, user1);

            Assert.ThrowsException<Exception>(() => Undo1.Action());
            Assert.AreEqual(8, state1.ProductQuantity);
            Assert.AreEqual(90, user1.Balance);
            Assert.IsFalse(user1.ProductLibrary.ContainsValue(game1));
        }
    }
}
