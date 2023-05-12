using Data.API;

namespace Data.Implementation;

internal class PurchaseEvent : IEvent
{
    public PurchaseEvent(int id, int stateId, int userId, DateTime occurrenceDate) 
    {
        this.Id = id;
        this.stateId = stateId;
        this.userId = userId;
        this.occurrenceDate = occurrenceDate;
    }

    public int Id { get; set; }

    public int stateId { get; set; }

    public int userId { get; set; }

    public DateTime occurrenceDate { get; set; }

    public async Task Action(IDataRepository dataRepository) 
    {
        IUser user = await dataRepository.GetUserAsync(userId);
        IState state = await dataRepository.GetStateAsync(stateId);
        IProduct product = await dataRepository.GetProductAsync(state.productId);

        if (DateTime.Now.Year - user.DateOfBirth.Year < product.Pegi)
            throw new Exception("You are not old enough to purchase this game!");

        if (state.productQuantity == 0)
            throw new Exception("Product unavailable, please check later!");

        if (user.Balance < product.Price)
            throw new Exception("Not enough money to purchase this product!");

        await dataRepository.UpdateStateAsync(stateId, product.Id, state.productQuantity - 1);
        await dataRepository.UpdateUserAsync(userId, user.Nickname, user.Email, user.Balance - product.Price, user.DateOfBirth);
    }
}
