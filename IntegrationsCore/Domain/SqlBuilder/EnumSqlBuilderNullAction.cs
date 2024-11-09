using System.Numerics;
using System.Text;

namespace IntegrationsCore.Domain.SqlBuilder
{
    /// <summary>
    /// Enum para determinar o comportamento da coluna adicionada, se forçar nulo ou ignorar
    /// ignorar é a melhor opção para updates, para otimizar o processamento.
    /// fazendo update somente nas colunas necessárias.
    /// </summary>
    public enum EnumSqlBuilderNullAction
    {
        ignore = 0,
        set_null = 1,
        set_empty = 2,
        set_default = 3,
    }
}