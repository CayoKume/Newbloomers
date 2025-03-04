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

namespace Domain.AfterSale.Interfaces;

public class AfterSaleRepository : IAfterSaleRepository
{
    private readonly ISQLServerConnection? _sqlServerConnection;

    public AfterSaleRepository(ISQLServerConnection? sqlServerConnection) =>
            (_sqlServerConnection) = (sqlServerConnection);

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

    public Task<bool> InsertIntoAfterSaleReverses()
    {
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

    public Task<bool> InsertIntoAfterSaleReversesTransportations()
    {
        throw new NotImplementedException();
    }

    private  DataTable CreateSystemDataTable<TEntity>(TEntity entity, string tableName)
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
