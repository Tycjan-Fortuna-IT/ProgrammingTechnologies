using Data.API;
using Data.Implementation;

namespace Test.Data
{
    [TestClass]
    public class DataTests
    {
        [TestMethod]
        public void UserTests()
        {
            IUser user = new User("348e7dd8-c30f-4f02-8215-4e713c58aa51", "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2015, 12, 25), 542123567, null);

            Assert.AreEqual("348e7dd8-c30f-4f02-8215-4e713c58aa51", user.Guid);
            Assert.AreEqual("Michal", user.Name);
            Assert.AreEqual("Gapcio", user.Surname);
            Assert.AreEqual("m_gapcio@gmail.com", user.Email);
            Assert.AreEqual(200, user.Balance);
            Assert.AreEqual(new DateTime(2015, 12, 25), user.DateOfBirth);
            Assert.AreEqual(542123567, user.PhoneNumber);
            Assert.IsNotNull(user.ProductLibrary);

            user.Name = "Antek";
            user.Surname = "Pcimowski";
            user.Email = "a_pcimowski@gmail.com";
            user.Balance = 850;
            user.DateOfBirth = new DateTime(2015, 12, 26);
            user.PhoneNumber = 495039281;
            Game game = new Game(null, "Witcher 3", 129.99, new DateTime(2015, 5, 18), 18);
            Dictionary<string, IProduct> newProductLibrary = new Dictionary<string, IProduct>() {
                { "0a81eb06-db53-11ed-afa1-0242ac120002", game }
            };
            user.ProductLibrary = newProductLibrary;

            Assert.AreEqual("Antek", user.Name);
            Assert.AreEqual("Pcimowski", user.Surname);
            Assert.AreEqual("a_pcimowski@gmail.com", user.Email);
            Assert.AreEqual(850, user.Balance);
            Assert.AreEqual(new DateTime(2015, 12, 26), user.DateOfBirth);
            Assert.AreEqual(495039281, user.PhoneNumber);
            Assert.AreEqual(game, user.ProductLibrary["0a81eb06-db53-11ed-afa1-0242ac120002"]);

            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());

            database.AddUser(user);
            Assert.ThrowsException<Exception>(() => { database.AddUser(user); });

            Assert.IsTrue(database.CheckIfUserExists(user.Guid));
            Assert.IsFalse(database.CheckIfUserExists(System.Guid.NewGuid().ToString()));
            Assert.AreEqual(1, database.GetUserCount());
            Assert.IsTrue(database.GetAllUsers().Contains(user));

            user.Name = "Test";

            database.UpdateUser(user);

            IUser user2 = new User("NOGUID", "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2015, 12, 25), 542123567, null);

            Assert.ThrowsException<Exception>(() => { database.UpdateUser(user2); });
            Assert.AreEqual(database.GetUser(user.Guid).Name, user.Name);
            Assert.ThrowsException<Exception>(() => { database.GetUser("NOGUID"); });

            database.DeleteUser(user.Guid);
            Assert.ThrowsException<Exception>(() => { database.DeleteUser("NOGUID"); });
            Assert.AreEqual(0, database.GetUserCount());
            Assert.IsFalse(database.GetAllUsers().Contains(user));
        }

        [TestMethod]
        public void ProductTests()
        {
            IProduct game = new Game("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);

            Assert.AreEqual("d3daae3a-a914-4d37-839a-b26c6e634652", game.Guid);
            Assert.AreEqual("Assassin's Creed Valhalla", game.Name);
            Assert.AreEqual(239.99, game.Price);
            Assert.AreEqual(new DateTime(2020, 11, 10), game.ReleaseDate);
            Assert.AreEqual(18, ((Game)game).PEGI);

            game.Name = "SimCity 3000";
            game.Price = 79.99;
            game.ReleaseDate = new DateTime(1999, 1, 31);
            ((Game)game).PEGI = 3;

            Assert.AreEqual("SimCity 3000", game.Name);
            Assert.AreEqual(79.99, game.Price);
            Assert.AreEqual(new DateTime(1999, 1, 31), game.ReleaseDate);
            Assert.AreEqual(3, ((Game)game).PEGI);

            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());

            database.AddProduct(game);
            Assert.ThrowsException<Exception>(() => { database.AddProduct(game); });

            Assert.IsTrue(database.CheckIfProductExists(game.Guid));
            Assert.IsFalse(database.CheckIfProductExists(System.Guid.NewGuid().ToString()));
            Assert.AreEqual(1, database.GetProductCount());
            Assert.IsTrue(database.GetAllProducts().Contains(game));

            game.Name = "Test";

            database.UpdateProduct(game);
            IProduct game1 = new Game("NOGUID", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            
            Assert.ThrowsException<Exception>(() => { database.UpdateProduct(game1); });
            Assert.AreEqual(database.GetProduct(game.Guid).Name, game.Name);
            Assert.ThrowsException<Exception>(() => { database.GetProduct("NOGUID"); });

            database.DeleteProduct(game.Guid);

            Assert.ThrowsException<Exception>(() => { database.DeleteProduct("NOGUID"); });
            Assert.AreEqual(0, database.GetProductCount());
            Assert.IsFalse(database.GetAllProducts().Contains(game));
        }

        [TestMethod]
        public void StateTests()
        {
            IProduct game = new Game("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            IState state = new State("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", game, 10);

            Assert.AreEqual("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", state.Guid);
            Assert.AreSame(game, state.Product);
            Assert.AreEqual(10, state.ProductQuantity);

            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());

            database.AddProduct(game);
            database.AddState(state);
            Assert.ThrowsException<Exception>(() => { database.AddState(state); });

            Assert.AreSame(database.GetState(state.Guid), state);
            Assert.ThrowsException<Exception>(() => { database.GetState("NOGUID"); });

            Assert.AreEqual(1, database.GetStateCount());
            Assert.IsTrue(database.GetAllStates().Contains(state));
            Assert.AreSame(database.GetProductState(game.Guid), state);
            Assert.ThrowsException<Exception>(() => { database.GetProductState("NOGUID"); });

            database.DeleteState(state.Guid);
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

            Assert.AreEqual("57afb3b7-9a7f-4d93-9688-298940a9ea11", testEvent.Guid);
            Assert.AreSame(state, testEvent.State);
            Assert.AreSame(user, testEvent.User);
            Assert.IsNotNull(testEvent2.OccurrenceDate);

            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());

            database.AddEvent(testEvent);
            database.AddEvent(testEvent1);
            Assert.ThrowsException<Exception>(() => { database.AddEvent(testEvent); });

            Assert.AreSame(database.GetEvent(testEvent.Guid), testEvent);
            Assert.ThrowsException<Exception>(() => { database.GetEvent("NOGUID"); });

            Assert.AreEqual(2, database.GetEventCount());
            Assert.IsTrue(database.GetAllEvents().Contains(testEvent));
            Assert.AreSame(database.GetLastProductEvent(game.Guid), testEvent1);
            Assert.ThrowsException<Exception>(() => { database.GetLastProductEvent("NOGUID"); });

            Assert.IsTrue(database.GetProductEventHistory(game.Guid).Contains(testEvent));

            database.DeleteEvent(testEvent.Guid);

            Assert.ThrowsException<Exception>(() => { database.DeleteEvent("NOGUID"); });
            Assert.AreEqual(1, database.GetEventCount());
        }
    }
}
