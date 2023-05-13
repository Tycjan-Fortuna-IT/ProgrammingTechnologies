using Data.API;

namespace Data.Implementation;

internal class ReturnEvent : IEvent
{
    public ReturnEvent(int id, int stateId, int userId, DateTime occurrenceDate)
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

        Dictionary<int, IEvent> events = await dataRepository.GetAllEventsAsync();
        Dictionary<int, IState> states = await dataRepository.GetAllStatesAsync();

        int copiesBought = 0;

        foreach 
        (
            IEvent even in 
                 from even in events.Values 
                 from stat in states.Values 
                    where even.userId == user.Id &&
                          even.stateId == stat.Id && 
                          stat.productId == product.Id 
                 select even
        )
            if (even is PurchaseEvent)
                copiesBought++;
            else if (even is ReturnEvent)
                copiesBought--;

        copiesBought--;

        if (copiesBought < 0)
            throw new Exception("You do not own this product!");

        await dataRepository.UpdateStateAsync(stateId, product.Id, state.productQuantity + 1);
        await dataRepository.UpdateUserAsync(userId, user.Nickname, user.Email, user.Balance + product.Price, user.DateOfBirth);
    }
}
