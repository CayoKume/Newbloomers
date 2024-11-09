using System.Numerics;
using System.Text;

namespace IntegrationsCore.Domain.SqlBuilder
{
    /// <summary>
    /// _SqlBuilder: Assistente de construção de strings de TSQL, INSERT E UPDATE
    /// </summary>
    public class SqlBuilderTSql
    {
        #region VARIÁVEIS PRIVADAS

        /// <summary>
        /// Indica se devem adicionar o retorno da coluna identity no insert
        /// </summary>
        private string _scope_identity = string.Empty;

        /// <summary>
        /// Armazena os nomes das colunas a inserir no TSQL UPDATE / INSERT
        /// </summary>
        private List<string> ColumnNames { get; set; } = new List<string>();

        /// <summary>
        /// Armazena os valores da coluna a inserir no TSQL na clausula UPDATE / INSERT
        /// </summary>
        private List<string> ColumnValues { get; set; } = new List<string>();
        
        /// <summary>
        /// Armazena os nomes das colunas a serem inseridas na clausula WHERE
        /// </summary>
        private List<string> WhereNames { get; set; } = new List<string>();
        
        /// <summary
        /// Armazena os valores das colunas a serem inseridas na clausula WHERE
        /// </summary>
        private List<string> WhereValues { get; set; } = new List<string>();

        #endregion

        #region PROPRIEDADES PÚBLICAS
        /// <summary>
        /// Nome do database
        /// </summary>
        public string Database { get; set; } = "";
        /// <summary>
        /// Nome da tabela
        /// </summary>
        public string TableName { get; set; } = "";

        /// <summary>
        /// Último Sql Construído
        /// </summary>
        public string LastSql { get; protected set; } = "";

        #endregion

        #region CONSTRUTORES
        /// <summary>
        /// Construtor da classe , é necessário informar o database e a tabela para construir
        /// </summary>
        /// <param name="database">Nome do Banco de Dados</param>
        /// <param name="table">Tabela para construir o comando.</param>
        public SqlBuilderTSql(string database, string table) =>
            (TableName, Database) = (table, database);

        // Set, alterar database e tabela.
        public void SetConfig(string database, string table) =>
            (Database, TableName) = (database, table);

        #endregion
        
        #region MÉTODOS DE LIMPEZA
        /// <summary>
        /// Limpar construção, mantem o nome do database e da tabela, para continuar usando a mesma instancia entre os selects
        /// </summary>
        public void Clear()
        {
            ColumnNames.Clear();
            ColumnValues.Clear();
            WhereNames.Clear();
            WhereValues.Clear();
            _scope_identity = string.Empty;
            LastSql = string.Empty;
        }
        #endregion

        #region MÉTODOS GERADORES: Métodos que geram o comando TSQL
        /// <summary>
        /// Constroi um comando UPDATE, com os argumentos informados
        /// </summary>
        /// <returns></returns>
        public string BuildUpdateSqlCmd()
        {
            var sbSetUpdates = new StringBuilder();
            var sbWheres = new StringBuilder();

            for (int i = 0; i < ColumnNames.Count(); i++)
            {
                sbSetUpdates.Append(sbSetUpdates.Length > 0 ? " , " : " ");
                sbSetUpdates.Append($" {ColumnNames[i]} = {ColumnValues[i]}");
            }

            for (int i = 0; i < WhereNames.Count(); i++)
            {
                sbWheres.Append(i > 0 ? " AND " : " ");
                sbWheres.Append($" {WhereNames[i]} = {WhereValues[i]}");
            }

            return $" UPDATE {Database}.{TableName} SET {sbSetUpdates.ToString()} WHERE {sbWheres.ToString()} ";
        }

        /// <summary>
        /// Constroi um INSERT, com os argumentos informados
        /// </summary>
        /// <param name="_AddSelectScopeIdentity"></param>
        /// <returns></returns>
        public string BuildInsertSqlCmd(bool _AddSelectScopeIdentity = false)
        {
            var sbColumns = new StringBuilder();
            var sbValues = new StringBuilder();

            for (int i = 0; i < ColumnNames.Count(); i++)
            {
                string virgula = i > 0 ? " , " : " ";
                sbColumns.Append($" {virgula} [{ColumnNames[i]}] ");
                sbValues.Append($" {virgula} {ColumnValues[i]} ");
            }

            if (_AddSelectScopeIdentity)
                _scope_identity = " SELECT SCOPE_IDENTITY() as ID ";
            else
                _scope_identity = string.Empty;

            LastSql = $" INSERT INTO {Database}.{TableName}({sbColumns.ToString()}) VALUES({sbValues.ToString()}) {_scope_identity}";
            return LastSql;
        }
        #endregion

        #region ADD COLUMNS: Métodos que adicionam colunas 
        private void AddField(EnumSqlBuilderAddType tipo, string s_fieldName, string s_value)
        {
            if (s_value != null && s_value != string.Empty)
            {
                //s_value = s_value.Replace("'", "''");
            }
            if (tipo == EnumSqlBuilderAddType.set)
            {
                if (s_value != string.Empty)
                {
                    ColumnNames.Add(s_fieldName);
                    ColumnValues.Add(s_value);
                }
            }
            else if (tipo == EnumSqlBuilderAddType.where)
            {
                WhereNames.Add(s_fieldName);
                WhereValues.Add(s_value);
            }
        }
        public void Add(string fieldName, DateTime? pDateTimeValue
                , EnumSqlBuilderNullAction nullAction = EnumSqlBuilderNullAction.ignore
                , string defaultvalue = ""
                , EnumSqlBuilderAddType tipo = EnumSqlBuilderAddType.set)
        {
            string sValue = string.Empty;
            if (pDateTimeValue == null)
            {
                if (nullAction == EnumSqlBuilderNullAction.set_null)
                    sValue += " null ";
                else if (nullAction == EnumSqlBuilderNullAction.set_empty)
                    sValue += " '' ";
                else
                    sValue += "";
            }
            else
            {
                string sdate = pDateTimeValue.GetValueOrDefault().ToString("yyyyMMdd HH:mm:ss");
                sValue += $" '{sdate.ToString()}' ";
            }
            AddField(tipo, fieldName, sValue);
        }

