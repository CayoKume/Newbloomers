namespace Application.Core.Interfaces
{
    public interface ICacheService<TEntity> : ICacheBase where TEntity : class
    {
        #region ADD: M�todos para adicionar ao cache
        public void Add(TEntity entity);
        public void AddList(IList<TEntity> pListEntities);
        #endregion

        #region GET: M�todos para recuperar item ou chave.
        public string GetKey(TEntity entity);
        public new abstract string GetKeyInDictionary(IDictionary<string, string> dictionaryFields);

        public new void AddCacheXml(string key, string xml);

        public IDictionary<string, string> GetDictionaryXml();
        public IList<string> GetKeys(IList<TEntity> lEntities);
        public IList<TEntity> GetList();
        public TEntity? Get(string pKey);
        #endregion

        #region CONTAINS: M�todos para verificar
        public bool ContainsKey(string pKey);
        public bool ContainsEntity(TEntity entity);
        public string[] ContainsKeys(string[] keys);
        #endregion

        #region FILTER: M�todos para filtrar
        public IList<TEntity> FiltrarList(IList<TEntity> pListEntities);
        #endregion region

    }
}

