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
        int userId = 1;

        await _dataRepository.AddUserAsync(userId, "John", "m_gapcio@gmail.com", 21, new DateTime(2015, 12, 25));

        IUser user = await _dataRepository.GetUserAsync(userId);

        Assert.IsNotNull(user);
        Assert.AreEqual(userId, user.Id);
        Assert.AreEqual("John", user.Nickname);
        Assert.AreEqual("m_gapcio@gmail.com", user.Email);
        Assert.AreEqual(21, user.Balance);
        Assert.AreEqual(new DateTime(2015, 12, 25), user.DateOfBirth);

        Assert.IsNotNull(await _dataRepository.GetAllUsersAsync());
        Assert.IsTrue(await _dataRepository.GetUsersCountAsync() > 0);

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetUserAsync(userId + 2));

        await _dataRepository.UpdateUserAsync(userId, "Tom", "t_pokot@gmail.com", 301, new DateTime(2015, 12, 12));

        IUser userUpdated = await _dataRepository.GetUserAsync(userId);

        Assert.IsNotNull(userUpdated);
        Assert.AreEqual(userId, userUpdated.Id);
        Assert.AreEqual("Tom", userUpdated.Nickname);
        Assert.AreEqual("t_pokot@gmail.com", userUpdated.Email);
        Assert.AreEqual(301, userUpdated.Balance);
        Assert.AreEqual(new DateTime(2015, 12, 12), userUpdated.DateOfBirth);

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateUserAsync(userId + 2,
            "Tom", "t_pokot@gmail.com", 301, new DateTime(2015, 12, 12)));

        await _dataRepository.DeleteUserAsync(userId);
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetUserAsync(userId));
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteUserAsync(userId));
    }

    [TestMethod]
    public async Task ProductTests()
    {
        int productId = 2;

        await _dataRepository.AddProductAsync(productId, "Assassin's Creed Valhalla", 240, 18);

        IProduct product = await _dataRepository.GetProductAsync(productId);

        Assert.IsNotNull(product);
        Assert.AreEqual(productId, product.Id);
        Assert.AreEqual("Assassin's Creed Valhalla", product.Name);
        Assert.AreEqual(240, product.Price);
        Assert.AreEqual(18, product.Pegi);

        Assert.IsNotNull(await _dataRepository.GetAllProductsAsync());
        Assert.IsTrue(await _dataRepository.GetProductsCountAsync() > 0);

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetProductAsync(12));

        await _dataRepository.UpdateProductAsync(productId, "Cyberpunk 2077", 300, 15);

        IProduct productUpdated = await _dataRepository.GetProductAsync(productId);

        Assert.IsNotNull(productUpdated);
        Assert.AreEqual(productId, productUpdated.Id);
        Assert.AreEqual("Cyberpunk 2077", productUpdated.Name);
        Assert.AreEqual(300, productUpdated.Price);
        Assert.AreEqual(15, productUpdated.Pegi);

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateProductAsync(12, "Cyberpunk 2077", 300, 15));

        await _dataRepository.DeleteProductAsync(productId);
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetProductAsync(productId));
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteProductAsync(productId));
    }

    [TestMethod]
    public async Task StateTests()
    {
        int productId = 3;
        int stateId = 3;

        await _dataRepository.AddProductAsync(productId, "Assassin's Creed Valhalla", 240, 18);

        IProduct product = await _dataRepository.GetProductAsync(productId);

        await _dataRepository.AddStateAsync(stateId, productId, 12);

        IState state = await _dataRepository.GetStateAsync(stateId);

        Assert.IsNotNull(state);
        Assert.AreEqual(stateId, state.Id);
        Assert.AreEqual(productId, state.productId);
        Assert.AreEqual(12, state.productQuantity);

        Assert.IsNotNull(await _dataRepository.GetAllStatesAsync());
        Assert.IsTrue(await _dataRepository.GetStatesCountAsync() > 0);

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetStateAsync(stateId + 2));

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.AddStateAsync(stateId, 13, 12));

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.AddStateAsync(stateId, productId, -1));

        await _dataRepository.UpdateStateAsync(stateId, productId, 9);

        IState stateUpdated = await _dataRepository.GetStateAsync(stateId);

        Assert.IsNotNull(stateUpdated);
        Assert.AreEqual(stateId, stateUpdated.Id);
        Assert.AreEqual(productId, stateUpdated.productId);
        Assert.AreEqual(9, stateUpdated.productQuantity);

        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateStateAsync(stateId + 2, productId, 12));
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateStateAsync(stateId, 13, 12));
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateStateAsync(stateId, productId, -12));

        await _dataRepository.DeleteStateAsync(stateId);
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetStateAsync(stateId));
        await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteStateAsync(stateId));

        await _dataRepository.DeleteProductAsync(productId);
    }

    [TestMethod]
    public async Task EventTests()
    {
        int purchaseEventId = 4;
        int userId = 4;
        int productId = 4;
        int stateId = 4;

        await _dataRepository.AddProductAsync(productId, "Assassin's Creed Valhalla", 240, 18);
        await _dataRepository.AddStateAsync(stateId, productId, 12);
        await _dataRepository.AddUserAsync(userId, "John", "m_gapcio@gmail.com", 21, new DateTime(2015, 12, 25));

        IProduct product = await _dataRepository.GetProductAsync(productId);
        IState state = await _dataRepository.GetStateAsync(stateId);
        IUser user = await _dataRepository.GetUserAsync(userId);

        await _dataRepository.AddEventAsync(purchaseEventId, stateId, userId, "PurchaseEvent");

        IEvent purchaseEvent = await _dataRepository.GetEventAsync(purchaseEventId, "PurchaseEvent");

        Assert.IsNotNull(purchaseEvent);
        Assert.AreEqual(purchaseEventId, purchaseEvent.Id);
        Assert.AreEqual(stateId, purchaseEvent.stateId);
        Assert.AreEqual(userId, purchaseEvent.userId);

        Assert.IsNotNull(await _dataRepository.GetAllEventsAsync());
        Assert.IsTrue(await _dataRepository.GetEventsCountAsync() > 0);

        await _dataRepository.UpdateEventAsync(purchaseEventId, stateId, userId, "PurchaseEvent", null);

        IEvent eventUpdated = await _dataRepository.GetEventAsync(purchaseEventId, "PurchaseEvent");

        Assert.IsNotNull(eventUpdated);
        Assert.AreEqual(purchaseEventId, eventUpdated.Id);
        Assert.AreEqual(stateId, eventUpdated.stateId);
        Assert.AreEqual(userId, eventUpdated.userId);

        await _dataRepository.DeleteEventAsync(purchaseEventId);
        await _dataRepository.DeleteStateAsync(stateId);
        await _dataRepository.DeleteProductAsync(productId);
        await _dataRepository.DeleteUserAsync(userId);
    }
}
