using Data.API;
using Logic.API;

namespace Test
{
    [TestClass]
    public class LogicTests
    {
        private IDataRepository repository;
        private IBusinessLogic logic;

        [TestInitialize]
        public void TestInitialize()
        {
            this.repository = IDataRepository.CreateDatabase();
            this.logic = IBusinessLogic.CreateLogic(this.repository);
        }

        [TestMethod]
        public void PurchaseEventTest()
        {
            //repository.AddUser("c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", "Michal", "m_gapcio@gmail.com", 200, new DateTime(2010, 12, 25));
            repository.AddUser("5525ef4a-db53-11ed-afa1-0242ac120002", "Eivor", "e_raventhrope@gmail.com", 200,
                new DateTime(1996, 12, 25));
            repository.AddUser("12790880-9130-47b2-adfb-c1df3d17e7a6", "Sigmund", "s_ledercestaire@gmail.com", 100,
                new DateTime(2016, 10, 3));
            repository.AddUser("5b25789d-422a-4de7-adb3-d18a5143c8c4", "Havi", "h_odinson@asgard.com", 500,
                new DateTime(1993, 11, 10));

            //repository.AddProduct("6701b3e8-db53-11ed-afa1-0242ac120002", "Starcraft", 61.99, 16);
            repository.AddProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, 18);
            repository.AddProduct("22c2a010-dfe4-4da3-8669-c150d0ad6068", "Cyberpunk 2077", 299.99, 18);
            repository.AddProduct("4ca8c94e-65be-44c8-ab0b-cf6fd73ddb57", "The Sims 3", 109.99, 7);
            repository.AddProduct("51c7d7ae-102b-4fe2-a38d-840a07a57f3d", "Witcher 3", 129.99, 18);
            repository.AddProduct("7561098b-d062-4ff9-8d73-11326a3eaee5", "Diablo 3", 339.99, 18);

            repository.AddState("8fac4984-db53-11ed-afa1-0242ac120002", "noguid", 3);
            repository.AddState("0e92eb1a-b8d3-4835-b317-6b348ecc633c", "d3daae3a-a914-4d37-839a-b26c6e634652", 0);
            repository.AddState("1b6bd5b9-b628-4149-b182-f9a05d092167", "22c2a010-dfe4-4da3-8669-c150d0ad6068", 20);
            repository.AddState("0ecfa654-d8e3-4757-a752-17516bf2cf9b", "4ca8c94e-65be-44c8-ab0b-cf6fd73ddb57", 4);
            repository.AddState("2c721af1-d010-48d8-a2d0-8ee3743281fd", "51c7d7ae-102b-4fe2-a38d-840a07a57f3d", 8);
            repository.AddState("b1d90cf0-2633-497f-a065-bdb449854598", "7561098b-d062-4ff9-8d73-11326a3eaee5", 1);

            Assert.ThrowsException<Exception>(() => { logic.Purchase("1b6bd5b9-b628-4149-b182-f9a05d092167", "12790880-9130-47b2-adfb-c1df3d17e7a6"); }); // not old enough
            Assert.ThrowsException<Exception>(() => { logic.Purchase("1b6bd5b9-b628-4149-b182-f9a05d092167", "5525ef4a-db53-11ed-afa1-0242ac120002"); }); // not enough money
            Assert.ThrowsException<Exception>(() => { logic.Purchase("0e92eb1a-b8d3-4835-b317-6b348ecc633c", "5b25789d-422a-4de7-adb3-d18a5143c8c4"); }); // product not available

            logic.Purchase("b1d90cf0-2633-497f-a065-bdb449854598", "5b25789d-422a-4de7-adb3-d18a5143c8c4");

            Assert.ThrowsException<Exception>(() => { logic.Purchase("b1d90cf0-2633-497f-a065-bdb449854598", "5b25789d-422a-4de7-adb3-d18a5143c8c4"); }); // product already bought

            Assert.ThrowsException<Exception>(() => { logic.Purchase("8fac4984-db53-11ed-afa1-0242ac120002", "5b25789d-422a-4de7-adb3-d18a5143c8c4"); }); // product not registered
            Assert.ThrowsException<Exception>(() => { logic.Purchase("b1d90cf0-2633-497f-a065-bdb449854598", "noguid"); }); // user not registered
        }

