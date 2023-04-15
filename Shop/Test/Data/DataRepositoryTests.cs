using Shop.Data;

namespace Shop.Test.Data
{
    [TestClass]
    public class DataRepositoryTests
    {
        IDataRepository Repository = new DataRepository(new DataContext());
        IUser User = new User("c2a0cb1c-38cb-41d8-a9bc-41f3fce7feca", "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2015, 12, 25), 542123567, null);
        IProduct game = new Game(null, "Diablo 3", 339.99, new DateTime(2012, 5, 15), 18);
        IState state = new State(null, new Game(null, "Starcraft", 61.99, new DateTime(1998, 3, 28), 16), 4);
        IEvent Buy = new PurchaseEvent(null, new State(null, new Game("99ef670b-9a73-432b-b3fd-2f575f56c312", "Hollow Knight", 55.99, new DateTime(2017, 2, 24), 13), 1), new User(null, "Arno", "Dorian", "a_dorian@paris.fr", 100, new DateTime(1990, 4, 5), 758903841, null));
        
        [TestInitialize]
        public void Initialize()
        {
            this.Repository.Add<IUser>(User);
            this.Repository.Add<IProduct>(game);
            this.Repository.Add<IState>(state);
            this.Repository.Add<IEvent>(Buy);
        }

        [TestMethod]
        public void DataRepositoryAddUserTest()
        {
            Assert.AreEqual(1, Repository.GetCount<IUser>());

            Assert.ThrowsException<Exception>(() => Repository.Add<IUser>(User));
        }

        [TestMethod]
        public void DataRepositoryGetUserTest()
        {
            IUser User1 = Repository.Get<IUser>(User.Guid);

            Assert.ReferenceEquals(User, User1);

            Assert.ThrowsException<Exception>(() => Repository.Get<IUser>("NOGUID"));
        }

        [TestMethod]
        public void DataRepositoryUpdateUserTest()
        {
            User.Name = "Test";
            User.Surname = "Test";
            User.Email = "Test";
            User.Balance = 100;
            User.DateOfBirth = new DateTime(2013, 10, 11);
            User.PhoneNumber = 123556677;

            Repository.Update<IUser>(User.Guid, User);

            IUser User1 = Repository.Get<IUser>(User.Guid);

            Assert.AreEqual("Test", User1.Name);
            Assert.AreEqual("Test", User1.Surname);
            Assert.AreEqual("Test", User1.Email);
            Assert.AreEqual(100, User1.Balance);
            Assert.AreEqual(new DateTime(2013, 10, 11), User1.DateOfBirth);
            Assert.AreEqual(123556677, User1.PhoneNumber);

            Assert.ThrowsException<Exception>(() => Repository.Update<IUser>("NOGUID", User));
        }

        [TestMethod]
        public void DataRepositoryDeleteUserTest()
        {
            Assert.AreEqual(1, Repository.GetCount<IUser>());

            Repository.Delete<IUser>(User.Guid);

            Assert.AreEqual(0, Repository.GetCount<IUser>());

            Assert.ThrowsException<Exception>(() => Repository.Delete<IUser>("NOGUID"));
        }

        [TestMethod]
        public void DataRepositoryGetAllTest()
        {
            var wholeContext = Repository.GetAll<IUser>();

            Assert.IsNotNull(wholeContext);
            Assert.AreEqual(1, Repository.GetCount<IUser>());
            Assert.IsTrue(wholeContext.ContainsValue(User));
        }

        [TestMethod]
        public void DataRepositoryGetLastProductEventTest()
        {
            var testEvent = Repository.GetLastProductEvent("99ef670b-9a73-432b-b3fd-2f575f56c312");

            Assert.IsNotNull(testEvent);
        }

        [TestMethod]
        public void DataRepositoryGetProductHistoryTest()
        {
            var history = Repository.GetProductEventHistory("99ef670b-9a73-432b-b3fd-2f575f56c312");

            Assert.AreEqual(1, history.Count);
        }

        [TestMethod]
        public void DataRepositoryGetProductState()
        {
            var ProductState = Repository.GetProductState("99ef670b-9a73-432b-b3fd-2f575f56c312");
            IState ExpectedValue = new State(null, new Game("99ef670b-9a73-432b-b3fd-2f575f56c312", "Hollow Knight", 55.99, new DateTime(2017, 2, 24), 13), 0);

            Assert.AreEqual(ExpectedValue, ProductState);
        }
    }
}
