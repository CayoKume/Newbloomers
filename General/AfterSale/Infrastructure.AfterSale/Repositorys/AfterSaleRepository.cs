using Dapper;
using Domain.AfterSale.Interfaces.Repositorys;
using Domain.IntegrationsCore.Entities.Exceptions;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Data;
using Domain.AfterSale.Entities;
using Reverse = Domain.AfterSale.Entities.Reverse;
using Domain.IntegrationsCore.Interfaces;
using Microsoft.Win32;

namespace Infrastructure.AfterSale.Repositorys;

public class AfterSaleRepository : IAfterSaleRepository
{
    private readonly ISQLServerConnection _sqlServerConnection;
    private readonly IIntegrationsCoreRepository _integrationsCoreRepository;

    public AfterSaleRepository(ISQLServerConnection sqlServerConnection, IIntegrationsCoreRepository integrationsCoreRepository) =>
            (_sqlServerConnection, _integrationsCoreRepository) = (sqlServerConnection, integrationsCoreRepository);

    public async Task<List<Reverse?>> GetReversesByIds(List<int?> reversesIds)
    {
        var list = new List<Reverse?>();
        string identificadores = String.Empty;
        int indice = reversesIds.Count() / 1000;

        if (indice > 1)
        {
            for (int i = 0; i <= indice; i++)
            {
                var top1000List = reversesIds.Skip(i * 1000).Take(1000).ToList();

                for (int j = 0; j < top1000List.Count(); j++)
                {

                    if (j == top1000List.Count() - 1)
                        identificadores += $"'{top1000List[j]}'";
                    else
                        identificadores += $"'{top1000List[j]}', ";
                }

                string sql = $"SELECT ID, UPDATED_AT FROM [GENERAL].[AFTERSALEREVERSES] WHERE ID IN ({identificadores})";
                var result = await _integrationsCoreRepository.GetRecords<Reverse>(sql);
                list.AddRange(result);
            }

            return list;
        }
        else
        {
            for (int i = 0; i < reversesIds.Count(); i++)
            {
                if (i == reversesIds.Count() - 1)
                    identificadores += $"'{reversesIds[i]}'";
                else
                    identificadores += $"'{reversesIds[i]}', ";
            }

            string sql = $"SELECT ID, UPDATED_AT FROM [GENERAL].[AFTERSALEREVERSES] WHERE ID IN ({identificadores})";
            var AddRange = await _integrationsCoreRepository.GetRecords<Reverse>(sql);
            list.AddRange(AddRange);

            return list;
        }
    }

    public async Task<IEnumerable<Company?>> GetCompanys()
    {
        string? sql = @$"SELECT DISTINCT
                    CNPJ_EMP AS DOC_COMPANY,
                    TOKEN AS TOKEN
                    FROM GENERAL.PARAMETROS_AFTERSALE";

        return await _integrationsCoreRepository.GetRecords<Company>(sql);
    }

