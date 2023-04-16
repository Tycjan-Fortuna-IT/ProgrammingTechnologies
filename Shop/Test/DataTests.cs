using Data.API;
using Data.Implementation;

namespace Test
{
    [TestClass]
    public class DataTests
    {
        [TestMethod]
        public void UserTests()
        {
            IUser user = new User("348e7dd8-c30f-4f02-8215-4e713c58aa51", "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2015, 12, 25), 542123567, null);

            Assert.AreEqual("348e7dd8-c30f-4f02-8215-4e713c58aa51", user.guid);
            Assert.AreEqual("Michal", user.name);
            Assert.AreEqual("Gapcio", user.surname);
            Assert.AreEqual("m_gapcio@gmail.com", user.email);
            Assert.AreEqual(200, user.balance);
            Assert.AreEqual(new DateTime(2015, 12, 25), user.dateOfBirth);
            Assert.AreEqual(542123567, user.phoneNumber);
            Assert.IsNotNull(user.productLibrary);

            user.name = "Antek";
            user.surname = "Pcimowski";
            user.email = "a_pcimowski@gmail.com";
            user.balance = 850;
            user.dateOfBirth = new DateTime(2015, 12, 26);
            user.phoneNumber = 495039281;
            Game game = new Game(null, "Witcher 3", 129.99, new DateTime(2015, 5, 18), 18);
            Dictionary<string, IProduct> newProductLibrary = new Dictionary<string, IProduct>() { 
                { "0a81eb06-db53-11ed-afa1-0242ac120002", game } 
            };
            user.productLibrary = newProductLibrary;

            Assert.AreEqual("Antek", user.name);
            Assert.AreEqual("Pcimowski", user.surname);
            Assert.AreEqual("a_pcimowski@gmail.com", user.email);
            Assert.AreEqual(850, user.balance);
            Assert.AreEqual(new DateTime(2015, 12, 26), user.dateOfBirth);
            Assert.AreEqual(495039281, user.phoneNumber);
            Assert.AreEqual(game, user.productLibrary["0a81eb06-db53-11ed-afa1-0242ac120002"]);

            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());

            database.AddUser(user);
            Assert.ThrowsException<Exception>(() => { database.AddUser(user); });

            Assert.IsTrue(database.CheckIfUserExists(user.guid));
            Assert.IsFalse(database.CheckIfUserExists(System.Guid.NewGuid().ToString()));
            Assert.AreEqual(1, database.GetUserCount());
            Assert.IsTrue(database.GetAllUsers().Contains(user));

            user.name = "Test";

            database.UpdateUser(user);

            IUser user2 = new User("NOGUID", "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2015, 12, 25), 542123567, null);

            Assert.ThrowsException<Exception>(() => { database.UpdateUser(user2); });
            Assert.AreEqual(database.GetUser(user.guid).name, user.name);
            Assert.ThrowsException<Exception>(() => { database.GetUser("NOGUID"); });

            database.DeleteUser(user.guid);
            Assert.ThrowsException<Exception>(() => { database.DeleteUser("NOGUID"); });
            Assert.AreEqual(0, database.GetUserCount());
            Assert.IsFalse(database.GetAllUsers().Contains(user));
        }

        [TestMethod]
        public void ProductTests()
        {
            IProduct game = new Game("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);

            Assert.AreEqual("d3daae3a-a914-4d37-839a-b26c6e634652", game.guid);
            Assert.AreEqual("Assassin's Creed Valhalla", game.name);
            Assert.AreEqual(239.99, game.price);
            Assert.AreEqual(new DateTime(2020, 11, 10), game.releaseDate);
            Assert.AreEqual(18, ((Game)game).pegi);

            game.name = "SimCity 3000";
            game.price = 79.99;
            game.releaseDate = new DateTime(1999, 1, 31);
            ((Game)game).pegi = 3;

            Assert.AreEqual("SimCity 3000", game.name);
            Assert.AreEqual(79.99, game.price);
            Assert.AreEqual(new DateTime(1999, 1, 31), game.releaseDate);
            Assert.AreEqual(3, ((Game)game).pegi);

            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());

            database.AddProduct(game);
            Assert.ThrowsException<Exception>(() => { database.AddProduct(game); });

            Assert.IsTrue(database.CheckIfProductExists(game.guid));
            Assert.IsFalse(database.CheckIfProductExists(System.Guid.NewGuid().ToString()));
            Assert.AreEqual(1, database.GetProductCount());
            Assert.IsTrue(database.GetAllProducts().Contains(game));

            game.name = "Test";

            database.UpdateProduct(game);
            IProduct game1 = new Game("NOGUID", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            
            Assert.ThrowsException<Exception>(() => { database.UpdateProduct(game1); });
            Assert.AreEqual(database.GetProduct(game.guid).name, game.name);
            Assert.ThrowsException<Exception>(() => { database.GetProduct("NOGUID"); });

            database.DeleteProduct(game.guid);

            Assert.ThrowsException<Exception>(() => { database.DeleteProduct("NOGUID"); });
            Assert.AreEqual(0, database.GetProductCount());
            Assert.IsFalse(database.GetAllProducts().Contains(game));
        }

        [TestMethod]
        public void StateTests()
        {
            IProduct game = new Game("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            IState state = new State("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", game, 10);

            Assert.AreEqual("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", state.guid);
            Assert.AreSame(game, state.product);
            Assert.AreEqual(10, state.productQuantity);

            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());

            database.AddProduct(game);
            database.AddState(state);
            Assert.ThrowsException<Exception>(() => { database.AddState(state); });

            Assert.AreSame(database.GetState(state.guid), state);
            Assert.ThrowsException<Exception>(() => { database.GetState("NOGUID"); });

            Assert.AreEqual(1, database.GetStateCount());
            Assert.IsTrue(database.GetAllStates().Contains(state));
            Assert.AreSame(database.GetProductState(game.guid), state);
            Assert.ThrowsException<Exception>(() => { database.GetProductState("NOGUID"); });

            database.DeleteState(state.guid);
            Assert.ThrowsException<Exception>(() => { database.DeleteState("NOGUID"); });

            Assert.AreEqual(0, database.GetStateCount());
            Assert.IsFalse(database.GetAllStates().Contains(state));
        }

        [TestMethod]
        public void EventTests()
        {
            IUser user = new User("348e7dd8-c30f-4f02-8215-4e713c58aa51", "Michal", "Gapcio", "m_gapcio@gmail.com", 20000,
                new DateTime(1998, 12, 25), 542123567, null);
            IUser user2 = new User("23d4fc2e-858f-4d81-b212-81943550ed78", "Michal", "Gapcio", "m_gapcio@gmail.com", 20000,
                new DateTime(1998, 12, 25), 542123567, null);
            IProduct game = new Game("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            IState state = new State("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", game, 10);

            IEvent testEvent = new PurchaseEvent("57afb3b7-9a7f-4d93-9688-298940a9ea11", state, user);
            IEvent testEvent1 = new PurchaseEvent("e33b179a-f1ed-4bff-a909-4f6cede80d63", state, user2);
            IEvent testEvent2 = new ReturnEvent("a3d4d9bc-4789-4a11-ab7a-451357048812", state, user2);

            Assert.AreEqual("57afb3b7-9a7f-4d93-9688-298940a9ea11", testEvent.guid);
            Assert.AreSame(state, testEvent.state);
            Assert.AreSame(user, testEvent.user);
            Assert.IsNotNull(testEvent2.occurrenceDate);

            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());

            database.AddEvent(testEvent);
            database.AddEvent(testEvent1);
            Assert.ThrowsException<Exception>(() => { database.AddEvent(testEvent); });

            Assert.AreSame(database.GetEvent(testEvent.guid), testEvent);
            Assert.ThrowsException<Exception>(() => { database.GetEvent("NOGUID"); });

            Assert.AreEqual(2, database.GetEventCount());
            Assert.IsTrue(database.GetAllEvents().Contains(testEvent));
            Assert.AreSame(database.GetLastProductEvent(game.guid), testEvent1);
            Assert.ThrowsException<Exception>(() => { database.GetLastProductEvent("NOGUID"); });

            Assert.IsTrue(database.GetProductEventHistory(game.guid).Contains(testEvent));

            database.DeleteEvent(testEvent.guid);

            Assert.ThrowsException<Exception>(() => { database.DeleteEvent("NOGUID"); });
            Assert.AreEqual(1, database.GetEventCount());
        }
    }
}
