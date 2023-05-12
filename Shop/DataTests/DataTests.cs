using Data.API;
using System.Runtime.Intrinsics.X86;

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

    [TestMethod]
    public async Task ProductTests()
    {
        int productId = 1;

        await _dataRepository.AddProductAsync("Assassin's Creed Valhalla", 240, 18);

        IProduct product = await _dataRepository.GetProductAsync(productId);

        Assert.IsNotNull(product);
        Assert.AreEqual(productId, product.Id);
        Assert.AreEqual("Assassin's Creed Valhalla", product.Name);
        Assert.AreEqual(240, product.Price);
        Assert.AreEqual(18, product.Pegi);

        Assert.IsNotNull(await _dataRepository.GetAllProductsAsync());
        Assert.IsTrue(await _dataRepository.GetProductsCountAsync() > 0);

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetProductAsync(productId + 2));

        await _dataRepository.UpdateProductAsync(productId, "Cyberpunk 2077", 300, 15);

        IProduct productUpdated = await _dataRepository.GetProductAsync(productId);

        Assert.IsNotNull(productUpdated);
        Assert.AreEqual(productId, productUpdated.Id);
        Assert.AreEqual("Cyberpunk 2077", productUpdated.Name);
        Assert.AreEqual(300, productUpdated.Price);
        Assert.AreEqual(15, productUpdated.Pegi);

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateProductAsync(productId + 2, "Cyberpunk 2077", 300, 15));

        await _dataRepository.DeleteProductAsync(productId);
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetProductAsync(productId));
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteProductAsync(productId));
    }
}
