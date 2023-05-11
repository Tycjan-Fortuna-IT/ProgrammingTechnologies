using Data.API;

namespace Test
{
    [TestClass]
    public class DataTests
    {
        IDataRepository dataRepository = IDataRepository.CreateDatabase();

        [TestMethod]
        public async Task DatabaseOperationsTests()
        {
            //await dataRepository.AddUserAsync("test2", "test", 21.2, DateTime.Now);

            //IUser user = await dataRepository.GetUserAsync(1);

            //int count = await dataRepository.GetUsersCountAsync();

            //Console.WriteLine(count);
        }

        //[TestMethod]
        //public void UserTests()
        //{
        //    dataRepository.AddUser("348e7dd8-c30f-4f02-8215-4e713c58aa51", "Michal", "m_gapcio@gmail.com", 200,
        //        new DateTime(2015, 12, 25));

        //    Assert.AreEqual("348e7dd8-c30f-4f02-8215-4e713c58aa51", dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").guid);
        //    Assert.AreEqual("Michal", dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").nickname);
        //    Assert.AreEqual("m_gapcio@gmail.com", dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").email);
        //    Assert.AreEqual(200, dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").balance);
        //    Assert.AreEqual(new DateTime(2015, 12, 25), dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").dateOfBirth);
        //    Assert.IsNotNull(dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").productLibrary);

        //    Assert.ThrowsException<Exception>(() => { dataRepository.AddUser("348e7dd8-c30f-4f02-8215-4e713c58aa51", "random48", "random48@gmail.com", 400, new DateTime(1999, 4, 5)); });

        //    dataRepository.UpdateUser("348e7dd8-c30f-4f02-8215-4e713c58aa51", "Antek", "a_pcimowski@gmail.com", 850, new DateTime(2015, 12, 26));
        //    dataRepository.AddProduct("0a81eb06-db53-11ed-afa1-0242ac120002", "Witcher 3", 129.99, 18);
        //    dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").productLibrary = new Dictionary<string, IProduct>() {
        //        { "0a81eb06-db53-11ed-afa1-0242ac120002" , dataRepository.GetProduct("0a81eb06-db53-11ed-afa1-0242ac120002") }
        //    };

        //    Assert.AreEqual("Antek", dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").nickname);
        //    Assert.AreEqual("a_pcimowski@gmail.com", dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").email);
        //    Assert.AreEqual(850, dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").balance);
        //    Assert.AreEqual(new DateTime(2015, 12, 26), dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").dateOfBirth);
        //    Assert.AreSame(dataRepository.GetProduct("0a81eb06-db53-11ed-afa1-0242ac120002"), dataRepository.GetUser("348e7dd8-c30f-4f02-8215-4e713c58aa51").productLibrary["0a81eb06-db53-11ed-afa1-0242ac120002"]);

        //    Assert.IsTrue(dataRepository.CheckIfUserExists("348e7dd8-c30f-4f02-8215-4e713c58aa51"));
        //    Assert.AreEqual(1, dataRepository.GetUserCount());
        //    Assert.IsTrue(dataRepository.GetAllUsers().ContainsKey("348e7dd8-c30f-4f02-8215-4e713c58aa51"));

        //    Assert.IsFalse(dataRepository.CheckIfUserExists(System.Guid.NewGuid().ToString()));

        //    dataRepository.DeleteUser("348e7dd8-c30f-4f02-8215-4e713c58aa51");
        //    Assert.AreEqual(0, dataRepository.GetUserCount());
        //    Assert.IsFalse(dataRepository.GetAllUsers().ContainsKey("348e7dd8-c30f-4f02-8215-4e713c58aa51"));

        //    Assert.ThrowsException<Exception>(() => { dataRepository.UpdateUser("NOGUID", "nicknameTest", "n_Test@o2.pl", 1200, new DateTime(2000, 9, 14)); });
        //    Assert.ThrowsException<Exception>(() => { dataRepository.GetUser("NOGUID"); });
        //    Assert.ThrowsException<Exception>(() => { dataRepository.DeleteUser("NOGUID"); });
        //}

