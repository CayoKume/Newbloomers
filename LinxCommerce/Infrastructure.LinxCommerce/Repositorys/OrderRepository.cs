using Dapper;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.LinxCommerce.Entities.Order;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Repositorys;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Data.SqlClient;

namespace Infrastructure.LinxCommerce.Repositorys
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ILinxCommerceRepositoryBase _linxCommerceRepositoryBase;
        private readonly ISQLServerConnection _sqlServerConnection;

        public OrderRepository(ILinxCommerceRepositoryBase linxCommerceRepositoryBase, ISQLServerConnection sqlServerConnection) =>
            (_linxCommerceRepositoryBase, _sqlServerConnection) = (linxCommerceRepositoryBase, sqlServerConnection);

        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Domain.LinxCommerce.Entities.Order.Order.Root> records, Guid? parentExecutionGUID)
        {
            try
            {
                var orderTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.Order.Root());
                var orderItemTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderItem());
                var orderTagTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderTag());
                var orderAddressTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderAddress());
                var orderPaymentMethodTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderPaymentMethod());
                var orderPaymentInfoTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderPaymentInfo());
                var orderDeliveryMethodTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderDeliveryMethod());
                var orderDiscountTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderDiscount());
                var orderShipmentTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderShipment());
                var orderPackageTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderPackage());
                var orderInvoiceTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderInvoice());

                for (int i = 0; i < records.Count(); i++)
                {
                    orderTable.Rows.Add(
                        records[i].lastupdateon, records[i].OrderID, records[i].OrderNumber, records[i].MarketPlaceBrand, records[i].OriginalOrderID, records[i].WebSiteID, records[i].WebSiteIntegrationID, records[i].CustomerID,
                        records[i].ShopperTicketID, records[i].ItemsQty, records[i].ItemsCount, records[i].TaxAmount, records[i].DeliveryAmount, records[i].DiscountAmount, records[i].PaymentTaxAmount, records[i].SubTotal,
                        records[i].Total, records[i].TotalDue, records[i].TotalPaid, records[i].TotalRefunded, records[i].PaymentDate, records[i].PaymentStatus, records[i].ShipmentDate, records[i].ShipmentStatus,
                        records[i].GlobalStatus, records[i].DeliveryPostalCode, records[i].CreatedChannel, records[i].TrafficSourceID, records[i].OrderStatusID, records[i].CreatedDate, records[i].CreatedBy, records[i].ModifiedDate,
                        records[i].ModifiedBy, records[i].Remarks, records[i].SellerCommissionAmount, records[i].CommissionAmount, records[i].OrderGroupID, records[i].OrderGroupNumber, records[i].HasConflicts, records[i].AcquiredDate,
                        records[i].HasHubOrderWithoutShipmentConflict, records[i].CustomerType, records[i].CancelledDate, records[i].WebSiteName, records[i].CustomerName, records[i].CustomerEmail, records[i].CustomerGender,
                        records[i].CustomerBirthDate, records[i].CustomerPhone, records[i].CustomerCPF, records[i].CustomerCNPJ, records[i].CustomerTradingName, records[i].CustomerSiteTaxPayer, records[i].SalesRepresentativeID,
                        records[i].SellerEMail, records[i].SellerIntegrationID, records[i].SellerName, records[i].SellerPhone, records[i].SellerID, records[i].MultiSiteTenantBrandId, records[i].MultiSiteTenantBrandType, 
                        records[i].MultiSiteTenantCompanyId, records[i].MultiSiteTenantDeviceType, records[i].OrderTypeID, records[i].OrderTypeAllowMultiPayment, records[i].OrderTypeIntegrationID, records[i].OrderTypeName,
                        records[i].OrderTypeEmitFiscalTicket, records[i].OrderTypeRequirePayment, records[i].OrderTypeRequireInventory
                    );

                    if (records[i].Items.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Items.Count(); j++)
                        {
                            orderItemTable.Rows.Add(
                                records[i].Items[j].lastupdateon, records[i].Items[j].OrderItemID, records[i].Items[j].OrderID, records[i].Items[j].ParentItemID, records[i].Items[j].ProductID, records[i].Items[j].SkuID, records[i].Items[j].SKU, records[i].Items[j].SellerSKU,
                                records[i].Items[j].WebSiteID, records[i].Items[j].CatalogID, records[i].Items[j].PriceListID, records[i].Items[j].WareHouseID, records[i].Items[j].WarehouseIntegrationID, records[i].Items[j].Qty, records[i].Items[j].Price,
                                records[i].Items[j].DiscountAmount, records[i].Items[j].TaxationAmount, records[i].Items[j].SubtotalAdjustment, records[i].Items[j].Subtotal, records[i].Items[j].Total, records[i].Items[j].IsFreeShipping, records[i].Items[j].IsDeleted, records[i].Items[j].Status,
                                records[i].Items[j].ProductIntegrationID, records[i].Items[j].SKUIntegrationID, records[i].Items[j].CatalogItemType, records[i].Items[j].IsFreeOffer, records[i].Items[j].IsGiftWrapping, records[i].Items[j].IsService,
                                records[i].Items[j].SpecialType, records[i].Items[j].BundlePriceType, records[i].Items[j].BundleKitDiscount, records[i].Items[j].BundleKitDiscountValue, records[i].Items[j].InStockHandlingDays,
                                records[i].Items[j].OutStockHandlingDays, records[i].Items[j].ProductName, records[i].Items[j].SkuName, records[i].Items[j].IsDeliverable, records[i].Items[j].Weight, records[i].Items[j].Depth,
                                records[i].Items[j].Height, records[i].Items[j].Width, records[i].Items[j].FulfillmentID, records[i].Items[j].UPC
                            );
                        }
                    }

                    if (records[i].Tags.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Tags.Count(); j++)
                        {
                            orderTagTable.Rows.Add(records[i].Tags[j].lastupdateon, records[i].Tags[j].TagID, records[i].Tags[j].Alias, records[i].Tags[j].Name, records[i].Tags[j].IsSystem, records[i].Tags[j].IsDeleted, records[i].Tags[j].OrderID);
                        }
                    }

                    if (records[i].Addresses.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Addresses.Count(); j++)
                        {
                            orderAddressTable.Rows.Add(
                                records[i].Addresses[j].lastupdateon, records[i].Addresses[j].OrderAddressID, records[i].Addresses[j].OrderID, records[i].Addresses[j].Name, records[i].Addresses[j].AddressLine, records[i].Addresses[j].City, records[i].Addresses[j].Neighbourhood,
                                records[i].Addresses[j].Number, records[i].Addresses[j].State, records[i].Addresses[j].PostalCode, records[i].Addresses[j].AddressNotes, records[i].Addresses[j].Landmark, records[i].Addresses[j].ContactName,
                                records[i].Addresses[j].ContactDocumentNumber, records[i].Addresses[j].AddressType, records[i].Addresses[j].PointOfSaleID, records[i].Addresses[j].ContactPhone
                            );
                        }
                    }

                    if (records[i].PaymentMethods.Count() > 0)
                    {
                        for (int j = 0; j < records[i].PaymentMethods.Count(); j++)
                        {
                            orderPaymentMethodTable.Rows.Add(
                                records[i].PaymentMethods[j].lastupdateon, records[i].PaymentMethods[j].OrderPaymentMethodID, records[i].PaymentMethods[j].OrderID, records[i].PaymentMethods[j].PaymentNumber, records[i].PaymentMethods[j].PaymentMethodID, records[i].PaymentMethods[j].TransactionID,
                                records[i].PaymentMethods[j].ReconciliationNumber, records[i].PaymentMethods[j].Status, records[i].PaymentMethods[j].IntegrationID, records[i].PaymentMethods[j].Amount, records[i].PaymentMethods[j].AmountNoInterest, records[i].PaymentMethods[j].InterestValue,
                                records[i].PaymentMethods[j].PaidAmount, records[i].PaymentMethods[j].RefundAmount, records[i].PaymentMethods[j].Installments, records[i].PaymentMethods[j].InstallmentAmount, records[i].PaymentMethods[j].TaxAmount, records[i].PaymentMethods[j].PaymentDate,
                                records[i].PaymentMethods[j].CaptureDate, records[i].PaymentMethods[j].AcquiredDate, records[i].PaymentMethods[j].PaymentCancelledDate
                            );

                            orderPaymentInfoTable.Rows.Add(
                                records[i].PaymentMethods[j].PaymentInfo.lastupdateon, records[i].PaymentMethods[j].PaymentInfo.Identifier, records[i].PaymentMethods[j].PaymentInfo.Alias, records[i].PaymentMethods[j].PaymentInfo.PaymentDate, records[i].PaymentMethods[j].PaymentInfo.ExpirationDate, records[i].PaymentMethods[j].PaymentInfo.Month,
                                records[i].PaymentMethods[j].PaymentInfo.Year, records[i].PaymentMethods[j].PaymentInfo.Holder, records[i].PaymentMethods[j].PaymentInfo.NumberHint, records[i].PaymentMethods[j].PaymentInfo.SecurityCodeHint, records[i].PaymentMethods[j].PaymentInfo.TransactionNumber,
                                records[i].PaymentMethods[j].PaymentInfo.AuthorizationCode, records[i].PaymentMethods[j].PaymentInfo.ReceiptCode, records[i].PaymentMethods[j].PaymentInfo.ReconciliationNumber, records[i].PaymentMethods[j].PaymentInfo.ConfirmationNumber, records[i].PaymentMethods[j].PaymentInfo.PaymentType,
                                records[i].PaymentMethods[j].PaymentInfo.Provider, records[i].PaymentMethods[j].PaymentInfo.ProviderDocumentNumber, records[i].PaymentMethods[j].PaymentInfo.PixQRCode, records[i].PaymentMethods[j].PaymentInfo.PixKey, records[i].PaymentMethods[j].OrderPaymentMethodID
                            );
                        }
                    }

                    if (records[i].DeliveryMethods.Count() > 0)
                    {
                        for (int j = 0; j < records[i].DeliveryMethods.Count(); j++)
                        {
                            orderDeliveryMethodTable.Rows.Add(
                                records[i].DeliveryMethods[j].lastupdateon, records[i].DeliveryMethods[j].LogisticOptionId, records[i].DeliveryMethods[j].LogisticOptionName, records[i].DeliveryMethods[j].LogisticContractId, records[i].DeliveryMethods[j].LogisticContractName, records[i].DeliveryMethods[j].OrderDeliveryMethodID,
                                records[i].DeliveryMethods[j].OrderID, records[i].DeliveryMethods[j].DeliveryMethodID, records[i].DeliveryMethods[j].DeliveryGroupID, records[i].DeliveryMethods[j].Amount, records[i].DeliveryMethods[j].ETA, records[i].DeliveryMethods[j].ETADays,
                                records[i].DeliveryMethods[j].IntegrationID, records[i].DeliveryMethods[j].ScheduleShiftID, records[i].DeliveryMethods[j].ScheduleDisplayName, records[i].DeliveryMethods[j].ScheduleTax,/* records[i].DeliveryMethods[j].ScheduleStartTime, records[i].DeliveryMethods[j].ScheduleEndTime,*/
                                records[i].DeliveryMethods[j].ScheduleDate, records[i].DeliveryMethods[j].DeliveryMethodAlias, records[i].DeliveryMethods[j].PointOfSaleID, records[i].DeliveryMethods[j].PointOfSaleIntegrationID, records[i].DeliveryMethods[j].PointOfSaleName, records[i].DeliveryMethods[j].DeliveryMethodType,
                                records[i].DeliveryMethods[j].DeliveryLogisticType, records[i].DeliveryMethods[j].ExternalID, records[i].DeliveryMethods[j].WarehouseID, records[i].DeliveryMethods[j].WarehouseIntegrationID, records[i].DeliveryMethods[j].DockID, records[i].DeliveryMethods[j].CarrierName,
                                records[i].DeliveryMethods[j].DeliveryEstimatedDate
                            );
                        }
                    }

                    if (records[i].Discounts.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Discounts.Count(); j++)
                        {
                            orderDiscountTable.Rows.Add(
                                records[i].Discounts[j].lastupdateon, records[i].Discounts[j].Amount, records[i].Discounts[j].DiscountID, records[i].Discounts[j].Message, records[i].Discounts[j].Reference, records[i].Discounts[j].Type, records[i].Discounts[j].OrderID
                            );
                        }
                    }

                    if (records[i].Shipments.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Shipments.Count(); j++)
                        {
                            orderShipmentTable.Rows.Add(
                                records[i].Shipments[j].lastupdateon, records[i].Shipments[j].OrderShipmentID, records[i].Shipments[j].OrderID, records[i].Shipments[j].DeliveryMethodID, records[i].Shipments[j].ShipmentNumber, records[i].Shipments[j].ShipmentStatus,
                                records[i].Shipments[j].AssignUserId, records[i].Shipments[j].AssignUserName, records[i].Shipments[j].DockID
                            );

                            if (records[i].Shipments[j].Packages.Count() > 0)
                            {
                                for (int h = 0; h < records[i].Shipments[j].Packages.Count(); h++)
                                {
                                    orderPackageTable.Rows.Add(
                                        records[i].Shipments[j].Packages[h].lastupdateon, records[i].Shipments[j].Packages[h].OrderPackageID, records[i].Shipments[j].Packages[h].OrderShipmentID, records[i].Shipments[j].Packages[h].DeliveryMethodID, records[i].Shipments[j].Packages[h].PackageNumber,
                                        records[i].Shipments[j].Packages[h].TrackingNumber, records[i].Shipments[j].Packages[h].TrackingNumberUrl, records[i].Shipments[j].Packages[h].ShippedDate, records[i].Shipments[j].Packages[h].ShippedBy,
                                        records[i].Shipments[j].Packages[h].IsDeleted, records[i].Shipments[j].Packages[h].PackageType, records[i].Shipments[j].Packages[h].Source, records[i].Shipments[j].Packages[h].InsuranceAmount,
                                        records[i].Shipments[j].Packages[h].Height, records[i].Shipments[j].Packages[h].Width, records[i].Shipments[j].Packages[h].Length, records[i].Shipments[j].Packages[h].Weight
                                    );
                                }
                            }
                        }
                    }

                    if (records[i].OrderInvoice != null)
                    {
                        orderInvoiceTable.Rows.Add(
                            records[i].OrderInvoice.lastupdateon, records[i].OrderInvoice.OrderInvoiceID, records[i].OrderInvoice.Code, records[i].OrderInvoice.Url, records[i].OrderInvoice.FulfillmentID, records[i].OrderInvoice.IsIssued, records[i].OrderInvoice.Series,
                            records[i].OrderInvoice.Number, records[i].OrderInvoice.CFOP, records[i].OrderInvoice.XML, records[i].OrderInvoice.InvoicePdf, records[i].OrderInvoice.Observation, records[i].OrderInvoice.Operation,
                            records[i].OrderInvoice.ProcessedAt, records[i].OrderInvoice.UpdatedAt, records[i].OrderInvoice.IssuedAt, records[i].OrderInvoice.CreatedAt, records[i].OrderInvoice.OrderID
                        );
                    }
                }

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "Order",
                     dataTable: orderTable,
                     dataTableRowsNumber: orderTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "Order", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "OrderItem",
                     dataTable: orderItemTable,
                     dataTableRowsNumber: orderItemTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "OrderItem", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "OrderTag",
                     dataTable: orderTagTable,
                     dataTableRowsNumber: orderTagTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "OrderTag", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "OrderAddress",
                     dataTable: orderAddressTable,
                     dataTableRowsNumber: orderAddressTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "OrderAddress", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "OrderPaymentMethod",
                     dataTable: orderPaymentMethodTable,
                     dataTableRowsNumber: orderPaymentMethodTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "OrderPaymentMethod", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "OrderPaymentInfo",
                     dataTable: orderPaymentInfoTable,
                     dataTableRowsNumber: orderPaymentInfoTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "OrderPaymentInfo", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "OrderDeliveryMethod",
                     dataTable: orderDeliveryMethodTable,
                     dataTableRowsNumber: orderDeliveryMethodTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "OrderDeliveryMethod", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "OrderDiscount",
                     dataTable: orderDiscountTable,
                     dataTableRowsNumber: orderDiscountTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "OrderDiscount", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "OrderShipment",
                     dataTable: orderShipmentTable,
                     dataTableRowsNumber: orderShipmentTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "OrderShipment", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "OrderPackage",
                     dataTable: orderPackageTable,
                     dataTableRowsNumber: orderPackageTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "OrderPackage", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "OrderInvoice",
                     dataTable: orderInvoiceTable,
                     dataTableRowsNumber: orderInvoiceTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "OrderInvoice", parentExecutionGUID);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool BulkInsertIntoUpdateTrackingNumberOrderTable(LinxCommerceJobParameter jobParameter, List<OrderTrackingNumber> records)
        {
            try
            {
                var orderTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Order.OrderTrackingNumber());

                for (int i = 0; i < records.Count(); i++)
                {
                    orderTable.Rows.Add(records[i].OrderID, records[i].OrderInvoiceID, records[i].OrderInvoiceCode, records[i].TrackingNumber);
                }

                _linxCommerceRepositoryBase.BulkInsertIntoTableTrusted(
                     jobName: jobParameter.jobName,
                     databaseName: jobParameter.databaseName,
                     dataTableName: "UpdateTrackingNumberOrder",
                     dataTable: orderTable,
                     dataTableRowsNumber: orderTable.Rows.Count
                );

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> InsertIntoUpdateTrackingNumberOrderTable(LinxCommerceJobParameter jobParameter, OrderTrackingNumber records)
        {
            try
            {
                string? sql = @$"INSERT INTO [linx_commerce].[{jobParameter.tableName}]
                            ([lastupdateon], [OrderID],[OrderInvoiceID],[OrderInvoiceCode],[TrackingNumber])
                            Values
                            (GETDATE(), @OrderID, @OrderInvoiceID, @OrderInvoiceCode, @TrackingNumber)";

                await _linxCommerceRepositoryBase.InsertRecord(
                     jobParameter: jobParameter,
                     sql: sql,
                     record: records
                );

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Domain.LinxCommerce.Entities.Order.Order.Root>> GetRegistersExists(IEnumerable<Guid?> guids)
        {
            string? identifiers = string.Empty;

            for (int i = 0; i < guids.Count(); i++)
            {

                if (i == guids.Count() - 1)
                    identifiers += $"'{guids.ElementAt(i)}'";
                else
                    identifiers += $"'{guids.ElementAt(i)}', ";
            }

            string? sql = $@"SELECT DISTINCT
							 A.[AcquiredDate],
							 A.[CancelledDate],
							 A.[CreatedDate],
							 A.[CustomerID],
							 A.[DeliveryAmount],
							 A.[DiscountAmount],
							 A.[GlobalStatus],
							 A.[HasConflicts],
							 A.[ItemsCount],
							 A.[ItemsQty],
							 A.[MarketPlaceBrand],
							 A.[ModifiedDate],
							 A.[OrderID],
							 A.[OrderNumber],
							 A.[OrderStatusID],
							 A.[PaymentDate],
							 A.[PaymentStatus],
							 A.[ShipmentDate],
							 A.[ShipmentStatus],
							 A.[SubTotal],
							 A.[TaxAmount],
							 A.[Total],
							 A.[TotalDue],
							 A.[TotalPaid],
							 A.[TotalRefunded],
							 A.[TrafficSourceID],
							 A.[WebSiteID],

							 B.[CFOP],
							 B.[Code],
							 B.[CreatedAt],
							 B.[FulfillmentID],
							 B.[IsIssued],
							 B.[IssuedAt],
							 B.[Number],
							 B.[Observation],
							 B.[Operation],
                             B.[OrderInvoiceID],
							 B.[ProcessedAt],
							 TRIM(B.[Series]) As Series,
							 B.[Url],
							 B.[XML],
                             B.[OrderID],

							 C.[CatalogID],
							 C.[CatalogItemType],
							 C.[DiscountAmount],
							 C.[InStockHandlingDays],
							 C.[IsDeleted],
							 C.[IsDeliverable],
							 C.[IsFreeOffer],
							 C.[IsFreeShipping],
							 C.[IsGiftWrapping],
							 C.[IsService],
							 C.[OrderID],
	                         C.[OrderItemID],
							 C.[OutStockHandlingDays],
							 C.[Price],
							 C.[PriceListID],
							 C.[ProductID],
							 C.[Qty],
							 C.[SkuID],
							 C.[SpecialType],
							 C.[Subtotal],
							 C.[SubtotalAdjustment],
							 C.[TaxationAmount],
							 C.[Total],
							 C.[WareHouseID],
							 C.[WebSiteID],

							 E.[AddressLine],
							 E.[AddressNotes],
							 E.[AddressType],
							 E.[City],
							 E.[ContactName],
							 E.[ContactPhone],
							 E.[Landmark],
							 E.[Name],
							 E.[Neighbourhood],
							 E.[Number],
							 E.[OrderAddressID],
							 E.[OrderID],
							 E.[PostalCode],
							 E.[State],

							 F.[Amount],
							 F.[CarrierName],
							 F.[DeliveryMethodID],
							 F.[LogisticContractId],
							 F.[LogisticContractName],
							 F.[LogisticOptionId],
							 F.[LogisticOptionName],
							 F.[OrderID],

                             D.[OrderPaymentMethodID],
                             D.[AcquiredDate],
							 D.[Amount],
							 D.[AmountNoInterest],
							 D.[CaptureDate],
							 D.[InstallmentAmount],
							 D.[Installments],
							 D.[IntegrationID],
							 D.[InterestValue],
							 D.[OrderID],
							 D.[PaidAmount],
							 D.[PaymentDate],
							 D.[PaymentMethodID],
							 D.[PaymentNumber],
							 D.[RefundAmount],
							 D.[Status],
							 D.[TaxAmount],
							 D.[TransactionID],

							 G.[Alias],
							 G.[ExpirationDate],
							 G.[Holder],
							 G.[Identifier],
							 G.[Month],
							 G.[NumberHint],
							 G.[PaymentDate],
							 G.[PaymentType],
							 G.[Provider],
							 G.[ReconciliationNumber],
							 G.[SecurityCodeHint],
							 G.[TransactionNumber],
							 G.[Year],
							 G.[OrderPaymentMethodID]

                             FROM [linx_commerce].[Order] A (NOLOCK)
                             LEFT JOIN [linx_commerce].[OrderInvoice] B (NOLOCK) ON A.OrderID = B.OrderID
                             LEFT JOIN [linx_commerce].[OrderItem] C (NOLOCK) ON A.OrderID = C.OrderID
							 LEFT JOIN [linx_commerce].[OrderAddress] E (NOLOCK) ON A.OrderID = E.OrderID
							 LEFT JOIN [linx_commerce].[OrderDeliveryMethod] F (NOLOCK) ON A.OrderID = F.OrderID
                             LEFT JOIN [linx_commerce].[OrderPaymentMethod] D (NOLOCK) ON A.OrderID = D.OrderID
							 LEFT JOIN [linx_commerce].[OrderPaymentInfo] G (NOLOCK) ON D.OrderPaymentMethodID = G.OrderPaymentMethodID
                             WHERE
                             A.OrderID IN ({identifiers})";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<
                        Domain.LinxCommerce.Entities.Order.Order.Root,
                        Domain.LinxCommerce.Entities.Order.OrderInvoice,
                        Domain.LinxCommerce.Entities.Order.OrderItem,
                        Domain.LinxCommerce.Entities.Order.OrderAddress,
                        Domain.LinxCommerce.Entities.Order.OrderDeliveryMethod,
                        Domain.LinxCommerce.Entities.Order.OrderPaymentMethod,
                        Domain.LinxCommerce.Entities.Order.OrderPaymentInfo,
                        Domain.LinxCommerce.Entities.Order.Order.Root
                    >(sql, (order, invoice, item, address, deliveryMethod, paymentMethod, paymentInfo) =>
                    {
                        order.OrderInvoice = invoice;
                        order.Items.Add(item);
                        order.Addresses.Add(address);
                        order.DeliveryMethods.Add(deliveryMethod);
                        order.PaymentMethods.Add(paymentMethod);

                        if (paymentInfo != null)
                        {
                            var _paymentInfo = order.PaymentMethods
                                .Where(x => x.OrderPaymentMethodID == paymentInfo.OrderPaymentMethodID)
                                .Select(y => y.PaymentInfo)
                                .First();

                            _paymentInfo.Identifier = paymentInfo.Identifier;
                            _paymentInfo.Alias = paymentInfo.Alias;
                            _paymentInfo.PaymentDate = paymentInfo.PaymentDate;
                            _paymentInfo.ExpirationDate = paymentInfo.ExpirationDate;
                            _paymentInfo.Month = paymentInfo.Month;
                            _paymentInfo.Year = paymentInfo.Year;
                            _paymentInfo.Holder = paymentInfo.Holder;
                            _paymentInfo.NumberHint = paymentInfo.NumberHint;
                            _paymentInfo.SecurityCodeHint = paymentInfo.SecurityCodeHint;
                            _paymentInfo.TransactionNumber = paymentInfo.TransactionNumber;
                            _paymentInfo.AuthorizationCode = paymentInfo.AuthorizationCode;
                            _paymentInfo.ReceiptCode = paymentInfo.ReceiptCode;
                            _paymentInfo.ReconciliationNumber = paymentInfo.ReconciliationNumber;
                            _paymentInfo.ConfirmationNumber = paymentInfo.ConfirmationNumber;
                            _paymentInfo.PaymentType = paymentInfo.PaymentType;
                            _paymentInfo.Provider = paymentInfo.Provider;
                            _paymentInfo.ProviderDocumentNumber = paymentInfo.ProviderDocumentNumber;
                            _paymentInfo.PixQRCode = paymentInfo.PixQRCode;
                            _paymentInfo.PixKey = paymentInfo.PixKey;
                        }

                        return order;
                    }, splitOn: "CFOP, CatalogID, AddressLine, Amount, OrderPaymentMethodID, Alias", commandTimeout: 360);

                    var resultGroupedByOrder = result
                        .GroupBy(p => p.OrderID)
                        .Select(g =>
                        {
                            var groupedResult = g.First();

                            if (!groupedResult.Items.Exists(x => x == null))
                            {
                                groupedResult.Items.AddRange(
                                    g
                                    .Select(p => p.Items.Single())
                                    .GroupBy(r => r.ProductID)
                                    .Select(a => a.First())
                                    .Where(x => !groupedResult.Items.Exists(y => y == x))
                                    .ToList()
                                );
                            }

                            if (!groupedResult.Addresses.Exists(x => x == null))
                            {
                                groupedResult.Addresses.AddRange(
                                    g
                                    .Select(p => p.Addresses.Single())
                                    .GroupBy(r => r.OrderAddressID)
                                    .Select(a => a.First())
                                    .Where(x => !groupedResult.Addresses.Exists(y => y == x))
                                    .ToList()
                                );
                            }

                            if (!groupedResult.DeliveryMethods.Exists(x => x == null))
                            {
                                groupedResult.DeliveryMethods.AddRange(
                                    g
                                    .Select(p => p.DeliveryMethods.Single())
                                    .GroupBy(r => r.OrderDeliveryMethodID)
                                    .Select(a => a.First())
                                    .Where(x => !groupedResult.DeliveryMethods.Exists(y => y == x))
                                    .ToList()
                                );
                            }

                            if (!groupedResult.PaymentMethods.Exists(x => x == null))
                            {
                                groupedResult.PaymentMethods.AddRange(
                                    g
                                    .Select(p => p.PaymentMethods.Single())
                                    .GroupBy(r => r.OrderPaymentMethodID)
                                    .Select(a => a.First())
                                    .Where(x => !groupedResult.PaymentMethods.Exists(y => y == x))
                                    .ToList()
                                );
                            }

                            return groupedResult;
                        })
                        .ToList();

                    return resultGroupedByOrder;
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    message: $"Error when trying to get records that already exist in trusted table - {ex.Message}",
                    exceptionMessage: ex.StackTrace,
                    commandSQL: sql
                );
            }
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.GetRegistersExists,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get records that already exist in trusted table",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<List<OrderTrackingNumber>> GetTrackingNumbersToUpdate()
        {
            string? sql = $@"SELECT DISTINCT
							 A.[OrderID],

							 B.[Code] AS OrderInvoiceCode,
                             B.[OrderInvoiceID],

							 D.[codigo] AS TrackingNumber

                             FROM [linx_commerce].[Order] A (NOLOCK)
                             JOIN [linx_commerce].[OrderInvoice] B (NOLOCK) ON A.OrderID = B.OrderID
                             LEFT JOIN [general].[JadLogPedidos] C (NOLOCK) ON A.OrderNumber = C.Pedido
							 LEFT JOIN [general].[JadLogTracking] D (NOLOCK) ON C.shipmentId = D.shipmentId
                             LEFT JOIN [linx_commerce].[UpdateTrackingNumberOrder] E (NOLOCK) ON A.OrderID = E.OrderID
                             WHERE
							 A.MODIFIEDDATE > GETDATE() - 7 AND
							 B.ORDERINVOICEID IS NOT NULL AND 
							 D.CODIGO IS NOT NULL AND
							 D.[STATUS] != 'ENTREGUE' AND
                             E.ORDERID IS NULL";

            //try
            //{
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result =  await conn.QueryAsync<OrderTrackingNumber>(sql);
                    return result.ToList();
                }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        //stage: EnumStages.GetRegistersExists,
            //        message: $"Error when trying to get records that already exist in trusted table"//,
            //        //exceptionMessage: ex.Message//,
            //        //commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.GetRegistersExists,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get records that already exist in trusted table",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }
    }
}
