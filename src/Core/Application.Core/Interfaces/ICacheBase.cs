namespace Application.Core.Interfaces
{
    public interface ICacheBase
    {
        public abstract string GetKeyInDictionary(IDictionary<string, string> dictionaryFields);
        public void AddCacheXml(string key, string xml);
    }
}

