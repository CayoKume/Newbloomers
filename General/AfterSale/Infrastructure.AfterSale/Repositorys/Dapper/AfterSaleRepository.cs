using Dapper;
using Domain.AfterSale.Entites.Company;
using Domain.AfterSale.Entities;
using Domain.AfterSale.Interfaces.Repositorys;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Extensions;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

namespace Infrastructure.AfterSale.Repositorys.Dapper;

public class AfterSaleRepository : IAfterSaleRepository
{
    private readonly ISQLServerConnection? _sqlServerConnection;

    public AfterSaleRepository(ISQLServerConnection? sqlServerConnection) =>
            _sqlServerConnection = sqlServerConnection;

    public async Task<IEnumerable<Company>> GetCompanys()
    {
        string? sql = @$"SELECT DISTINCT
                     CNPJ_EMP AS DOC_COMPANY,
                     TOKEN
                     FROM GENERAL.PARAMETROS_AFTERSALE";

        using (var conn = _sqlServerConnection.GetIDbConnection())
        {
            return await conn.QueryAsync<Company>(sql);
        }
    }

    public async Task<Company> GetCompany(string cnpj_emp)
    {
        string? sql = @$"SELECT DISTINCT
                     CNPJ_EMP AS DOC_COMPANY,
                     TOKEN
                     FROM GENERAL.PARAMETROS_AFTERSALE
                     WHERE 
                     CNPJ_EMP = {cnpj_emp}";

        using (var conn = _sqlServerConnection.GetIDbConnection())
        {
            var result = await conn.QueryAsync<Company>(sql);

            return result.FirstOrDefault();
        }
    }

    public Task<bool> InsertIntoAfterSaleRefunds()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleRefundsActions()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleRefundsBanks()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleRefundsStatus()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleRefundsTypes()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> InsertIntoAfterSaleReverses(List<Domain.AfterSale.Entities.Data> data)
    {
        var reversesTable = CreateSystemDataTable(new ReverseComplete(), "AfterSaleReverses");
        var customerTable = CreateSystemDataTable(new CustomerComplete(), "AfterSaleCustomer");
        var addressTable = CreateSystemDataTable(new Address(), "AfterSaleAddress");
        var trackingHistoryTable = CreateSystemDataTable(new TrackingHistory(), "AfterSaleReverseTrackings");

        for (int i = 0; i < data.Count; i++)
        {
            reversesTable.Rows.Add(data[i].reverse.id, data[i].reverse.reverse_type, data[i].reverse.reverse_type_name, data[i].reverse.created_at, data[i].reverse.updated_at, data[i].reverse.order_id, data[i].reverse.total_amount,
                data[i].reverse.returned_invoice, data[i].customer is not null ? data[i].customer.id : null, data[i].customer is not null ? data[i].customer.first_name : null, data[i].customer is not null ? data[i].customer.last_name : null, data[i].reverse.status_id, data[i].reverse.status is not null ? data[i].reverse.status.name : null, data[i].reverse.status is not null ? data[i].reverse.status.description : null,
                data[i].reverse.tracking is not null ? data[i].reverse.tracking.tracking_code : null, data[i].reverse.tracking is not null ? data[i].reverse.tracking.shipping_amount : null, data[i].reverse.tracking is not null ? data[i].reverse.refunds.Count : null, data[i].reverse.invoice, data[i].reverse.service_type_change);
        }

        try
        {
            using (var conn = _sqlServerConnection.GetDbConnection())
            {
                using var bulkCopy = new SqlBulkCopy(conn);
                //bulkCopy.DestinationTableName = $"[untreated].[{reversesTable.TableName}]";
                bulkCopy.DestinationTableName = $"[general].[{reversesTable.TableName}]";
                bulkCopy.BatchSize = reversesTable.Rows.Count;
                bulkCopy.BulkCopyTimeout = 360;
                foreach (DataColumn c in reversesTable.Columns)
                {
                    bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                }
                bulkCopy.WriteToServer(reversesTable);
            }

            return true;
        }
        catch (Exception ex)
        {
            throw new InternalException(
                stage: EnumStages.BulkInsertIntoTableRaw,
                error: EnumError.SQLCommand,
                level: EnumMessageLevel.Error,
                message: $"Error when trying to bulk insert records on table raw",
                exceptionMessage: ex.Message
            );
        }

        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleReversesCourierAttributes()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> InsertIntoAfterSaleReversesStatus(List<Status> statusReverses)
    {
        var statusReversesTable = CreateSystemDataTable(new Status(), "AfterSaleStatus");

        for (int i = 0; i < statusReverses.Count; i++)
        {
            statusReversesTable.Rows.Add(statusReverses[i].id, statusReverses[i].name, statusReverses[i].description);
        }

        try
        {
            using (var conn = _sqlServerConnection.GetDbConnection())
            {
                using var bulkCopy = new SqlBulkCopy(conn);
                //bulkCopy.DestinationTableName = $"[untreated].[{statusReversesTable.TableName}]";
                bulkCopy.DestinationTableName = $"[general].[{statusReversesTable.TableName}]";
                bulkCopy.BatchSize = statusReversesTable.Rows.Count;
                bulkCopy.BulkCopyTimeout = 360;
                foreach (DataColumn c in statusReversesTable.Columns)
                {
                    bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                }
                bulkCopy.WriteToServer(statusReversesTable);
            }

            return true;
        }
        catch (Exception ex)
        {
            throw new InternalException(
                stage: EnumStages.BulkInsertIntoTableRaw,
                error: EnumError.SQLCommand,
                level: EnumMessageLevel.Error,
                message: $"Error when trying to bulk insert records on table raw",
                exceptionMessage: ex.Message
            );
        }
    }

    public async Task<bool> InsertIntoAfterSaleReversesTransportations(Transportations transportations)
    {
        var transportationsTable = CreateSystemDataTable(new Transportations(), "AfterSaleTransportations");

        for (int i = 0; i < transportations.data.Count; i++)
        {
            transportationsTable.Rows.Add(transportations.data[i]);
        }

        try
        {
            using (var conn = _sqlServerConnection.GetDbConnection())
            {
                using var bulkCopy = new SqlBulkCopy(conn);
                //bulkCopy.DestinationTableName = $"[untreated].[{statusReversesTable.TableName}]";
                bulkCopy.DestinationTableName = $"[general].[{transportationsTable.TableName}]";
                bulkCopy.BatchSize = transportationsTable.Rows.Count;
                bulkCopy.BulkCopyTimeout = 360;
                foreach (DataColumn c in transportationsTable.Columns)
                {
                    bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                }
                bulkCopy.WriteToServer(transportationsTable);
            }

            return true;
        }
        catch (Exception ex)
        {
            throw new InternalException(
                stage: EnumStages.BulkInsertIntoTableRaw,
                error: EnumError.SQLCommand,
                level: EnumMessageLevel.Error,
                message: $"Error when trying to bulk insert records on table raw",
                exceptionMessage: ex.Message
            );
        }
    }

    private DataTable CreateSystemDataTable<TEntity>(TEntity entity, string tableName)
    {
        try
        {
            var properties = entity.GetType().GetFilteredProperties();
            var dataTable = new DataTable(tableName);
            foreach (PropertyInfo prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            return dataTable;
        }
        catch (Exception ex)
        {
            throw new InternalException(
                stage: EnumStages.CreateSystemDataTable,
                error: EnumError.SQLCommand,
                level: EnumMessageLevel.Error,
                message: $"Error when convert system datatable to bulkinsert",
                exceptionMessage: ex.Message
            );
        }
    }
}