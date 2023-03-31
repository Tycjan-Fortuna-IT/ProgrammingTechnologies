using Shop.Data;

namespace Shop.Test.Data
{
    [TestClass]
    public class DataRepositoryTests
    {
        private IDataRepository Repository;
        private IUser User;

        [TestInitialize]
        public void Initialize()
        {
            Repository = new DataRepository(new DataContext());

            User = new User(null, "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2015, 12, 25), 542123567);

            Repository.AddUser(User);
        }

        [TestMethod]
        public void DataRepositoryAddUserTest()
        {
            Assert.AreEqual(1, Repository.GetUsersCount());

            Assert.ThrowsException<Exception>(() => Repository.AddUser(User));
        }

        [TestMethod]
        public void DataRepositoryGetUserTest()
        {
            IUser User1 = Repository.GetUser(User.Guid);

            Assert.ReferenceEquals(User, User1);

            Assert.ThrowsException<Exception>(() => Repository.GetUser("NOGUID"));
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

            Repository.UpdateUser(User.Guid, User);

            IUser User1 = Repository.GetUser(User.Guid);

            Assert.AreEqual("Test", User1.Name);
            Assert.AreEqual("Test", User1.Surname);
            Assert.AreEqual("Test", User1.Email);
            Assert.AreEqual(100, User1.Balance);
            Assert.AreEqual(new DateTime(2013, 10, 11), User1.DateOfBirth);
            Assert.AreEqual(123556677, User1.PhoneNumber);

            Assert.ThrowsException<Exception>(() => Repository.UpdateUser("NOGUID", User));
        }

        [TestMethod]
        public void DataRepositoryDeleteUserTest()
        {
            Assert.AreEqual(1, Repository.GetUsersCount());

            Repository.DeleteUser(User.Guid);

            Assert.AreEqual(0, Repository.GetUsersCount());
        }
    }
}
