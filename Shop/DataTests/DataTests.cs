using Data.API;

namespace DataTests;

[TestClass]
public class DataTests
{
    private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase();

    [TestMethod]
    public async Task UserTests()
    {
        //int lastId = (await _dataRepository.GetAllUsersAsync()).Keys.MaxBy(k => k);
        int user1 = 1;

        await _dataRepository.AddUserAsync("John", "m_gapcio@gmail.com", 21, new DateTime(2015, 12, 25));

        IUser user = await _dataRepository.GetUserAsync(user1);

        Assert.IsNotNull(user);
        Assert.AreEqual(user1, user.Id);
        Assert.AreEqual("John", user.Nickname);
        Assert.AreEqual("m_gapcio@gmail.com", user.Email);
        Assert.AreEqual(21, user.Balance);
        Assert.AreEqual(new DateTime(2015, 12, 25), user.DateOfBirth);

        Assert.IsNotNull(await _dataRepository.GetAllUsersAsync());
        Assert.IsTrue(await _dataRepository.GetUsersCountAsync() > 0);

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetUserAsync(user1 + 2));

        await _dataRepository.UpdateUserAsync(user1, "Tom", "t_pokot@gmail.com", 301, new DateTime(2015, 12, 12));

        IUser userUpdated = await _dataRepository.GetUserAsync(user1);

        Assert.IsNotNull(userUpdated);
        Assert.AreEqual(user1, userUpdated.Id);
        Assert.AreEqual("Tom", userUpdated.Nickname);
        Assert.AreEqual("t_pokot@gmail.com", userUpdated.Email);
        Assert.AreEqual(301, userUpdated.Balance);
        Assert.AreEqual(new DateTime(2015, 12, 12), userUpdated.DateOfBirth);

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateUserAsync(user1 + 2,
            "Tom", "t_pokot@gmail.com", 301, new DateTime(2015, 12, 12)));

        await _dataRepository.DeleteUserAsync(user1);
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetUserAsync(user1));
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteUserAsync(user1));
    }
}
