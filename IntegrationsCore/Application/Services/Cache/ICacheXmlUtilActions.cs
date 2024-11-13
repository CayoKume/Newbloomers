namespace IntegrationsCore.Application.Services.Cache
{
    public interface ICacheXmlUtilActions
    {
        public abstract string GetKeyInDictionary(IDictionary<string, string> dictionaryFields);
        public void AddCacheXml(string key, string xml);
    }
}
