using Application.Core.Interfaces;

namespace Application.Core.Services
{
    /// <summary>
    /// Classe Para Auxiliar o Armazenamento Em Memória dos dados de Entity (Model de Registro de Dados)
    /// para auxiliar no processo de integração, guardando registros em memória.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class CacheService<TEntity> : IDisposable, ICacheService<TEntity>, ICacheBase where TEntity : class
    {
        private IList<TEntity> _list = new List<TEntity>();
        private Dictionary<string, int> _dictionary_index = new();
        private Dictionary<string, string> _dictionary_cache_xml = new();

        #region ADD: Métodos para adicionar ao cache
        public void Add(TEntity entity)
        {
            var key = GetKey(entity);
            if (!_dictionary_index.ContainsKey(key))
            {
                _list.Add(entity);
                _dictionary_index.Add(key, _list.Count() - 1);
            }
        }

        /// <summary>
        /// Adicionar lista ao cache, para cachear as chaves, e assim poder verificar as chaves recebidas.
        /// </summary>
        /// <param name="pListEntities">Informe a lista a ser adicionada.</param>
        public void AddList(IList<TEntity> pListEntities)
        {
            if (pListEntities == null)
                return;

            for (int i = 0; i < pListEntities.Count; i++)
            {
                Add(pListEntities[i]);
            }
        }

        #endregion

        public abstract string GetKey(TEntity entity);
        public abstract string GetKeyInDictionary(IDictionary<string, string> dictionaryFields);
        public IDictionary<string, string> GetDictionaryXml()
        {
            return _dictionary_cache_xml;
        }
        public void AddCacheXml(string key, string xml)
        {
            if (!_dictionary_cache_xml.ContainsKey(key))
                _dictionary_cache_xml.Add(key, xml);
        }

        public IList<string> GetKeys(IList<TEntity> lEntities)
        {
            IList<string> lkeys = new List<string>();
            for (int i = 0; i < lEntities.Count; i++)
            {
                lkeys.Add(GetKey(lEntities[i]));
            }
            return lkeys;
        }

        public void SetKeys(string[] pKeys)
        {
            for (int i = 0; i < pKeys.Length; i++)
            {

            }
        }
        public IList<TEntity> GetList()
        {
            IList<TEntity> newList = new List<TEntity>();
            for (int i = 0; i < _list.Count; i++)
            {
                newList.Add(_list[i]);
            }
            return newList;
        }



        /// <summary>
        // Retornar somente novos registros.
        /// Forneça uma lista do mesmo tipo. A lista em memória, armazenada, será usada
        /// para filtrar a lista enviada.
        /// Retornando, somente com registros que não existem na lista enviada pListReceived
        /// </summary>
        /// <param name="pListReceived">Lista recebida, cheia do EndPoint à ser filtrada.</param>
        /// <returns>retorna lista filtrada.</returns>
        public IList<TEntity> FiltrarList(IList<TEntity> pListReceived)
        {
            IList<TEntity> newFilteredList = new List<TEntity>();
            for (int i = 0; i < pListReceived.Count; i++)
            {
                if (!ContainsEntity(pListReceived[i]))
                    newFilteredList.Add(pListReceived[i]);
            }
            return newFilteredList;
        }

        public TEntity? Get(string pKey)
        {
            if (_dictionary_index.ContainsKey(pKey))
                return _list[_dictionary_index[pKey]];

            return null;
        }
        public bool ContainsKey(string pKey)
        {
            return _dictionary_index.ContainsKey(pKey);
        }
        public bool ContainsEntity(TEntity entity)
        {
            string key = GetKey(entity);
            return _dictionary_index.ContainsKey(key);
        }

        public string[] ContainsKeys(string[] keys)
        {
            IList<string> listNotFoundKeys = new List<string>();
            for (int i = 0; i < keys.Length; i++)
            {
                if (!_dictionary_index.ContainsKey(keys[i]))
                {
                    listNotFoundKeys.Add(keys[i]);
                }
            }
            return listNotFoundKeys.ToArray();
        }


        public void Dispose()
        {
            _dictionary_index.Clear();
            _list.Clear();
        }
    }
}
