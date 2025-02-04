using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Repositorys.Base;
using Domain.LinxCommerce.Interfaces.Repositorys.SalesRepresentative;

namespace Infrastructure.LinxCommerce.Repositorys.SalesRepresentative
{
    public class SalesRepresentativeRepository : ISalesRepresentativeRepository
    {
        private readonly ILinxCommerceRepositoryBase _linxCommerceRepositoryBase;

        public SalesRepresentativeRepository(ILinxCommerceRepositoryBase linxCommerceRepositoryBase) =>
            _linxCommerceRepositoryBase = linxCommerceRepositoryBase;

        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentative> records)
        {
            try
            {
                var salesRepresentativeTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentative());
                var salesRepresentativeContactTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentativeContactData());
                var salesRepresentativeAddressesTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentativeAddress());
                var salesRepresentativeIdentificationTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentativeIdentification());
                var salesRepresentativeComissionTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentativeComission());
                var salesRepresentativeMaxDiscountTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentativeMaxDiscount());
                var salesRepresentativeWebSiteSettingsTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentativeWebSiteSettings(), columnNames: ["WebSiteGroups", "WebSites"], columnTypes: [typeof(string), typeof(string)]);
                var salesRepresentativePortfolioTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentativePortfolio());
                var salesRepresentativeCustomerRelationTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentativeCustomerRelation());
                var salesRepresentativeShippingRegionTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentativeShippingRegion(), columnNames: ["PointOfSalesList"], columnTypes: [typeof(string)]);

                for (int i = 0; i < records.Count(); i++)
                {
                    salesRepresentativeTable.Rows.Add(records[i].SalesRepresentativeID, records[i].Name, records[i].FriendlyCode, records[i].ImageUrl, records[i].IntegrationID,
                        records[i].AllowQuoteDeletion, records[i].BusinessContractID, records[i].SalesRepresentativeType, records[i].Status);

                    if (records[i].Addresses.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Addresses.Count(); j++)
                        {
                            salesRepresentativeAddressesTable.Rows.Add(records[i].SalesRepresentativeID, records[i].Addresses[j].IsMainAddress, records[i].Addresses[j].Name,
                                records[i].Addresses[j].Name, records[i].Addresses[j].AddressLine, records[i].Addresses[j].City, records[i].Addresses[j].Neighbourhood,
                                records[i].Addresses[j].Number, records[i].Addresses[j].State, records[i].Addresses[j].AddressNotes, records[i].Addresses[j].Landmark,
                                records[i].Addresses[j].ContactName, records[i].Addresses[j].Latitude, records[i].Addresses[j].Longitude, records[i].Addresses[j].PostalCode);

                        } 
                    }

                    if (records[i].ShippingRegion != null)
                    {
                        salesRepresentativeShippingRegionTable.Rows.Add(records[i].SalesRepresentativeID, records[i].ShippingRegion.SelectedMode, records[i].ShippingRegion.ShippingRegionID,
                            records[i].ShippingRegion.PointOfSalesList.Count() > 0 ? String.Join(", ", records[i].ShippingRegion.PointOfSalesList) : null);
                    }

                    if (records[i].Contact != null)
                    {
                        salesRepresentativeContactTable.Rows.Add(records[i].SalesRepresentativeID, records[i].Contact.Email, records[i].Contact.Phone, records[i].Contact.CellPhone);
                    }

                    if (records[i].Identification != null)
                    {
                        salesRepresentativeIdentificationTable.Rows.Add(records[i].SalesRepresentativeID, records[i].Identification.Type, records[i].Identification.DocumentNumber);
                    }

                    if (records[i].Commission != null)
                    {
                        salesRepresentativeComissionTable.Rows.Add(records[i].SalesRepresentativeID, records[i].Commission.TotalCommission, records[i].Commission.DeliveryCommission);
                    }

                    if (records[i].WebSiteSettings != null)
                    {
                        salesRepresentativeWebSiteSettingsTable.Rows.Add(records[i].SalesRepresentativeID, records[i].WebSiteSettings.WebSiteFilter, 
                            records[i].WebSiteSettings.WebSiteGroups.Count() > 0 ? String.Join(", ", records[i].WebSiteSettings.WebSiteGroups) : null, 
                            records[i].WebSiteSettings.WebSites.Count() > 0 ? String.Join(", ", records[i].WebSiteSettings.WebSites) : null);
                    }

                    if (records[i].Portfolio != null)
                    {
                        salesRepresentativePortfolioTable.Rows.Add(records[i].SalesRepresentativeID, records[i].Portfolio.HasPortfolio, records[i].Portfolio.PortfolioAssociationType);

                        if (records[i].Portfolio.Customers.Count() > 0)
                        {
                            for (int h = 0; h < records[i].Portfolio.Customers.Count(); h++)
                            {
                                salesRepresentativeCustomerRelationTable.Rows.Add(records[i].Portfolio.Customers[h].CustomerID, records[i].Portfolio.Customers[h].Status, records[i].Portfolio.Customers[h].IsMaxDiscountEnabled,
                                    records[i].SalesRepresentativeID);
                            }
                        }
                    }

                    if (records[i].MaxDiscount != null)
                    {
                        salesRepresentativeMaxDiscountTable.Rows.Add(records[i].MaxDiscount.Type, records[i].MaxDiscount.Amount, records[i].SalesRepresentativeID);
                    }
                }

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "SalesRepresentative",
                    dataTable: salesRepresentativeTable,
                    dataTableRowsNumber: salesRepresentativeTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "SalesRepresentativeAddress",
                    dataTable: salesRepresentativeAddressesTable,
                    dataTableRowsNumber: salesRepresentativeAddressesTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "SalesRepresentativeShippingRegion",
                    dataTable: salesRepresentativeShippingRegionTable,
                    dataTableRowsNumber: salesRepresentativeShippingRegionTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "SalesRepresentativeContactData",
                    dataTable: salesRepresentativeContactTable,
                    dataTableRowsNumber: salesRepresentativeContactTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "SalesRepresentativeIdentification",
                    dataTable: salesRepresentativeIdentificationTable,
                    dataTableRowsNumber: salesRepresentativeIdentificationTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "SalesRepresentativeComission",
                    dataTable: salesRepresentativeComissionTable,
                    dataTableRowsNumber: salesRepresentativeComissionTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "SalesRepresentativePortfolio",
                    dataTable: salesRepresentativePortfolioTable,
                    dataTableRowsNumber: salesRepresentativePortfolioTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "SalesRepresentativeCustomerRelation",
                    dataTable: salesRepresentativeCustomerRelationTable,
                    dataTableRowsNumber: salesRepresentativeCustomerRelationTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "SalesRepresentativeWebSiteSettings",
                    dataTable: salesRepresentativeWebSiteSettingsTable,
                    dataTableRowsNumber: salesRepresentativeWebSiteSettingsTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobName: jobParameter.jobName,
                    databaseName: jobParameter.databaseName,
                    dataTableName: "SalesRepresentativeMaxDiscount",
                    dataTable: salesRepresentativeMaxDiscountTable,
                    dataTableRowsNumber: salesRepresentativeMaxDiscountTable.Rows.Count
                );

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                return true;
            }
            catch
            {
                throw;
            }
        }

        public Task<List<Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentative>> GetRegistersExists(List<string> ordersIds)
        {
            throw new NotImplementedException();
        }
    }
}
