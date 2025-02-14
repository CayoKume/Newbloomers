using Dapper;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxCommerce.Entities.Customer;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Repositorys;
using Domain.LinxCommerce.Interfaces.Repositorys.Base;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Data.SqlClient;

namespace Infrastructure.LinxCommerce.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILinxCommerceRepositoryBase _linxCommerceRepositoryBase;
        private readonly ISQLServerConnection? _sqlServerConnection;

        public CustomerRepository(ILinxCommerceRepositoryBase linxCommerceRepositoryBase, ISQLServerConnection? sqlServerConnection) =>
            (_linxCommerceRepositoryBase, _sqlServerConnection) = (linxCommerceRepositoryBase, sqlServerConnection);

        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Person> records)
        {
            try
            {
                var customerTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Customer.Person());
                var customerContactTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Customer.Contact());
                var customerAddressTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Customer.PersonAddress());
                var customerEmailConfirmationTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Customer.EmailConfirmation());

                for (int i = 0; i < records.Count(); i++)
                {
                    customerTable.Rows.Add(records[i].Surname, records[i].BirthDate, records[i].Gender, records[i].RG, records[i].Cpf,
                        records[i].CreatedDate, records[i].CustomerID, records[i].CustomerStatusID, records[i].WebSiteID, records[i].Name,
                        records[i].Email, records[i].CustomerHash, records[i].Password, records[i].CustomerType, records[i].Cnpj, records[i].TradingName,
                        records[i].Groups.Count() > 0 ? String.Join(", ", records[i].Groups.Select(x => x.CustomerGroupID)) : null);

                    if (records[i].Contact != null)
                    {
                        customerContactTable.Rows.Add(records[i].Contact.Phone, records[i].Contact.Phone2,
                            records[i].Contact.CellPhone, records[i].Contact.Fax, records[i].CustomerID);
                    }

                    if (records[i].Address.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Address.Count(); j++)
                        {
                            customerAddressTable.Rows.Add(records[i].Address[j].ID, records[i].Address[j].Name, records[i].Address[j].ContactName,
                                records[i].Address[j].PostalCode, records[i].Address[j].AddressLine, records[i].Address[j].City, records[i].Address[j].Neighbourhood,
                                records[i].Address[j].Number, records[i].Address[j].State, records[i].Address[j].AddressNotes, records[i].Address[j].Landmark,
                                records[i].Address[j].MainAddress, records[i].CustomerID);
                        }
                    }

                    if (records[i].EmailConfirmation != null)
                    {
                        customerEmailConfirmationTable.Rows.Add(records[i].CustomerID, records[i].EmailConfirmation.Status, records[i].EmailConfirmation.ConfirmationDate);
                    }
                }

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                        jobName: jobParameter.jobName,
                        databaseName: jobParameter.databaseName,
                        dataTableName: "Customer",
                        dataTable: customerTable,
                        dataTableRowsNumber: customerTable.Rows.Count
                    );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "CustomerEmailConfirmation",
                    dataTable: customerEmailConfirmationTable,
                    dataTableRowsNumber: customerEmailConfirmationTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "CustomerAddress",
                    dataTable: customerAddressTable,
                    dataTableRowsNumber: customerAddressTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "CustomerContact",
                    dataTable: customerContactTable,
                    dataTableRowsNumber: customerContactTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Person>> GetRegistersExists(IEnumerable<int> customerIds)
        {
            string? identifiers = String.Empty;

            for (int i = 0; i < customerIds.Count(); i++)
            {

                if (i == customerIds.Count() - 1)
                    identifiers += $"{customerIds.ElementAt(i)}";
                else
                    identifiers += $"{customerIds.ElementAt(i)}, ";
            }

            string? sql = $@"SELECT DISTINCT
	                         A.[Surname],
                             A.[BirthDate],
                             A.[Gender],
                             A.[RG],
                             A.[Cpf],
                             A.[CreatedDate],
                             A.[CustomerID],
                             A.[CustomerStatusID],
                             A.[WebSiteID],
                             A.[Name],
                             A.[Email],
                             A.[CustomerHash],
                             A.[Password],
                             A.[CustomerType],
                             A.[Cnpj],
                             A.[TradingName],
                             A.[CustomerGroupID] As CustomerGroupID,

                             B.[Phone],
                             B.[Phone2],
                             B.[CellPhone],
                             TRIM(B.[Fax]) As Fax,
                             B.[CustomerID],

	                         C.[Status],
                             C.[ConfirmationDate],
                             C.[CustomerID],

                             D.[ID],
                             D.[Name],
                             D.[ContactName],
                             TRIM(D.[PostalCode]) As PostalCode,
                             D.[AddressLine],
                             D.[City],
                             D.[Neighbourhood],
                             D.[Number],
                             D.[State],
                             D.[AddressNotes],
                             D.[Landmark],
                             D.[MainAddress],
                             D.[CustomerID]

                             FROM [linx_commerce].[Customer] A (NOLOCK)
                             LEFT JOIN [linx_commerce].[CustomerContact] B (NOLOCK) ON A.CustomerID = B.CustomerID
                             LEFT JOIN [linx_commerce].[CustomerEmailConfirmation] C (NOLOCK) ON A.CustomerID = C.CustomerID
                             LEFT JOIN [linx_commerce].[CustomerAddress] D (NOLOCK) ON A.CustomerID = D.CustomerID
                             WHERE
                             A.CustomerID IN ({identifiers})";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<
                        Domain.LinxCommerce.Entities.Customer.Person,
                        Domain.LinxCommerce.Entities.Customer.Contact,
                        Domain.LinxCommerce.Entities.Customer.EmailConfirmation,
                        Domain.LinxCommerce.Entities.Customer.PersonAddress,
                        Domain.LinxCommerce.Entities.Customer.Person
                    >(sql, (person, contact, emailConfirmation, personAddress) =>
                    {
                        person.Contact = contact;
                        person.EmailConfirmation = emailConfirmation;
                        person.Address.Add(personAddress);

                        return person;
                    }, splitOn: "Phone, Status, ID", commandTimeout: 360);

                    return result
                        .GroupBy(p => p.CustomerID)
                        .Select(g =>
                        {
                            var groupedResult = g.First();
                            groupedResult.Address = g.Select(p => p.Address.Single()).ToList();

                            return groupedResult;
                        })
                        .ToList();
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    stage: EnumStages.GetRegistersExists,
                    message: $"Error when trying to get records that already exist in trusted table",
                    exceptionMessage: ex.Message,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to get records that already exist in trusted table",
                    exceptionMessage: ex.Message
                );
            }
        }
    }
}
