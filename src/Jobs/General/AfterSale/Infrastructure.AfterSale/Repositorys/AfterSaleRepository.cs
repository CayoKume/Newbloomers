using Dapper;
using Domain.AfterSale.Interfaces.Repositorys;
using Domain.Core.Entities.Exceptions;
using Infrastructure.Core.Connections.SQLServer;
using System.Data;
using Domain.AfterSale.Models;
using Reverse = Domain.AfterSale.Models.Reverse;
using Domain.Core.Interfaces;
using Microsoft.Win32;

namespace Infrastructure.AfterSale.Repositorys;

public class AfterSaleRepository : IAfterSaleRepository
{
    private readonly ISQLServerConnection _sqlServerConnection;
    private readonly ICoreRepository _coreRepository;

    public AfterSaleRepository(ISQLServerConnection sqlServerConnection, ICoreRepository coreRepository) =>
            (_sqlServerConnection, _coreRepository) = (sqlServerConnection, coreRepository);

    public async Task<List<SimplifiedReverse?>> GetReversesByIds(List<string?> reversesIds)
    {
        var list = new List<SimplifiedReverse?>();
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
                var result = await _coreRepository.GetRecords<SimplifiedReverse>(sql);
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
            var AddRange = await _coreRepository.GetRecords<SimplifiedReverse>(sql);
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

        return await _coreRepository.GetRecords<Company>(sql);
    }

