using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Responses;
using Domain.LinxCommerce.Interfaces.Repositorys;
using System.ComponentModel;
using System.Data;

namespace Infrastructure.LinxCommerce.Repositorys
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly ILinxCommerceRepositoryBase _linxCommerceRepositoryBase;

        public OrderStatusRepository(ILinxCommerceRepositoryBase linxCommerceRepositoryBase) =>
            _linxCommerceRepositoryBase = linxCommerceRepositoryBase;

        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, SearchOrderStatus.Root records)
        {
            try
            {
                var table = CreateSystemDataTable(jobParameter, new SearchOrderStatus.Result());

                for (int i = 0; i < records.Result.Count(); i++)
                {
                    table.Rows.Add(records.Result[i].OrderStatusID, records.Result[i].Status, records.Result[i].Color, records.Result[i].IsDefault, records.Result[i].IntegrationID);
                }

                //_linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                //    jobParameter: jobParameter,
                //    dataTable: table,
                //    dataTableRowsNumber: table.Rows.Count
                //);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Domain.LinxCommerce.Entities.Order.Order>> GetRegistersExists(List<string> registros, string? database)
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
            //catch (Exception ex) when (ex is not GeneralException && ex is not SQLCommandException)
            //{
            //    throw new GeneralException(
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
