using Shop.Data;
using Shop.Logic;

namespace Shop.Test.Logic
{
    [TestClass]
    public class BusinessLogicTests
    {
        BusinessLogic BusinessLogic = new BusinessLogic(new DataRepository(new DataContext()));

        IUser user1 = new User("c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
               new DateTime(2010, 12, 25), 542123567, null);
        IUser user2 = new User("5525ef4a-db53-11ed-afa1-0242ac120002", "Eivor", "Raventhrope", "e_raventhrope@gmail.com", 200, new DateTime(1996, 12, 25), 542123567, null);
        IUser user3 = new User("12790880-9130-47b2-adfb-c1df3d17e7a6", "Sigmund", "Ledercestaire", "s_ledercestaire@gmail.com", 100, new DateTime(2016, 10, 3), 543903567, null);
        IUser user4 = new User("5b25789d-422a-4de7-adb3-d18a5143c8c4", "Havi", "Odinson", "h_odinson@asgard.com", 500, new DateTime(1993, 11, 10), 982374901, null);

        static IProduct game1 = new Game("6701b3e8-db53-11ed-afa1-0242ac120002", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
        static IProduct game2 = new Game("d3daae3a-a914-4d37-839a-b26c6e634652", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
        static IProduct game3 = new Game("22c2a010-dfe4-4da3-8669-c150d0ad6068", "Cyberpunk 2077", 299.99, new DateTime(2020, 12, 10), 18);
        static IProduct game4 = new Game("4ca8c94e-65be-44c8-ab0b-cf6fd73ddb57", "The Sims 3", 109.99, new DateTime(2009, 6, 12), 7);
        static IProduct game5 = new Game("51c7d7ae-102b-4fe2-a38d-840a07a57f3d", "Witcher 3", 129.99, new DateTime(2015, 5, 18), 18);
        static IProduct game6 = new Game("7561098b-d062-4ff9-8d73-11326a3eaee5", "Diablo 3", 339.99, new DateTime(2012, 5, 15), 18);

        IState state1 = new State("8fac4984-db53-11ed-afa1-0242ac120002", game1, 3);
        IState state2 = new State("0e92eb1a-b8d3-4835-b317-6b348ecc633c", game2, 0);
        IState state3 = new State("1b6bd5b9-b628-4149-b182-f9a05d092167", game3, 20);
        IState state4 = new State("0ecfa654-d8e3-4757-a752-17516bf2cf9b", game4, 4);
        IState state5 = new State("2c721af1-d010-48d8-a2d0-8ee3743281fd", game5, 8);
        IState state6  = new State("b1d90cf0-2633-497f-a065-bdb449854598", game6, 1);

        [TestInitialize]
        public void Initialize()
        {
            this.BusinessLogic.RegisterUser(user1);
            this.BusinessLogic.RegisterUser(user2);
            this.BusinessLogic.RegisterUser(user3);
            this.BusinessLogic.RegisterUser(user4);

            this.BusinessLogic.RegisterProduct(game1);
            this.BusinessLogic.RegisterProduct(game2);
            this.BusinessLogic.RegisterProduct(game3);
            this.BusinessLogic.RegisterProduct(game4);
            this.BusinessLogic.RegisterProduct(game5);
            this.BusinessLogic.RegisterProduct(game6);

            this.BusinessLogic.RegisterState(state1);
            this.BusinessLogic.RegisterState(state2);
            this.BusinessLogic.RegisterState(state3);
            this.BusinessLogic.RegisterState(state4);
            this.BusinessLogic.RegisterState(state5);
            this.BusinessLogic.RegisterState(state6);
        }

        [TestMethod]
        //[ExpectedException(typeof(Exception))]
        public void PurchasesTest()
        {
            //BusinessLogic.Purchase(user3, state3); // not old enough
            BusinessLogic.Purchase(user4, state1);
            BusinessLogic.Purchase(user4, state4);
            Assert.AreEqual(2, BusinessLogic.GetUser("5b25789d-422a-4de7-adb3-d18a5143c8c4").ProductLibrary.Count);
        }

        [TestMethod]
        public void ReturnsTest()
        {
            BusinessLogic.Purchase(user4, state1);
            BusinessLogic.Purchase(user4, state4);
            BusinessLogic.Return(user4, state4);
            Assert.AreEqual(1, BusinessLogic.GetUser("5b25789d-422a-4de7-adb3-d18a5143c8c4").ProductLibrary.Count);
        }
    }
}


//1 osoba kupuje 2,3
//2 kupuje wszystkie
//3 kupuje 3,5,6
//1 osoba zwraca 2
//2 osoba chce kupić coś 18+ ale nie może
//3 osoba chce kupić coś co już ma
//1 osoba zwraca coś czego nie ma
//2 osoba nie ma kasy
//3 kupuje coś czego nie ma / skonczyl sie zapas