        [TestMethod]
        public void ReturnEventTest()
        {
            //repository.AddUser("c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", "Michal", "m_gapcio@gmail.com", 200, new DateTime(2010, 12, 25));
            repository.AddUser("5525ef4a-db53-11ed-afa1-0242ac120002", "Eivor", "e_raventhrope@gmail.com", 200,
                new DateTime(1996, 12, 25));
            repository.AddUser("12790880-9130-47b2-adfb-c1df3d17e7a6", "Sigmund", "s_ledercestaire@gmail.com", 100,
                new DateTime(2016, 10, 3));
            repository.AddUser("5b25789d-422a-4de7-adb3-d18a5143c8c4", "Havi", "h_odinson@asgard.com", 500,
                new DateTime(1993, 11, 10));

            //repository.AddProduct("6701b3e8-db53-11ed-afa1-0242ac120002", "Starcraft", 61.99, 16);
            repository.AddProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, 18);
            repository.AddProduct("22c2a010-dfe4-4da3-8669-c150d0ad6068", "Cyberpunk 2077", 299.99, 18);
            repository.AddProduct("4ca8c94e-65be-44c8-ab0b-cf6fd73ddb57", "The Sims 3", 109.99, 7);
            repository.AddProduct("51c7d7ae-102b-4fe2-a38d-840a07a57f3d", "Witcher 3", 129.99, 18);
            repository.AddProduct("7561098b-d062-4ff9-8d73-11326a3eaee5", "Diablo 3", 339.99, 18);

            repository.AddState("8fac4984-db53-11ed-afa1-0242ac120002", "noguid", 3);
            repository.AddState("0e92eb1a-b8d3-4835-b317-6b348ecc633c", "d3daae3a-a914-4d37-839a-b26c6e634652", 0);
            repository.AddState("1b6bd5b9-b628-4149-b182-f9a05d092167", "22c2a010-dfe4-4da3-8669-c150d0ad6068", 20);
            repository.AddState("0ecfa654-d8e3-4757-a752-17516bf2cf9b", "4ca8c94e-65be-44c8-ab0b-cf6fd73ddb57", 4);
            repository.AddState("2c721af1-d010-48d8-a2d0-8ee3743281fd", "51c7d7ae-102b-4fe2-a38d-840a07a57f3d", 8);
            repository.AddState("b1d90cf0-2633-497f-a065-bdb449854598", "7561098b-d062-4ff9-8d73-11326a3eaee5", 1);

            Assert.ThrowsException<Exception>(() => { logic.Return("1b6bd5b9-b628-4149-b182-f9a05d092167", "12790880-9130-47b2-adfb-c1df3d17e7a6"); }); // product not purchased

            logic.Purchase("b1d90cf0-2633-497f-a065-bdb449854598", "5b25789d-422a-4de7-adb3-d18a5143c8c4");
            logic.Return("b1d90cf0-2633-497f-a065-bdb449854598", "5b25789d-422a-4de7-adb3-d18a5143c8c4");

