using Shop.Data;

namespace Shop.Test.Data
{
    [TestClass]
    public class DataRepositoryTests
    {
        private IDataRepository Repository = new DataRepository(new DataContext());
        private IUser User = new User(null, "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2015, 12, 25), 542123567);

        [TestInitialize]
        public void Initialize()
        {
            this.Repository.Add<IUser>(User);
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
        }
    }
}
