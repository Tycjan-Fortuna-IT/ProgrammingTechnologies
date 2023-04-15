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
            IProduct game = new Game("22559192-db53-11ed-afa1-0242ac120002", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            IState state = new State("4f0fd49a-db53-11ed-afa1-0242ac120002", game, 2);
            IUser user = new User("5525ef4a-db53-11ed-afa1-0242ac120002", "Eivor", "Raventhrope", "e_raventhrope@gmail.com", 200, new DateTime(1996, 12, 25), 542123567, null);

            IEvent Buy = new PurchaseEvent(null, state, user);

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
            IProduct game1 = new Game("6701b3e8-db53-11ed-afa1-0242ac120002", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            IState state1 = new State("65dfa45e-c21f-4803-93da-9b9e77fc732c", game1, 2);
            IUser user1 = new User("1d77efcec-05e0-47bd-bcd4-d590fa569d0c", "Eivor", "Raventhrope", "e_raventhrope@gmail.com", 200, new DateTime(2015, 12, 25), 542123567, new Dictionary<string, IProduct>() { { "18cfb155-17cf-4522-a53c-e3b0ae18fe37", game1 } });

            IEvent Buy1 = new PurchaseEvent(null, state1, user1);

            Assert.ThrowsException<Exception>(() => Buy1.Action());
            Assert.AreEqual(2, state1.ProductQuantity);
            Assert.AreEqual(200, user1.Balance);
            Assert.IsFalse(user1.ProductLibrary.ContainsValue(game1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PurchaseAgeExceptionTest()
        {
            IProduct game2 = new Game("28e5b5ec-6995-4a76-94fd-8d5ada7eac3b", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            IState state2 = new State("8fac4984-db53-11ed-afa1-0242ac120002", game2, 3);
            IUser user2 = new User("12790880-9130-47b2-adfb-c1df3d17e7a6", "Sigmund", "Ledercestaire", "s_ledercestaire@gmail.com", 100, new DateTime(2016, 10, 3), 543903567, null);

            IEvent Buy2 = new PurchaseEvent(null, state2, user2);

            Assert.ThrowsException<Exception>(() => Buy2.Action());
            Assert.AreEqual(3, state2.ProductQuantity);
            Assert.AreEqual(100, user2.Balance);
            Assert.IsFalse(user2.ProductLibrary.ContainsValue(game2));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PurchaseUnavailabilityExceptionTest()
        {
            IProduct game3 = new Game("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            IState state3 = new State("0e92eb1a-b8d3-4835-b317-6b348ecc633c", game3, 0);
            IUser user3 = new User("5b25789d-422a-4de7-adb3-d18a5143c8c4", "Havi", "Odinson", "h_odinson@asgard.com", 500, new DateTime(1993, 11, 10), 982374901, null);

            IEvent Buy3 = new PurchaseEvent(null, state3, user3);

            Assert.ThrowsException<Exception>(() => Buy3.Action());
            Assert.AreEqual(0, state3.ProductQuantity);
            Assert.AreEqual(500, user3.Balance);
            Assert.IsFalse(user3.ProductLibrary.ContainsValue(game3));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PurchaseBalanceExceptionTest()
        {
            IProduct game4 = new Game("22c2a010-dfe4-4da3-8669-c150d0ad6068", "Cyberpunk 2077", 299.99, new DateTime(2020, 12, 10), 18);
            IState state4 = new State("1b6bd5b9-b628-4149-b182-f9a05d092167", game4, 20);
            IUser user4 = new User("b32d9ea6-6be8-4c74-bd28-e12f196c1acb", "Keanu", "Reeves", "k_reeves@wick.com", 200, new DateTime(1980, 11, 10), 982994901, null);

            IEvent Buy4 = new PurchaseEvent(null, state4, user4);

            Assert.ThrowsException<Exception>(() => Buy4.Action());
            Assert.AreEqual(20, state4.ProductQuantity);
            Assert.AreEqual(200, user4.Balance);
            Assert.IsFalse(user4.ProductLibrary.ContainsValue(game4));

        }

        //[TestMethod]
        //public void ReturnGettersTest() 
        //{
        //IProduct game = new Game("4ca8c94e-65be-44c8-ab0b-cf6fd73ddb57", "The Sims 3", 109.99, new DateTime(2009, 6, 12), 7);
        //IState state = new State("0ecfa654-d8e3-4757-a752-17516bf2cf9b", game, 4);
        //IUser user = new User("02398dfd-d04c-41b7-b71a-fd2ac87a7fc7", "Eivor", "Raventhrope", "e_raventhrope@gmail.com", 100, new DateTime(1996, 12, 25), 542123567, new Dictionary<string, IProduct>() { { "b197a800-f80e-4406-b1ad-5f956cdc1050", game } });

        //IEvent Undo = new ReturnEvent(null, state, user);

        //Assert.IsNotNull(Undo.Guid);
        //Assert.AreEqual(state, Undo.State);
        //Assert.AreEqual(user, Undo.User);
        //Assert.IsNotNull(Undo.OccurrenceDate);
        //Assert.AreEqual(209.99, user.Balance);
        //Assert.AreEqual(5, state.ProductQuantity);
        //Assert.IsFalse(user.ProductLibrary.ContainsValue(game));
        //}

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReturnOwnershipExceptionTest()
        {
            IProduct game1 = new Game(null, "Witcher 3", 129.99, new DateTime(2015, 5, 18), 18);
            IState state1 = new State("2c721af1-d010-48d8-a2d0-8ee3743281fd", game1, 8);
            IUser user1 = new User("7c1b6d7a-7db2-4e32-8835-71e6e1433022", "Ezio", "Auditore", "e_auditore@dafirenze.com", 90, new DateTime(1987, 7, 25), 542177567, null);

            IEvent Undo1 = new ReturnEvent(null, state1, user1);

            Assert.ThrowsException<Exception>(() => Undo1.Action());
            Assert.AreEqual(8, state1.ProductQuantity);
            Assert.AreEqual(90, user1.Balance);
            Assert.IsFalse(user1.ProductLibrary.ContainsValue(game1));
        }
    }
}
