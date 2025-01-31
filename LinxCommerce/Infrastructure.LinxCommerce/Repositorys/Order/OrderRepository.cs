using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Repositorys.Base;
using Domain.LinxCommerce.Interfaces.Repositorys.Order;
using System.ComponentModel;
using System.Data;

namespace Infrastructure.LinxCommerce.Repositorys.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ILinxCommerceRepositoryBase _linxCommerceRepositoryBase;

        public OrderRepository(ILinxCommerceRepositoryBase linxCommerceRepositoryBase) =>
            _linxCommerceRepositoryBase = linxCommerceRepositoryBase;

        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Domain.LinxCommerce.Entities.Order.Order> records, string? database)
        {
            try
            {
                var table = CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.Order());

                for (int i = 0; i < records.Count(); i++)
                {
                    //table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cod_cliente, records[i].razao_cliente, records[i].nome_cliente, records[i].doc_cliente,
                    //    records[i].tipo_cliente, records[i].endereco_cliente, records[i].numero_rua_cliente, records[i].complement_end_cli, records[i].bairro_cliente, records[i].cep_cliente,
                    //    records[i].cidade_cliente, records[i].uf_cliente, records[i].pais, records[i].fone_cliente, records[i].email_cliente, records[i].sexo, records[i].data_cadastro,
                    //    records[i].data_nascimento, records[i].cel_cliente, records[i].ativo, records[i].dt_update, records[i].inscricao_estadual, records[i].incricao_municipal, records[i].identidade_cliente,
                    //    records[i].cartao_fidelidade, records[i].cod_ibge_municipio, records[i].classe_cliente, records[i].matricula_conveniado, records[i].tipo_cadastro, records[i].empresa_cadastro, records[i].id_estado_civil,
                    //    records[i].fax_cliente, records[i].site_cliente, records[i].timestamp, records[i].cliente_anonimo, records[i].limite_compras, records[i].codigo_ws, records[i].limite_credito_compra, records[i].id_classe_fiscal,
                    //    records[i].obs, records[i].mae);
                }

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobParameter: jobParameter,
                    dataTable: table,
                    dataTableRowsNumber: table.Rows.Count
                );

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Domain.LinxCommerce.Entities.Order.Order>> GetRegistersExists(List<string> registros)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var identificadores = String.Empty;
            //    for (int i = 0; i < registros.Count(); i++)
            //    {
            //        if (i == registros.Count() - 1)
            //            identificadores += $"'{registros[i]}'";
            //        else
            //            identificadores += $"'{registros[i]}', ";
            //    }

            //    string sql = $"SELECT cod_cliente, DOC_CLIENTE, TIMESTAMP FROM [linx_microvix_erp].[LinxClientesFornec] WHERE DOC_CLIENTE IN ({identificadores})";

            //    return await _linxMicrovixRepositoryBase.GetRegistersExists(jobParameter, sql);
            //}
            //catch (Exception ex) when (ex is not InternalException && ex is not SQLCommandException)
            //{
            //    throw new InternalException(
            //        stage: EnumStages.GetRegistersExists,
            //        error: EnumError.Exception,
            //        level: EnumMessageLevel.Error,
            //        message: "Error when filling identifiers to sql command",
            //        exceptionMessage: ex.Message
            //    );
            //}
            //catch
            //{
            //    throw;
            //}
        }

        public DataTable CreateSystemDataTable<TEntity>(LinxCommerceJobParameter jobParameter, TEntity entity)
        {
            try
            {
                var properties = TypeDescriptor.GetProperties(typeof(TEntity));
                var dataTable = new DataTable(jobParameter.tableName);
                foreach (PropertyDescriptor prop in properties)
                {
                    dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
