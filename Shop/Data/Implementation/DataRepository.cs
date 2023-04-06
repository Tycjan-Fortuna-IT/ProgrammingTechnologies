namespace Shop.Data
{
    public class DataRepository : IDataRepository
    {
        public DataRepository(IDataContext context) {
            this.context = context;
        }

        private IDataContext context;

        public void Add<T>(T element) where T : IElement {
            if (!this.context.Elements[typeof(T)].ContainsKey(element.Guid))
            {
                this.context.Elements[typeof(T)].Add(element.Guid, element);
            }
            else
            {
                throw new Exception("This " + typeof(T).Name.Substring(1) + " already exists!");
            }
        }

        public T Get<T>(string Guid) where T : IElement {
            if (this.context.Elements[typeof(T)].ContainsKey(Guid))
            {
                return (T)this.context.Elements[typeof(T)][Guid];
            }
            else
            {
                throw new Exception("This " + typeof(T).Name.Substring(1) + " does not exist!");
            }
        }

        public void Update<T>(string Guid, T element) where T : IElement {
            if (this.context.Elements[typeof(T)].ContainsKey(Guid))
            {
                this.context.Elements[typeof(T)][Guid] = element;
            }
            else
            {
                throw new Exception("This " + typeof(T).Name.Substring(1) + " does not exist!");
            }
        }

        public void Delete<T>(string Guid) where T : IElement {
            if (this.context.Elements[typeof(T)].ContainsKey(Guid))
            {
                this.context.Elements[typeof(T)].Remove(Guid);
            }
            else
            {
                throw new Exception("This " + typeof(T).Name.Substring(1) + " does not exist!");
            }
        }

        public Dictionary<string, T> GetAll<T>() where T : IElement {
            return (Dictionary<string, T>)this.context.Elements[typeof(T)];
        }

        public int GetCount<T>() where T : IElement {
            return this.context.Elements[typeof(T)].Count();
        }
    }
}
