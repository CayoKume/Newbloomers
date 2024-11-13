using System.Numerics;
using System.Text;

namespace Domain.IntegrationsCore.SqlBuilder
{

    /// <summary>
    /// Enum para o addFieldType de adição, se é um item de Insert/Update ou um Where.
    /// </summary>
    public enum EnumSqlBuilderAddType
    {
        set = 0,
        where = 1
    }
}