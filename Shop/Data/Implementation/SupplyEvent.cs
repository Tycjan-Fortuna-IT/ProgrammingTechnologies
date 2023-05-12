using Data.API;

namespace Data.Implementation;

internal class SupplyEvent : IEvent
{
    public SupplyEvent(int id, int stateId, int userId, DateTime occurrenceDate, int quantity)
    {
        this.Id = id;
        this.stateId = stateId;
        this.userId = userId;
        this.quantity = quantity;
        this.occurrenceDate = occurrenceDate;
    }

    public int Id { get; set; }

    public int stateId { get; set; }

    public int userId { get; set; }

    public DateTime occurrenceDate { get; set; }

    public int quantity { get; set; }

    public async Task Action(IDataRepository dataRepository)
    {
        IState state = await dataRepository.GetStateAsync(stateId);
        IProduct product = await dataRepository.GetProductAsync(state.productId);

        if (quantity <= 0)
            throw new Exception("Can not supply with this amount!");

        await dataRepository.UpdateStateAsync(stateId, product.Id, state.productQuantity + quantity);
    }
}
