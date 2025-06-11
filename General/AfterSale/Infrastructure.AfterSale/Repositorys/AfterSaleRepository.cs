using Dapper;
using Domain.AfterSale.Interfaces.Repositorys;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Data;
using Domain.AfterSale.Entities;
using Reverse = Domain.AfterSale.Entities.Reverse;
using Domain.IntegrationsCore.Interfaces;

namespace Infrastructure.AfterSale.Repositorys;

public class AfterSaleRepository : IAfterSaleRepository
{
    private readonly ISQLServerConnection? _sqlServerConnection;
    private readonly IIntegrationsCoreRepository? _integrationsCoreRepository;

    public AfterSaleRepository(ISQLServerConnection? sqlServerConnection, IIntegrationsCoreRepository? integrationsCoreRepository) =>
            (_sqlServerConnection, _integrationsCoreRepository) = (sqlServerConnection, integrationsCoreRepository);

    public async Task<IEnumerable<Company>> GetCompanys()
    {
        string? sql = @$"SELECT DISTINCT
                     CNPJ_EMP AS DOC_COMPANY,
                     TOKEN AS TOKEN
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
        var reversesTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Reverse(), tableName: "AfterSaleReverses");
        var customerTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Customer(), tableName: "AfterSaleCustomers");
        var addressTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Address(), tableName: "AfterSaleAddresses");
        var trackingHistoryTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new TrackingHistory(), tableName: "AfterSaleTrackingHistories");

        try
        {
            _integrationsCoreRepository.FillSystemDataTable(reversesTable, data.Select(x => x.reverse).ToList());
            _integrationsCoreRepository.FillSystemDataTable(customerTable, data.Select(x => x.customer).ToList());
            _integrationsCoreRepository.FillSystemDataTable(addressTable, data.Select(x => x.customer.address).ToList());
            _integrationsCoreRepository.FillSystemDataTable(addressTable, data.Select(x => x.customer.shipping_address).ToList());
            _integrationsCoreRepository.FillSystemDataTable(trackingHistoryTable, data.SelectMany(x => x.tracking_history).ToList());

            _integrationsCoreRepository.BulkInsertIntoTableRaw(reversesTable);
            _integrationsCoreRepository.BulkInsertIntoTableRaw(customerTable);
            _integrationsCoreRepository.BulkInsertIntoTableRaw(addressTable);
            _integrationsCoreRepository.BulkInsertIntoTableRaw(trackingHistoryTable);

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

    public Task<bool> InsertIntoAfterSaleReversesCourierAttributes()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> InsertIntoAfterSaleStatus(List<Status> statusReverses)
    {
        var statusReversesTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Status(), tableName: "AfterSaleStatus");

        try
        {
            _integrationsCoreRepository.FillSystemDataTable(statusReversesTable, statusReverses);

            _integrationsCoreRepository.BulkInsertIntoTableRaw(statusReversesTable);

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

    public async Task<bool> InsertIntoAfterSaleTransportations(Transportations transportations)
    {
        var transportationsTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Transportations(), tableName: "AfterSaleTransportations");

        try
        {
            _integrationsCoreRepository.FillSystemDataTable(transportationsTable, transportations.data);

            _integrationsCoreRepository.BulkInsertIntoTableRaw(transportationsTable);

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

    public async Task<bool> InsertIntoAfterSaleTransportations(List<Transportations> transportations)
    {
        var transportationsTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Transportations(), tableName: "AfterSaleTransportations");

        try
        {
            _integrationsCoreRepository.FillSystemDataTable(transportationsTable, transportations);

            _integrationsCoreRepository.BulkInsertIntoTableRaw(transportationsTable);

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

    public async Task<bool> InsertIntoAfterSaleEcommerce(List<Ecommerce> data)
    {
        var ecommercesTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Ecommerce(), tableName: "AfterSaleEcommerces");
        var addressTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Address(), tableName: "AfterSaleAddresses");
        var reasonTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Reason(), tableName: "AfterSaleReasons");

        try
        {
            _integrationsCoreRepository.FillSystemDataTable(ecommercesTable, data);
            _integrationsCoreRepository.FillSystemDataTable(addressTable, data.Select(x => x.address).ToList());
            _integrationsCoreRepository.FillSystemDataTable(reasonTable, data.SelectMany(x => x.reasons).ToList());

            _integrationsCoreRepository.BulkInsertIntoTableRaw(ecommercesTable);
            _integrationsCoreRepository.BulkInsertIntoTableRaw(addressTable);
            _integrationsCoreRepository.BulkInsertIntoTableRaw(reasonTable);

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
}