    public async Task<Company?> GetCompany(string cnpj_emp)
    {
        string? sql = @$"SELECT DISTINCT
                     CNPJ_EMP AS DOC_COMPANY,
                     TOKEN
                     FROM GENERAL.PARAMETROS_AFTERSALE
                     WHERE 
                     CNPJ_EMP = {cnpj_emp}";

        return await _coreRepository.GetRecord<Company>(sql);
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

    public async Task<bool> InsertIntoAfterSaleReverses(List<Domain.AfterSale.Models.Reverse> data, Guid? parentExecutionGUID)
    {
        var reversesTable = _coreRepository.CreateSystemDataTable(entity: new Reverse(), tableName: "AfterSaleReverses");
        var customerTable = _coreRepository.CreateSystemDataTable(entity: new Customer(), tableName: "AfterSaleCustomers");
        var addressTable = _coreRepository.CreateSystemDataTable(entity: new Address(), tableName: "AfterSaleAddresses");
        var trackingTable = _coreRepository.CreateSystemDataTable(entity: new Tracking(), tableName: "AfterSaleTrackings");
        var trackingHistoryTable = _coreRepository.CreateSystemDataTable(entity: new TrackingHistory(), tableName: "AfterSaleTrackingHistories");

        //quando tracking é nulo na response o ctor do código monta um tracking com id = 0 e em caso com mais de um tracking montado pelo ctor, da erro de primary key no insert por isso esse agrupamento
        var trackingGroupBy = data.Where(x => x.tracking != null)
                                  .GroupBy(x => new { x.tracking.id, ReverseId = x.tracking.reverse_id })
                                  .Select(g => g.First().tracking)
                                  .ToList();

        _coreRepository.FillSystemDataTable(reversesTable, data.Select(x => x).ToList());
        _coreRepository.FillSystemDataTable(customerTable, data.Select(x => x.customer).ToList());
        _coreRepository.FillSystemDataTable(addressTable, data.Select(x => x.customer.address).ToList());
        _coreRepository.FillSystemDataTable(addressTable, data.Select(x => x.customer.shipping_address).ToList());
        _coreRepository.FillSystemDataTable(trackingTable, trackingGroupBy);
        _coreRepository.FillSystemDataTable(trackingHistoryTable, data.SelectMany(x => x.tracking_history).ToList());

        _coreRepository.BulkInsertIntoTableRaw(reversesTable);
        _coreRepository.BulkInsertIntoTableRaw(customerTable);
        _coreRepository.BulkInsertIntoTableRaw(addressTable);
        _coreRepository.BulkInsertIntoTableRaw(trackingTable);
        _coreRepository.BulkInsertIntoTableRaw(trackingHistoryTable);

        await _coreRepository.CallDbProcMerge("general", addressTable.TableName, parentExecutionGUID);
        await _coreRepository.CallDbProcMerge("general", customerTable.TableName, parentExecutionGUID);
        await _coreRepository.CallDbProcMerge("general", reversesTable.TableName, parentExecutionGUID);
        await _coreRepository.CallDbProcMerge("general", trackingTable.TableName, parentExecutionGUID);
        await _coreRepository.CallDbProcMerge("general", trackingHistoryTable.TableName, parentExecutionGUID);

        return true;
    }

    public Task<bool> InsertIntoAfterSaleReversesCourierAttributes()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> InsertIntoAfterSaleStatus(List<Status> statusReverses, Guid? parentExecutionGUID)
    {
        var statusReversesTable = _coreRepository.CreateSystemDataTable(entity: new Status(), tableName: "AfterSaleStatus");

        _coreRepository.FillSystemDataTable(statusReversesTable, statusReverses);

        _coreRepository.BulkInsertIntoTableRaw(statusReversesTable);

        await _coreRepository.CallDbProcMerge("general", statusReversesTable.TableName, parentExecutionGUID);

        return true;
    }

    public async Task<bool> InsertIntoAfterSaleTransportations(Transportations transportations, Guid? parentExecutionGUID)
    {
        var transportationsTable = _coreRepository.CreateSystemDataTable(entity: new Transportations(), tableName: "AfterSaleTransportations");

        _coreRepository.FillSystemDataTable(transportationsTable, transportations.data);

        _coreRepository.BulkInsertIntoTableRaw(transportationsTable);

        await _coreRepository.CallDbProcMerge("general", transportationsTable.TableName, parentExecutionGUID);

        return true;
    }

    public async Task<bool> InsertIntoAfterSaleTransportations(List<Transportations> transportations, Guid? parentExecutionGUID)
    {
        var transportationsTable = _coreRepository.CreateSystemDataTable(entity: new Transportations(), tableName: "AfterSaleTransportations");

        _coreRepository.FillSystemDataTable(transportationsTable, transportations);

        _coreRepository.BulkInsertIntoTableRaw(transportationsTable);

        await _coreRepository.CallDbProcMerge("general", transportationsTable.TableName, parentExecutionGUID);

        return true;
    }

    public async Task<bool> InsertIntoAfterSaleEcommerce(List<Ecommerce> data, Guid? parentExecutionGUID)
    {
        var ecommercesTable = _coreRepository.CreateSystemDataTable(entity: new Ecommerce(), tableName: "AfterSaleEcommerces");
        var addressTable = _coreRepository.CreateSystemDataTable(entity: new Address(), tableName: "AfterSaleAddresses");
        var reasonTable = _coreRepository.CreateSystemDataTable(entity: new Reason(), tableName: "AfterSaleReasons");

        _coreRepository.FillSystemDataTable(ecommercesTable, data);
        _coreRepository.FillSystemDataTable(addressTable, data.Select(x => x.address).ToList());
        _coreRepository.FillSystemDataTable(reasonTable, data.SelectMany(x => x.reasons).ToList());

        _coreRepository.BulkInsertIntoTableRaw(ecommercesTable);
        _coreRepository.BulkInsertIntoTableRaw(addressTable);
        _coreRepository.BulkInsertIntoTableRaw(reasonTable);

        await _coreRepository.CallDbProcMerge("general", addressTable.TableName, parentExecutionGUID);
        await _coreRepository.CallDbProcMerge("general", ecommercesTable.TableName, parentExecutionGUID);
        await _coreRepository.CallDbProcMerge("general", reasonTable.TableName, parentExecutionGUID);

        return true;
    }
}