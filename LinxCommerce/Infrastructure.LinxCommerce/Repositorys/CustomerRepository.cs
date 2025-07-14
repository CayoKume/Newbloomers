﻿using Domain.IntegrationsCore.Interfaces;
using Domain.LinxCommerce.Entities.Customer;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Repositorys;
using Infrastructure.IntegrationsCore.Connections.SQLServer;

namespace Infrastructure.LinxCommerce.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly ISQLServerConnection? _sqlServerConnection;

        public CustomerRepository(IIntegrationsCoreRepository integrationsCoreRepository, ISQLServerConnection? sqlServerConnection) =>
            (_integrationsCoreRepository, _sqlServerConnection) = (integrationsCoreRepository, sqlServerConnection);

        public async Task<bool> BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Person> records, Guid? parentExecutionGUID)
        {
            var customerTable = _integrationsCoreRepository.CreateSystemDataTable("Customer", new Person());
            var customerContactTable = _integrationsCoreRepository.CreateSystemDataTable("CustomerContact", new Contact());
            var customerAddressTable = _integrationsCoreRepository.CreateSystemDataTable("CustomerAddress", new PersonAddress());
            var customerEmailConfirmationTable = _integrationsCoreRepository.CreateSystemDataTable("CustomerEmailConfirmation", new EmailConfirmation());

            //Adicionar Fill DataTable com os dados dos registros
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    customerTable.Rows.Add(records[i].lastupdateon, records[i].Surname, records[i].BirthDate, records[i].Gender, records[i].RG, records[i].Cpf,
                                    records[i].CreatedDate, records[i].CustomerID, records[i].CustomerStatusID, records[i].WebSiteID, records[i].Name,
                                    records[i].Email, records[i].CustomerHash, records[i].Password, records[i].CustomerType, records[i].Cnpj, records[i].TradingName,
                                    records[i].Groups.Count() > 0 ? String.Join(", ", records[i].Groups.Select(x => x.CustomerGroupID)) : null);

                    if (records[i].Contact != null)
                    {
                        customerContactTable.Rows.Add(records[i].Contact.lastupdateon, records[i].Contact.Phone, records[i].Contact.Phone2,
                            records[i].Contact.CellPhone, records[i].Contact.Fax, records[i].Contact.CustomerID);
                    }

                    if (records[i].Address.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Address.Count(); j++)
                        {
                            customerAddressTable.Rows.Add(records[i].Address[j].lastupdateon, records[i].Address[j].ID, records[i].Address[j].Name, records[i].Address[j].ContactName,
                                records[i].Address[j].PostalCode, records[i].Address[j].AddressLine, records[i].Address[j].City, records[i].Address[j].Neighbourhood,
                                records[i].Address[j].Number, records[i].Address[j].State, records[i].Address[j].AddressNotes, records[i].Address[j].Landmark,
                                records[i].Address[j].MainAddress, records[i].Address[j].CustomerID);
                        }
                    }

                    if (records[i].EmailConfirmation != null)
                    {
                        customerEmailConfirmationTable.Rows.Add(records[i].EmailConfirmation.lastupdateon, records[i].EmailConfirmation.CustomerID, records[i].EmailConfirmation.Status, records[i].EmailConfirmation.ConfirmationDate);
                    }
                }
                catch
                {
                    continue;
                }
            }

            _integrationsCoreRepository.BulkInsertIntoTableRaw(customerTable);
            await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, customerTable.TableName, parentExecutionGUID);

            _integrationsCoreRepository.BulkInsertIntoTableRaw(customerEmailConfirmationTable);
            await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, customerEmailConfirmationTable.TableName, parentExecutionGUID);

            _integrationsCoreRepository.BulkInsertIntoTableRaw(customerAddressTable);
            await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, customerAddressTable.TableName, parentExecutionGUID);

            _integrationsCoreRepository.BulkInsertIntoTableRaw(customerContactTable);
            await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, customerContactTable.TableName, parentExecutionGUID);

            return true;
        }

        public async Task<bool> InsertRecord(LinxCommerceJobParameter jobParameter, Person registro, Guid? parentExecutionGUID)
        {
            string? sql = @$"INSERT INTO [untreated].[Customer]
                            ([Surname],[BirthDate],[Gender],[RG],[Cpf],[CreatedDate],[CustomerID],[CustomerStatusID],[WebSiteID],[Name],[Email],[CustomerHash],[Password],
                             [CustomerType],[Cnpj],[TradingName],[CustomerGroupID])
                            Values
                            (@Surname, @BirthDate, @Gender, @RG, @Cpf, @CreatedDate, @CustomerID,@CustomerStatusID,@WebSiteID,@Name,@Email,@CustomerHash,
                             @Password,@CustomerType,@Cnpj,@TradingName,@CustomerGroupID)";

            await _integrationsCoreRepository.InsertRecord(sql: sql, entity: registro);
            await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, "Customer", parentExecutionGUID);

            string? _sql = @$"INSERT INTO [untreated].[CustomerEmailConfirmation]
                            ([Status],[ConfirmationDate],[CustomerID])
                            Values
                            (@Status, @ConfirmationDate, @CustomerID)";

            await _integrationsCoreRepository.InsertRecord(sql: _sql, entity: registro.EmailConfirmation);
            await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, "CustomerEmailConfirmation", parentExecutionGUID);

            foreach (var address in registro.Address)
            {
                string? __sql = @$"INSERT INTO [untreated].[CustomerAddress]
                            ([ID], [Name],[ContactName],[PostalCode],[AddressLine],[City],[Neighbourhood],[Number],[State],[AddressNotes],[Landmark],[MainAddress],[CustomerID])
                            Values
                            (@ID, @Name, @ContactName, @PostalCode, @AddressLine, @City, @Neighbourhood, @Number, @State, @AddressNotes, @Landmark, @MainAddress, @CustomerID)";

                await _integrationsCoreRepository.InsertRecord(sql: __sql, entity: address);
            }

            await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, "CustomerAddress", parentExecutionGUID);

            string? ___sql = @$"INSERT INTO [untreated].[CustomerContact]
                            ([Phone],[Phone2],[CellPhone],[Fax],[CustomerID])
                            Values
                            (@Phone, @Phone2, @CellPhone, @Fax, @CustomerID)";

            await _integrationsCoreRepository.InsertRecord(sql: ___sql, entity: registro.Contact);
            await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, "CustomerContact", parentExecutionGUID);

            return true;
        }
    }
}