        //[TestMethod]
        //public void ProductTests()
        //{
        //    dataRepository.AddProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, 18);

        //    Assert.AreEqual("d3daae3a-a914-4d37-839a-b26c6e634652", dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").guid);
        //    Assert.AreEqual("Assassin's Creed Valhalla", dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").name);
        //    Assert.AreEqual(239.99, dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").price);
        //    Assert.AreEqual(18, dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").pegi);

        //    Assert.ThrowsException<Exception>(() => { dataRepository.AddProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "Diablo 3", 339.99, 18); }); // already exists

        //    dataRepository.UpdateProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "SimCity 3000", 79.99, 3);

        //    Assert.AreEqual("SimCity 3000", dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").name);
        //    Assert.AreEqual(79.99, dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").price);
        //    Assert.AreEqual(3, dataRepository.GetProduct("d3daae3a-a914-4d37-839a-b26c6e634652").pegi);
 
        //    Assert.IsTrue(dataRepository.CheckIfProductExists("d3daae3a-a914-4d37-839a-b26c6e634652"));
        //    Assert.AreEqual(1, dataRepository.GetProductCount());
        //    Assert.IsTrue(dataRepository.GetAllProducts().ContainsKey("d3daae3a-a914-4d37-839a-b26c6e634652"));

        //    Assert.IsFalse(dataRepository.CheckIfProductExists(System.Guid.NewGuid().ToString()));

        //    dataRepository.DeleteProduct("d3daae3a-a914-4d37-839a-b26c6e634652");
        //    Assert.AreEqual(0, dataRepository.GetProductCount());
        //    Assert.IsFalse(dataRepository.GetAllProducts().ContainsKey("d3daae3a-a914-4d37-839a-b26c6e634652"));

        //    Assert.ThrowsException<Exception>(() => { dataRepository.UpdateProduct("NOGUID", "Assassin's Creed Valhalla", 239.99, 18); });
        //    Assert.ThrowsException<Exception>(() => { dataRepository.GetProduct("NOGUID"); });
        //    Assert.ThrowsException<Exception>(() => { dataRepository.DeleteProduct("NOGUID"); });
        //}

        //[TestMethod]
        //public void StateTests()
        //{
        //    dataRepository.AddProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, 18);
        //    dataRepository.AddState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", "d3daae3a-a914-4d37-839a-b26c6e634652", 10);
            
        //    Assert.AreEqual("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", dataRepository.GetState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1").guid);
        //    Assert.AreEqual("d3daae3a-a914-4d37-839a-b26c6e634652", dataRepository.GetState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1").productGuid);
        //    Assert.AreEqual(10, dataRepository.GetState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1").productQuantity);

        //    Assert.ThrowsException<Exception>(() => { dataRepository.AddState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", "1a75e2e6-01fc-4a27-9aca-0b933cf59d84", 100); });

        //    Assert.AreEqual(1, dataRepository.GetStateCount());
        //    Assert.IsTrue(dataRepository.GetAllStates().ContainsKey("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1"));

        //    Assert.AreSame(dataRepository.GetState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1"), dataRepository.GetProductState("d3daae3a-a914-4d37-839a-b26c6e634652"));
        //    Assert.ThrowsException<Exception>(() => { dataRepository.GetProductState("NOGUID"); });

        //    dataRepository.DeleteState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1");
        //    Assert.AreEqual(0, dataRepository.GetStateCount());
        //    Assert.IsFalse(dataRepository.GetAllStates().ContainsKey("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1"));
        
        //    Assert.ThrowsException<Exception>(() => { dataRepository.GetState("NOGUID"); });
        //    Assert.ThrowsException<Exception>(() => { dataRepository.DeleteState("NOGUID"); });
        //}
    }
}
