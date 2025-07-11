using Dapper;
using Domain.AfterSale.Interfaces.Repositorys;
using Domain.IntegrationsCore.Entities.Exceptions;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Data;
using Domain.AfterSale.Entities;
using Reverse = Domain.AfterSale.Entities.Reverse;
using Domain.IntegrationsCore.Interfaces;
using Domain.IntegrationsCore.Enums;
using Newtonsoft.Json;
using System.Reflection;

namespace Infrastructure.AfterSale.Repositorys;

public class AfterSaleRepository : IAfterSaleRepository
{
    private readonly ISQLServerConnection _sqlServerConnection;
    private readonly IIntegrationsCoreRepository _integrationsCoreRepository;

    public AfterSaleRepository(ISQLServerConnection sqlServerConnection, IIntegrationsCoreRepository integrationsCoreRepository) =>
            (_sqlServerConnection, _integrationsCoreRepository) = (sqlServerConnection, integrationsCoreRepository);

    public async Task<IEnumerable<Company?>> GetCompanys()
    {
        try
        {
            string? sql = @$"SELECT DISTINCT
                     CNPJ_EMP AS DOC_COMPANY,
                     TOKEN AS TOKEN
                     FROM GENERAL.PARAMETROS_AFTERSALE";

            return await _integrationsCoreRepository.GetRecords<Company>(sql);
        }
        catch (Exception ex)
        {
            /////que merda é essa cayo????
            var message = JsonConvert.SerializeObject(new
            {
                project = ex.Source,
                method = MethodBase.GetCurrentMethod()?.Name,//ex.TargetSite?.ReflectedType?.Name,
                message = ex.Message,
            });

            //ex.AddMessage(message);
            throw;
        }
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

    public bool InsertIntoAfterSaleRefunds()
    {
        throw new NotImplementedException();
    }

    public bool InsertIntoAfterSaleRefundsActions()
    {
        throw new NotImplementedException();
    }

    public bool InsertIntoAfterSaleRefundsBanks()
    {
        throw new NotImplementedException();
    }

    public bool InsertIntoAfterSaleRefundsStatus()
    {
        throw new NotImplementedException();
    }

    public bool InsertIntoAfterSaleRefundsTypes()
    {
        throw new NotImplementedException();
    }

    public bool InsertIntoAfterSaleReverses(List<Domain.AfterSale.Entities.Data> data)
    {
        var reversesTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Reverse(), tableName: "AfterSaleReverses");
        var customerTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Customer(), tableName: "AfterSaleCustomers");
        var addressTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Address(), tableName: "AfterSaleAddresses");
        var trackingHistoryTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new TrackingHistory(), tableName: "AfterSaleTrackingHistories");

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

    public bool InsertIntoAfterSaleReversesCourierAttributes()
    {
        throw new NotImplementedException();
    }

    public bool InsertIntoAfterSaleStatus(List<Status> statusReverses)
    {
        var statusReversesTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Status(), tableName: "AfterSaleStatus");

        //try
        //{
            _integrationsCoreRepository.FillSystemDataTable(statusReversesTable, statusReverses);

            _integrationsCoreRepository.BulkInsertIntoTableRaw(statusReversesTable);

            return true;
        //}
        //catch (Exception ex)
        //{
        //    throw new GeneralException(
        //        //stage: EnumStages.BulkInsertIntoTableRaw,
        //        //error: EnumError.SQLCommand,
        //        //level: EnumMessageLevel.Error,
        //        message: $"Error when trying to bulk insert records on table raw"//,
        //        //exceptionMessage: ex.Message
        //    );
        //}
    }

    public bool InsertIntoAfterSaleTransportations(Transportations transportations)
    {
        var transportationsTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Transportations(), tableName: "AfterSaleTransportations");

        //try
        //{
            _integrationsCoreRepository.FillSystemDataTable(transportationsTable, transportations.data);

            _integrationsCoreRepository.BulkInsertIntoTableRaw(transportationsTable);

            return true;
        //}
        //catch (Exception ex)
        //{
        //    throw new GeneralException(
        //        //stage: EnumStages.BulkInsertIntoTableRaw,
        //        //error: EnumError.SQLCommand,
        //        //level: EnumMessageLevel.Error,
        //        message: $"Error when trying to bulk insert records on table raw"//,
        //        //exceptionMessage: ex.Message
        //    );
        //}
    }

    public bool InsertIntoAfterSaleTransportations(List<Transportations> transportations)
    {
        var transportationsTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Transportations(), tableName: "AfterSaleTransportations");

        //try
        //{
            _integrationsCoreRepository.FillSystemDataTable(transportationsTable, transportations);

            _integrationsCoreRepository.BulkInsertIntoTableRaw(transportationsTable);

            return true;
        //}
        //catch (Exception ex)
        //{
        //    throw new GeneralException(
        //        //stage: EnumStages.BulkInsertIntoTableRaw,
        //        //error: EnumError.SQLCommand,
        //        //level: EnumMessageLevel.Error,
        //        message: $"Error when trying to bulk insert records on table raw"//,
        //        //exceptionMessage: ex.Message
        //    );
        //}
    }

    public bool InsertIntoAfterSaleEcommerce(List<Ecommerce> data)
    {
        var ecommercesTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Ecommerce(), tableName: "AfterSaleEcommerces");
        var addressTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Address(), tableName: "AfterSaleAddresses");
        var reasonTable = _integrationsCoreRepository.CreateSystemDataTable(entity: new Reason(), tableName: "AfterSaleReasons");

        //try
        //{
            _integrationsCoreRepository.FillSystemDataTable(ecommercesTable, data);
            _integrationsCoreRepository.FillSystemDataTable(addressTable, data.Select(x => x.address).ToList());
            _integrationsCoreRepository.FillSystemDataTable(reasonTable, data.SelectMany(x => x.reasons).ToList());

            _integrationsCoreRepository.BulkInsertIntoTableRaw(ecommercesTable);
            _integrationsCoreRepository.BulkInsertIntoTableRaw(addressTable);
            _integrationsCoreRepository.BulkInsertIntoTableRaw(reasonTable);

            return true;
        //}
        //catch (Exception ex)
        //{
        //    throw new GeneralException(
        //        //stage: EnumStages.BulkInsertIntoTableRaw,
        //        //error: EnumError.SQLCommand,
        //        //level: EnumMessageLevel.Error,
        //        message: $"Error when trying to bulk insert records on table raw"//,
        //        //exceptionMessage: ex.Message
        //    );
        //}
    }
}