        public void Add(string fieldName, string? pStringValue
                , EnumSqlBuilderNullAction nullAction = EnumSqlBuilderNullAction.ignore
                , string defaultvalue = ""
                , EnumSqlBuilderAddType tipo = EnumSqlBuilderAddType.set)
        {
            string sValue = string.Empty;
            if (pStringValue == null)
            {
                if (nullAction == EnumSqlBuilderNullAction.set_null)
                    sValue += " null ";
                else if (nullAction == EnumSqlBuilderNullAction.set_empty)
                    sValue += " '' ";
                else
                    sValue += "";
            }
            else
            {
                sValue += $" '{pStringValue.ToString()}' ";
            }
            AddField(tipo, fieldName, sValue);
        }

        public void Add(string fieldName, int? pIntValue
                , EnumSqlBuilderNullAction nullAction = EnumSqlBuilderNullAction.ignore
                , string defaultvalue = ""
                , EnumSqlBuilderAddType tipo = EnumSqlBuilderAddType.set)
        {
            string sValue = string.Empty;
            if (pIntValue == null)
            {
                if (nullAction == EnumSqlBuilderNullAction.set_null)
                    sValue += " null ";
                else if (nullAction == EnumSqlBuilderNullAction.set_empty)
                    sValue += " '' ";
                else
                    sValue += "";
            }
            else
            {
                sValue += $" {pIntValue.ToString()}";
            }
            AddField(tipo, fieldName, sValue);
        }
        
        public void Add(string fieldName, short? pIntValue
                , EnumSqlBuilderNullAction nullAction = EnumSqlBuilderNullAction.ignore
                , string defaultvalue = ""
                , EnumSqlBuilderAddType tipo = EnumSqlBuilderAddType.set)
        {
            string sValue = string.Empty;
            if (pIntValue == null)
            {
                if (nullAction == EnumSqlBuilderNullAction.set_null
                    || nullAction == EnumSqlBuilderNullAction.set_empty)
                    sValue += " null ";
                else if (nullAction == EnumSqlBuilderNullAction.set_default)
                    sValue += $" {defaultvalue} ";
            }
            else
            {
                sValue += $" {pIntValue.GetValueOrDefault().ToString()}";
            }
            AddField(tipo, fieldName, sValue);
        }
        
        public void Add(string fieldName, byte? pByteValue
                , EnumSqlBuilderNullAction nullAction = EnumSqlBuilderNullAction.ignore
                , string defaultvalue = ""
                , EnumSqlBuilderAddType tipo = EnumSqlBuilderAddType.set)
        {
            string sValue = string.Empty;
            if (pByteValue == null)
            {
                if (nullAction == EnumSqlBuilderNullAction.set_null)
                    sValue += " null ";
                else if (nullAction == EnumSqlBuilderNullAction.set_empty)
                    sValue += " '' ";
                else
                    sValue += "";
            }
            else
            {
                sValue += $" = {pByteValue.ToString()}";
            }
            AddField(tipo, fieldName, sValue);
        }
        
        public void Add(string fieldName, bool? pBoolValue
                , EnumSqlBuilderNullAction nullAction = EnumSqlBuilderNullAction.ignore
                , string defaultvalue = ""
                , EnumSqlBuilderAddType tipo = EnumSqlBuilderAddType.set)
        {
            string sValue = string.Empty;
            if (pBoolValue == null)
            {
                if (nullAction == EnumSqlBuilderNullAction.set_null
                    || nullAction == EnumSqlBuilderNullAction.set_empty)
                    sValue += " null ";
                else
                    sValue += "";
            }
            else
            {
                sValue += $" {Convert.ToByte(pBoolValue)}";
            }
            AddField(tipo, fieldName, sValue);
        }

        /// <summary>
        /// Adicionar Campos Onde Type é um addFieldType numérico por genéric
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldName"></param>
        /// <param name="pByteValue"></param>
        /// <param name="nullAction"></param>
        /// <param name="defaultvalue"></param>
        /// <param name="addFieldType"></param>
        public void AddNumericField<T>(string fieldName, T pNumberValue
                , T defaultvalue
                , EnumSqlBuilderNullAction nullAction = EnumSqlBuilderNullAction.ignore
                , EnumSqlBuilderAddType addFieldType = EnumSqlBuilderAddType.set)
            where T: ISignedNumber<T>, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T> 
        {
            string valString = string.Empty;
            if (pNumberValue != null)
                valString = pNumberValue.ToString();
            AddField(addFieldType, fieldName, valString);
        }

        /// <summary>
        /// Adicionar um campo enumerator com generico EnumType
        /// </summary>
        /// <typeparam name="EnumType">Informe o Tipo Enum do Campo a Adicionar</typeparam>
        /// <param name="fieldName">Nome do Campo</param>
        /// <param name="fieldValue">Informe o valor do campo entity</param>
        /// <param name="tipo">Tipo da ação, use set para insert e update </param>
        public void Add<EnumType>(string fieldName, EnumType fieldValue
                , EnumSqlBuilderAddType tipo = EnumSqlBuilderAddType.set)
            where EnumType : struct, IConvertible
        {
            short new_value = Convert.ToInt16(fieldValue);
            string sValue = $" {new_value.ToString()}";
            AddField(tipo, fieldName, sValue);
        }

        #endregion

    }
}