    public async Task<Company?> GetCompany(string cnpj_emp)
    {
        string? sql = @$"SELECT DISTINCT
                     CNPJ_EMP AS DOC_COMPANY,
                     TOKEN
                     FROM GENERAL.PARAMETROS_AFTERSALE
                     WHERE 
                     CNPJ_EMP = {cnpj_emp}";

        return await _integrationsCoreRepository.GetRecord<Company>(sql);
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

    public async Task<bool> InsertIntoAfterSaleReverses(List<Domain.AfterSale.Entities.Data> data, Guid? parentExecutionGUID)
    {
        var reversesTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Reverse(), tableName: "AfterSaleReverses");
        var customerTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Customer(), tableName: "AfterSaleCustomers");
        var addressTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Address(), tableName: "AfterSaleAddresses");
        var trackingTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Tracking(), tableName: "AfterSaleTrackings");
        var trackingHistoryTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new TrackingHistory(), tableName: "AfterSaleTrackingHistories");

        _integrationsCoreRepository.FillSystemDataTable(reversesTable, data.Select(x => x.reverse).ToList());
        _integrationsCoreRepository.FillSystemDataTable(customerTable, data.Select(x => x.customer).ToList());
        _integrationsCoreRepository.FillSystemDataTable(addressTable, data.Select(x => x.customer.address).ToList());
        _integrationsCoreRepository.FillSystemDataTable(addressTable, data.Select(x => x.customer.shipping_address).ToList());
        _integrationsCoreRepository.FillSystemDataTable(trackingTable, data.Where(x => x.reverse.tracking != null).Select(x => x.reverse.tracking).ToList());
        _integrationsCoreRepository.FillSystemDataTable(trackingHistoryTable, data.SelectMany(x => x.tracking_history).ToList());

        _integrationsCoreRepository.BulkInsertIntoTableRaw(reversesTable);
        _integrationsCoreRepository.BulkInsertIntoTableRaw(customerTable);
        _integrationsCoreRepository.BulkInsertIntoTableRaw(addressTable);
        _integrationsCoreRepository.BulkInsertIntoTableRaw(trackingTable);
        _integrationsCoreRepository.BulkInsertIntoTableRaw(trackingHistoryTable);

        await _integrationsCoreRepository.CallDbProcMerge("general", addressTable.TableName, parentExecutionGUID);
        await _integrationsCoreRepository.CallDbProcMerge("general", customerTable.TableName, parentExecutionGUID);
        await _integrationsCoreRepository.CallDbProcMerge("general", reversesTable.TableName, parentExecutionGUID);
        await _integrationsCoreRepository.CallDbProcMerge("general", trackingTable.TableName, parentExecutionGUID);
        await _integrationsCoreRepository.CallDbProcMerge("general", trackingHistoryTable.TableName, parentExecutionGUID);

        return true;
    }

    public Task<bool> InsertIntoAfterSaleReversesCourierAttributes()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> InsertIntoAfterSaleStatus(List<Status> statusReverses, Guid? parentExecutionGUID)
    {
        var statusReversesTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Status(), tableName: "AfterSaleStatus");

        _integrationsCoreRepository.FillSystemDataTable(statusReversesTable, statusReverses);

        _integrationsCoreRepository.BulkInsertIntoTableRaw(statusReversesTable);

        await _integrationsCoreRepository.CallDbProcMerge("general", statusReversesTable.TableName, parentExecutionGUID);

        return true;
    }

    public async Task<bool> InsertIntoAfterSaleTransportations(Transportations transportations, Guid? parentExecutionGUID)
    {
        var transportationsTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Transportations(), tableName: "AfterSaleTransportations");

        _integrationsCoreRepository.FillSystemDataTable(transportationsTable, transportations.data);

        _integrationsCoreRepository.BulkInsertIntoTableRaw(transportationsTable);

        await _integrationsCoreRepository.CallDbProcMerge("general", transportationsTable.TableName, parentExecutionGUID);

        return true;
    }

    public async Task<bool> InsertIntoAfterSaleTransportations(List<Transportations> transportations, Guid? parentExecutionGUID)
    {
        var transportationsTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Transportations(), tableName: "AfterSaleTransportations");

        _integrationsCoreRepository.FillSystemDataTable(transportationsTable, transportations);

        _integrationsCoreRepository.BulkInsertIntoTableRaw(transportationsTable);

        await _integrationsCoreRepository.CallDbProcMerge("general", transportationsTable.TableName, parentExecutionGUID);

        return true;
    }

    public async Task<bool> InsertIntoAfterSaleEcommerce(List<Ecommerce> data, Guid? parentExecutionGUID)
    {
        var ecommercesTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Ecommerce(), tableName: "AfterSaleEcommerces");
        var addressTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Address(), tableName: "AfterSaleAddresses");
        var reasonTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Reason(), tableName: "AfterSaleReasons");

        _integrationsCoreRepository.FillSystemDataTable(ecommercesTable, data);
        _integrationsCoreRepository.FillSystemDataTable(addressTable, data.Select(x => x.address).ToList());
        _integrationsCoreRepository.FillSystemDataTable(reasonTable, data.SelectMany(x => x.reasons).ToList());

        _integrationsCoreRepository.BulkInsertIntoTableRaw(ecommercesTable);
        _integrationsCoreRepository.BulkInsertIntoTableRaw(addressTable);
        _integrationsCoreRepository.BulkInsertIntoTableRaw(reasonTable);

        await _integrationsCoreRepository.CallDbProcMerge("general", addressTable.TableName, parentExecutionGUID);
        await _integrationsCoreRepository.CallDbProcMerge("general", ecommercesTable.TableName, parentExecutionGUID);
        await _integrationsCoreRepository.CallDbProcMerge("general", reasonTable.TableName, parentExecutionGUID);

        return true;
    }
}