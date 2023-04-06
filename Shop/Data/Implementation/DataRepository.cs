namespace Shop.Data
{
    public class DataRepository : IDataRepository
    {
        public DataRepository(IDataContext context) {
            this.context = context;
        }

        private IDataContext context;

        public void Add<T>(T element) where T : IElement {
            var ContextElements = this.context.Elements[typeof(T)];

            if (!ContextElements.ContainsKey(element.Guid))
                ContextElements.Add(element.Guid, element);
            else
                throw new Exception("This " + typeof(T).Name.Substring(1) + " already exists!");
        }

        public T Get<T>(string Guid) where T : IElement {
            var ContextElements = this.context.Elements[typeof(T)];

            if (ContextElements.ContainsKey(Guid))
                return (T)ContextElements[Guid];
            else
                throw new Exception("This " + typeof(T).Name.Substring(1) + " does not exist!");
        }

        public void Update<T>(string Guid, T element) where T : IElement {
            var ContextElements = this.context.Elements[typeof(T)];

            if (ContextElements.ContainsKey(Guid))
                ContextElements[Guid] = element;
            else
                throw new Exception("This " + typeof(T).Name.Substring(1) + " does not exist!");
        }

        public void Delete<T>(string Guid) where T : IElement {
            var ContextElements = this.context.Elements[typeof(T)];

            if (ContextElements.ContainsKey(Guid))
                ContextElements.Remove(Guid);
            else
                throw new Exception("This " + typeof(T).Name.Substring(1) + " does not exist!");
        }

        public Dictionary<string, T> GetAll<T>() where T : IElement {
            var ContextElements = (Dictionary<string, T>)this.context.Elements[typeof(T)];

            return ContextElements;
        }

        public int GetCount<T>() where T : IElement {
            var ContextElements = this.context.Elements[typeof(T)];

            return ContextElements.Count();
        }

        public IEvent GetLastProductEvent(string ProductGuid) {
            IEvent? LastEvent = null;

            Dictionary<string, IEvent>.ValueCollection Events = 
                ((Dictionary<string, IEvent>)this.context.Elements[typeof(IEvent)]).Values;

            foreach (IEvent Event in Events)
                if (Event.State.Product.Guid == ProductGuid)
                    if (LastEvent is not null && LastEvent.OccurrenceDate < Event.OccurrenceDate)
                        LastEvent = Event;

            if (LastEvent is null)
                throw new Exception("There have been no Events for this Product!");

            return LastEvent;
        }

        public List<IEvent> GetProductEventHistory(string ProductGuid) {
            List<IEvent> History = new List<IEvent>();

            Dictionary<string, IEvent>.ValueCollection Events =
                ((Dictionary<string, IEvent>)this.context.Elements[typeof(IEvent)]).Values;

            foreach (IEvent Event in Events)
                if (Event.State.Product.Guid == ProductGuid)
                    History.Add(Event);

            return History;
        }

        public IState GetProductState(string ProductGuid) {
            if (this.context.Elements[typeof(IState)].ContainsKey(ProductGuid))
                return (IState)this.context.Elements[typeof(IState)][ProductGuid];
            else
                throw new Exception("There is no State for this Product!");
        }
    }
}
