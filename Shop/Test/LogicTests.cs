using Data.API;
using Data.Implementation;
using Logic.API;
using System.Runtime.Intrinsics.X86;

namespace Test
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void PurchaseEventTest()
        {
            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());
            IBusinessLogic logic = IBusinessLogic.CreateLogic(database);

            IUser user1 = new User("c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2010, 12, 25), 542123567, null);
            IUser user2 = new User("5525ef4a-db53-11ed-afa1-0242ac120002", "Eivor", "Raventhrope", "e_raventhrope@gmail.com", 200,
                new DateTime(1996, 12, 25), 542123567, null);
            IUser user3 = new User("12790880-9130-47b2-adfb-c1df3d17e7a6", "Sigmund", "Ledercestaire", "s_ledercestaire@gmail.com", 100,
                new DateTime(2016, 10, 3), 543903567, null);
            IUser user4 = new User("5b25789d-422a-4de7-adb3-d18a5143c8c4", "Havi", "Odinson", "h_odinson@asgard.com", 500,
                new DateTime(1993, 11, 10), 982374901, null);

            IProduct game1 = new Game("6701b3e8-db53-11ed-afa1-0242ac120002", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            IProduct game2 = new Game("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            IProduct game3 = new Game("22c2a010-dfe4-4da3-8669-c150d0ad6068", "Cyberpunk 2077", 299.99, new DateTime(2020, 12, 10), 18);
            IProduct game4 = new Game("4ca8c94e-65be-44c8-ab0b-cf6fd73ddb57", "The Sims 3", 109.99, new DateTime(2009, 6, 12), 7);
            IProduct game5 = new Game("51c7d7ae-102b-4fe2-a38d-840a07a57f3d", "Witcher 3", 129.99, new DateTime(2015, 5, 18), 18);
            IProduct game6 = new Game("7561098b-d062-4ff9-8d73-11326a3eaee5", "Diablo 3", 339.99, new DateTime(2012, 5, 15), 18);

            IState state1 = new State("8fac4984-db53-11ed-afa1-0242ac120002", game1, 3);
            IState state2 = new State("0e92eb1a-b8d3-4835-b317-6b348ecc633c", game2, 0);
            IState state3 = new State("1b6bd5b9-b628-4149-b182-f9a05d092167", game3, 20);
            IState state4 = new State("0ecfa654-d8e3-4757-a752-17516bf2cf9b", game4, 4);
            IState state5 = new State("2c721af1-d010-48d8-a2d0-8ee3743281fd", game5, 8);
            IState state6 = new State("b1d90cf0-2633-497f-a065-bdb449854598", game6, 1);

            //database.AddUser(user1);
            database.AddUser(user2);
            database.AddUser(user3);
            database.AddUser(user4);
            
            //database.AddProduct(game1);
            database.AddProduct(game2);
            database.AddProduct(game3);
            database.AddProduct(game4);
            database.AddProduct(game5);
            database.AddProduct(game6);

            //database.AddState(state1);
            database.AddState(state2);
            database.AddState(state3);
            database.AddState(state4);
            database.AddState(state5);
            database.AddState(state6);

            Assert.ThrowsException<Exception>(() => { logic.Purchase(state3, user3); }); // not old enough
            Assert.ThrowsException<Exception>(() => { logic.Purchase(state3, user2); }); // not enough money
            Assert.ThrowsException<Exception>(() => { logic.Purchase(state2, user4); }); // product not available

            logic.Purchase(state6, user4);

            Assert.ThrowsException<Exception>(() => { logic.Purchase(state6, user4); }); // product already bought

            Assert.ThrowsException<Exception>(() => { logic.Purchase(state1, user4); }); // product not registered
            Assert.ThrowsException<Exception>(() => { logic.Purchase(state6, user1); }); // user not registered
        }

        [TestMethod]
        public void ReturnEventTest()
        {
            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());
            IBusinessLogic logic = IBusinessLogic.CreateLogic(database);

            IUser user1 = new User("c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2010, 12, 25), 542123567, null);
            IUser user2 = new User("5525ef4a-db53-11ed-afa1-0242ac120002", "Eivor", "Raventhrope", "e_raventhrope@gmail.com", 200,
                new DateTime(1996, 12, 25), 542123567, null);
            IUser user3 = new User("12790880-9130-47b2-adfb-c1df3d17e7a6", "Sigmund", "Ledercestaire", "s_ledercestaire@gmail.com", 100,
                new DateTime(2016, 10, 3), 543903567, null);
            IUser user4 = new User("5b25789d-422a-4de7-adb3-d18a5143c8c4", "Havi", "Odinson", "h_odinson@asgard.com", 500,
                new DateTime(1993, 11, 10), 982374901, null);

            IProduct game1 = new Game("6701b3e8-db53-11ed-afa1-0242ac120002", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            IProduct game2 = new Game("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            IProduct game3 = new Game("22c2a010-dfe4-4da3-8669-c150d0ad6068", "Cyberpunk 2077", 299.99, new DateTime(2020, 12, 10), 18);
            IProduct game4 = new Game("4ca8c94e-65be-44c8-ab0b-cf6fd73ddb57", "The Sims 3", 109.99, new DateTime(2009, 6, 12), 7);
            IProduct game5 = new Game("51c7d7ae-102b-4fe2-a38d-840a07a57f3d", "Witcher 3", 129.99, new DateTime(2015, 5, 18), 18);
            IProduct game6 = new Game("7561098b-d062-4ff9-8d73-11326a3eaee5", "Diablo 3", 339.99, new DateTime(2012, 5, 15), 18);

            IState state1 = new State("8fac4984-db53-11ed-afa1-0242ac120002", game1, 3);
            IState state2 = new State("0e92eb1a-b8d3-4835-b317-6b348ecc633c", game2, 0);
            IState state3 = new State("1b6bd5b9-b628-4149-b182-f9a05d092167", game3, 20);
            IState state4 = new State("0ecfa654-d8e3-4757-a752-17516bf2cf9b", game4, 4);
            IState state5 = new State("2c721af1-d010-48d8-a2d0-8ee3743281fd", game5, 8);
            IState state6 = new State("b1d90cf0-2633-497f-a065-bdb449854598", game6, 1);

            //database.AddUser(user1);
            database.AddUser(user2);
            database.AddUser(user3);
            database.AddUser(user4);

            //database.AddProduct(game1);
            database.AddProduct(game2);
            database.AddProduct(game3);
            database.AddProduct(game4);
            database.AddProduct(game5);
            database.AddProduct(game6);

            //database.AddState(state1);
            database.AddState(state2);
            database.AddState(state3);
            database.AddState(state4);
            database.AddState(state5);
            database.AddState(state6);

            Assert.ThrowsException<Exception>(() => { logic.Return(state3, user3); }); // product not purchased

            logic.Purchase(state6, user4);
            logic.Return(state6, user4);

            Assert.ThrowsException<Exception>(() => { logic.Return(state1, user4); }); // product not registered
            Assert.ThrowsException<Exception>(() => { logic.Return(state6, user1); }); // user not registered
        }

        [TestMethod]
        public void SupplyEventTest()
        {
            IDataRepository database = IDataRepository.CreateDatabase(new DataContext());
            IBusinessLogic logic = IBusinessLogic.CreateLogic(database);

            IUser user1 = new User("c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2010, 12, 25), 542123567, null);
            IUser user2 = new User("5525ef4a-db53-11ed-afa1-0242ac120002", "Eivor", "Raventhrope", "e_raventhrope@gmail.com", 200,
                new DateTime(1996, 12, 25), 542123567, null);

            IProduct game1 = new Game("6701b3e8-db53-11ed-afa1-0242ac120002", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            IProduct game2 = new Game("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            IProduct game3 = new Game("22c2a010-dfe4-4da3-8669-c150d0ad6068", "Cyberpunk 2077", 299.99, new DateTime(2020, 12, 10), 18);

            IState state1 = new State("8fac4984-db53-11ed-afa1-0242ac120002", game1, 3);
            IState state2 = new State("0e92eb1a-b8d3-4835-b317-6b348ecc633c", game2, 0);
            IState state3 = new State("1b6bd5b9-b628-4149-b182-f9a05d092167", game3, 20);

            database.AddUser(user1);
            database.AddProduct(game1);
            database.AddProduct(game2);
            database.AddState(state1);
            database.AddState(state2);

            logic.Supply(state1, user1, 10);
            logic.Supply(state2, user1, 20);

            Assert.ThrowsException<Exception>(() => { logic.Supply(state1, user1, 0); });
            Assert.ThrowsException<Exception>(() => { logic.Supply(state2, user1, -20); });
            Assert.ThrowsException<Exception>(() => { logic.Supply(state3, user1, 10); });
            Assert.ThrowsException<Exception>(() => { logic.Supply(state2, user2, 10); });
        }

        [TestMethod]
        public void EventMethodsTest()
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

            IEvent testEvent3 = new SupplyEvent("ec5d3229-1a77-493a-848e-0d1afffb5d2d", state, user2, 5);
            database.AddEvent(testEvent3);

            Assert.AreSame(user2, testEvent3.user);
            Assert.IsNotNull(testEvent3.occurrenceDate);
        }
    }
}
