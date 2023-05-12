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

    public void Action(IDataRepository dataRepository)
    {
        //IUser user = dataRepository.GetUser(this.userGuid);
        //IState state = dataRepository.GetState(this.stateGuid);
        //IProduct product = dataRepository.GetProduct(state.productGuid);

        //if (!user.productLibrary.ContainsKey(product.guid))
        //    throw new Exception("You do not have this Product!");

        //state.productQuantity++;
        //user.balance += product.price;
        //user.productLibrary.Remove(product.guid);
    }
}
