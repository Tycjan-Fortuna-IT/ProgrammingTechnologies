using System.Collections.Generic;

namespace Shop.Data
{
    public abstract class IDataContext
    {
        Dictionary<string, IUser> Users = new Dictionary<string, IUser>();

        Dictionary<string, IProduct> Products = new Dictionary<string, IProduct>();

        Dictionary<string, IEvent> Events = new Dictionary<string, IEvent>();
        
        Dictionary<string, IState> States = new Dictionary<string, IState>();

        public Dictionary<Type, IDictionary<string, IElement>> Elements = new Dictionary<Type, IDictionary<string, IElement>>
        {
            { typeof(IUser), new Dictionary<string, IElement>() },
            { typeof(IProduct), new Dictionary<string, IElement>() },
            { typeof(IEvent), new Dictionary<string, IElement>() },
            { typeof(IState), new Dictionary<string, IElement>() }
        };
    }
}
