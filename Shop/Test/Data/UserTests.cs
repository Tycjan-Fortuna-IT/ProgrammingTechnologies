using Shop.Data;

namespace Shop.Test.Data
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void GettersAndSettersTest()
        {
            IUser user = new User(null, "Michal", "Gapcio", "m_gapcio@gmail.com", 200,
                new DateTime(2015, 12, 25), 542123567);

            Assert.IsNotNull(user.Guid);

            Assert.AreEqual("Michal", user.Name);
            Assert.AreEqual("Gapcio", user.Surname);
            Assert.AreEqual("m_gapcio@gmail.com", user.Email);
            Assert.AreEqual(200, user.Balance);
            Assert.AreEqual(new DateTime(2015, 12, 25), user.DateOfBirth);
            Assert.AreEqual(542123567, user.PhoneNumber);

            user.Name = "Antek";
            user.Surname = "Pcimowski";
            user.Email = "a_pcimowski@gmail.com";
            user.Balance = 850;
            user.DateOfBirth = new DateTime(2015, 12, 26);
            user.PhoneNumber = 495039281;

            Assert.AreEqual("Antek", user.Name);
            Assert.AreEqual("Pcimowski", user.Surname);
            Assert.AreEqual("a_pcimowski@gmail.com", user.Email);
            Assert.AreEqual(850, user.Balance);
            Assert.AreEqual(new DateTime(2015, 12, 26), user.DateOfBirth);
            Assert.AreEqual(495039281, user.PhoneNumber);
        }
    }
}