            Assert.ThrowsException<Exception>(() => { logic.Return("8fac4984-db53-11ed-afa1-0242ac120002", "5b25789d-422a-4de7-adb3-d18a5143c8c4"); }); // product not registered
            Assert.ThrowsException<Exception>(() => { logic.Return("b1d90cf0-2633-497f-a065-bdb449854598", "noguid"); }); // user not registered
        }

        [TestMethod]
        public void SupplyEventTest()
        {
            repository.AddUser("c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", "Michal", "m_gapcio@gmail.com", 200, new DateTime(2010, 12, 25));
            //repository.AddUser("5525ef4a-db53-11ed-afa1-0242ac120002", "Eivor", "e_raventhrope@gmail.com", 200,
                //new DateTime(1996, 12, 25));

            repository.AddProduct("6701b3e8-db53-11ed-afa1-0242ac120002", "Starcraft", 61.99, 16);
            repository.AddProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, 18);
            //repository.AddProduct("22c2a010-dfe4-4da3-8669-c150d0ad6068", "Cyberpunk 2077", 299.99, 18);

            repository.AddState("8fac4984-db53-11ed-afa1-0242ac120002", "6701b3e8-db53-11ed-afa1-0242ac120002", 3);
            repository.AddState("0e92eb1a-b8d3-4835-b317-6b348ecc633c", "d3daae3a-a914-4d37-839a-b26c6e634652", 0);
            repository.AddState("1b6bd5b9-b628-4149-b182-f9a05d092167", "noguid", 20);

            logic.Supply("8fac4984-db53-11ed-afa1-0242ac120002", "c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", 10);
            logic.Supply("0e92eb1a-b8d3-4835-b317-6b348ecc633c", "c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", 20);

            Assert.ThrowsException<Exception>(() => { logic.Supply("8fac4984-db53-11ed-afa1-0242ac120002", "c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", 0); });
            Assert.ThrowsException<Exception>(() => { logic.Supply("0e92eb1a-b8d3-4835-b317-6b348ecc633c", "c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", -20); });
            Assert.ThrowsException<Exception>(() => { logic.Supply("1b6bd5b9-b628-4149-b182-f9a05d092167", "c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", 10); });
            Assert.ThrowsException<Exception>(() => { logic.Supply("0e92eb1a-b8d3-4835-b317-6b348ecc633c", "noguid", 10); });
        }

        [TestMethod]
        public void EventMethodsTest()
        {
            repository.AddUser("348e7dd8-c30f-4f02-8215-4e713c58aa51", "Michal", "m_gapcio@gmail.com", 20000,
                new DateTime(1998, 12, 25));
            repository.AddUser("23d4fc2e-858f-4d81-b212-81943550ed78", "Eivor", "eivor39@gmail.com", 20000,
                new DateTime(1998, 12, 25));
            repository.AddProduct("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, 18);
            repository.AddState("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", "d3daae3a-a914-4d37-839a-b26c6e634652", 10);

            logic.Purchase("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", "348e7dd8-c30f-4f02-8215-4e713c58aa51");
            logic.Purchase("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", "23d4fc2e-858f-4d81-b212-81943550ed78");
            logic.Return("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", "23d4fc2e-858f-4d81-b212-81943550ed78");

            Assert.IsNotNull(repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").guid);
            Assert.AreEqual("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").stateGuid);
            Assert.AreEqual("23d4fc2e-858f-4d81-b212-81943550ed78", repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").userGuid);
            Assert.IsNotNull(repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").occurrenceDate);

            Assert.ThrowsException<Exception>(() => { logic.Purchase("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", "348e7dd8-c30f-4f02-8215-4e713c58aa51"); });
            Assert.ThrowsException<Exception>(() => { repository.AddEvent(repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").guid, "b1d90cf0-2633-497f-a065-bdb449854598", "c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", "ReturnEvent"); }); // event exists
            Assert.ThrowsException<Exception>(() => { repository.AddEvent("03b1cb6f-e382-433e-ab5c-776a40e0741c", "0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", "23d4fc2e-858f-4d81-b212-81943550ed78", "different"); }); // event type does not exist

            Assert.AreSame(repository.GetEvent(repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").guid), repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652"));
            Assert.ThrowsException<Exception>(() => { repository.GetEvent("NOGUID"); });

            Assert.AreEqual(3, repository.GetEventCount());
            Assert.IsTrue(repository.GetAllEvents().ContainsKey(repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").guid));
            Assert.ThrowsException<Exception>(() => { repository.GetLastProductEvent("NOGUID"); });

            Assert.IsTrue(repository.GetProductEventHistory("d3daae3a-a914-4d37-839a-b26c6e634652").ContainsKey(repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").guid));

            repository.DeleteEvent(repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").guid);
            Assert.AreEqual(2, repository.GetEventCount());

            Assert.ThrowsException<Exception>(() => { repository.DeleteEvent("NOGUID"); });
            
            logic.Supply("0a24ee26-7a3c-4d26-964c-22a1ff38cdb1", "348e7dd8-c30f-4f02-8215-4e713c58aa51", 5);

            Assert.AreSame("348e7dd8-c30f-4f02-8215-4e713c58aa51", repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").userGuid);
            Assert.IsNotNull(repository.GetLastProductEvent("d3daae3a-a914-4d37-839a-b26c6e634652").occurrenceDate);

            
        }
    }
}
