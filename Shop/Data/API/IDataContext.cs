using System.Collections.Generic;

namespace Shop.Data
{
    public abstract class IDataContext
    {
        public Dictionary<Type, IDictionary<string, IElement>> Elements = new Dictionary<Type, IDictionary<string, IElement>>
        {
            { typeof(IUser), new Dictionary<string, IElement>() },
            { typeof(IProduct), new Dictionary<string, IElement>() },
            { typeof(IEvent), new Dictionary<string, IElement>() },
            { typeof(IState), new Dictionary<string, IElement>() }
        };
    }
}