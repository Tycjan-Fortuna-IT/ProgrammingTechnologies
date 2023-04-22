using Data.API;

namespace Test
{
    [TestClass]
    public class DataTests
    {
        IDataRepository dataRepository = IDataRepository.CreateDatabase();

        [TestMethod]
        public void UserTests()
        {
            dataRepository.AddUser("348e7dd8-c30f-4f02-8215-4e713c58aa51", "Michal", "m_gapcio@gmail.com", 200,
                new DateTime(2015, 12, 25));

            Assert.AreEqual("348e7dd8-c30f-4f02-8215-4e713c58aa51", dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").guid);
            Assert.AreEqual("Michal", dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").nickname);
            Assert.AreEqual("m_gapcio@gmail.com", dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").email);
            Assert.AreEqual(200, dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").balance);
            Assert.AreEqual(new DateTime(2015, 12, 25), dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").dateOfBirth);
            Assert.IsNotNull(dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").productLibrary);

            dataRepository.UpdateUser("348e7dd8-c30f-4f02-8215-4e713c58aa51", "Antek", "a_pcimowski@gmail.com", 850, new DateTime(2015, 12, 26));
            dataRepository.AddProduct("0a81eb06-db53-11ed-afa1-0242ac120002", "Witcher 3", 129.99, 18);

            dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").productLibrary = new Dictionary<string, IProduct>() {
                { "0a81eb06-db53-11ed-afa1-0242ac120002" , dataRepository.GetProduct("0a81eb06-db53-11ed-afa1-0242ac120002") }
            };

            Assert.AreEqual("Antek", dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").nickname);
            Assert.AreEqual("a_pcimowski@gmail.com", dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").email);
            Assert.AreEqual(850, dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").balance);
            Assert.AreEqual(new DateTime(2015, 12, 26), dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").dateOfBirth);
            Assert.AreEqual(dataRepository.GetProduct("0a81eb06-db53-11ed-afa1-0242ac120002"), dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").productLibrary["0a81eb06-db53-11ed-afa1-0242ac120002"]);

            Assert.IsTrue(dataRepository.CheckIfUserExists("348e7dd8-c30f-4f02-8215-4e713c58aa51"));
            Assert.IsFalse(dataRepository.CheckIfUserExists(System.Guid.NewGuid().ToString()));
            Assert.AreEqual(1, dataRepository.GetUserCount());
            Assert.IsTrue(dataRepository.GetAllUsers().ContainsKey("348e7dd8-c30f-4f02-8215-4e713c58aa51"));

            /*
            Assert.ThrowsException<Exception>(() => { database.AddUser(user); });

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
            */
        }

        [TestMethod]
        public void ProductTests()
        {
            dataRepository.AddProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, 18);

            Assert.AreEqual("d3daae3a-a914-4d37-839a-b26c6e634652", dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").guid);
            Assert.AreEqual("Assassin's Creed Valhalla", dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").name);
            Assert.AreEqual(239.99, dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").price);
            Assert.AreEqual(18, dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").pegi);

            dataRepository.UpdateProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "SimCity 3000", 79.99, 3);

            Assert.AreEqual("SimCity 3000", dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").name);
            Assert.AreEqual(79.99, dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").price);
            Assert.AreEqual(3, dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").pegi);

            /*
            Assert.ThrowsException<Exception>(() => { database.AddProduct(game); });

            Assert.IsTrue(dataRepository.CheckIfProductExists(game.guid));
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
            */
        }

        [TestMethod]
        public void StateTests()
        {
            dataRepository.AddProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, 18);
            dataRepository.AddState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", "d3daae3a-a914-4d37-839a-b26c6e634652", 10);
            
            Assert.AreEqual("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", dataRepository.GetState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1").guid);
            Assert.AreSame("d3daae3a-a914-4d37-839a-b26c6e634652", dataRepository.GetState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1").productGuid);
            Assert.AreEqual(10, dataRepository.GetState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1").productQuantity);

            /*
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
            */
        }
    }
}
