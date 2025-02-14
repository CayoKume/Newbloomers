using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Repositorys.Base;
using Domain.LinxCommerce.Interfaces.Repositorys.Order;
using Infrastructure.IntegrationsCore.Connections.SQLServer;

namespace Infrastructure.LinxCommerce.Repositorys.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ILinxCommerceRepositoryBase _linxCommerceRepositoryBase;
        private readonly ISQLServerConnection _sqlServerConnection;

        public OrderRepository(ILinxCommerceRepositoryBase linxCommerceRepositoryBase, ISQLServerConnection sqlServerConnection) =>
            (_linxCommerceRepositoryBase, _sqlServerConnection) = (linxCommerceRepositoryBase, sqlServerConnection);

        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Domain.LinxCommerce.Entities.Order.Order.Root> records)
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
                        records[i].OrderID, records[i].OrderNumber, records[i].MarketPlaceBrand, records[i].OriginalOrderID, records[i].WebSiteID, records[i].WebSiteIntegrationID, records[i].CustomerID, 
                        records[i].ShopperTicketID, records[i].ItemsQty, records[i].ItemsCount, records[i].TaxAmount, records[i].DeliveryAmount, records[i].DiscountAmount, records[i].PaymentTaxAmount, records[i].SubTotal,
                        records[i].Total, records[i].TotalDue, records[i].TotalPaid, records[i].TotalRefunded, records[i].PaymentDate, records[i].PaymentStatus, records[i].ShipmentDate, records[i].ShipmentStatus,
                        records[i].GlobalStatus, records[i].DeliveryPostalCode, records[i].CreatedChannel, records[i].TrafficSourceID, records[i].OrderStatusID, records[i].CreatedDate, records[i].CreatedBy, records[i].ModifiedDate, 
                        records[i].ModifiedBy, records[i].Remarks, records[i].SellerCommissionAmount, records[i].CommissionAmount, records[i].OrderGroupID, records[i].OrderGroupNumber, records[i].HasConflicts, records[i].AcquiredDate,
                        records[i].HasHubOrderWithoutShipmentConflict, records[i].CustomerType, records[i].CancelledDate, records[i].WebSiteName, records[i].CustomerName, records[i].CustomerEmail, records[i].CustomerGender,
                        records[i].CustomerBirthDate, records[i].CustomerPhone, records[i].CustomerCPF, records[i].CustomerCNPJ, records[i].CustomerTradingName, records[i].CustomerSiteTaxPayer
                    );

                    if (records[i].Items.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Items.Count(); j++)
                        {
                            orderItemTable.Rows.Add(
                                records[i].Items[j].OrderItemID, records[i].Items[j].OrderID, records[i].Items[j].ParentItemID, records[i].Items[j].ProductID, records[i].Items[j].SkuID, records[i].Items[j].SKU, records[i].Items[j].SellerSKU, 
                                records[i].Items[j].WebSiteID, records[i].Items[j].CatalogID, records[i].Items[j].PriceListID, records[i].Items[j].WareHouseID, records[i].Items[j].WarehouseIntegrationID, records[i].Items[j].Qty, records[i].Items[j].Price,
                                records[i].Items[j].DiscountAmount, records[i].Items[j].TaxationAmount, records[i].Items[j].Subtotal, records[i].Items[j].Total, records[i].Items[j].IsFreeShipping, records[i].Items[j].IsDeleted, records[i].Items[j].Status, 
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
                            orderTagTable.Rows.Add(records[i].Tags[j].TagID, records[i].Tags[j].Alias, records[i].Tags[j].Name, records[i].Tags[j].IsSystem, records[i].Tags[j].IsDeleted);
                        }
                    }

                    if (records[i].Addresses.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Addresses.Count(); j++)
                        {
                            orderAddressTable.Rows.Add(
                                records[i].Addresses[j].OrderAddressID, records[i].Addresses[j].OrderID, records[i].Addresses[j].Name, records[i].Addresses[j].AddressLine, records[i].Addresses[j].City, records[i].Addresses[j].Neighbourhood,
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
                                records[i].PaymentMethods[j].OrderPaymentMethodID, records[i].PaymentMethods[j].OrderID, records[i].PaymentMethods[j].PaymentNumber, records[i].PaymentMethods[j].PaymentMethodID, records[i].PaymentMethods[j].TransactionID,
                                records[i].PaymentMethods[j].ReconciliationNumber, records[i].PaymentMethods[j].Status, records[i].PaymentMethods[j].IntegrationID, records[i].PaymentMethods[j].Amount, records[i].PaymentMethods[j].AmountNoInterest, records[i].PaymentMethods[j].InterestValue,
                                records[i].PaymentMethods[j].PaidAmount, records[i].PaymentMethods[j].RefundAmount, records[i].PaymentMethods[j].Installments, records[i].PaymentMethods[j].InstallmentAmount, records[i].PaymentMethods[j].TaxAmount, records[i].PaymentMethods[j].PaymentDate,
                                records[i].PaymentMethods[j].CaptureDate, records[i].PaymentMethods[j].AcquiredDate, records[i].PaymentMethods[j].PaymentCancelledDate
                            );

                            orderPaymentInfoTable.Rows.Add(
                                records[i].PaymentMethods[j].PaymentInfo.Identifier, records[i].PaymentMethods[j].PaymentInfo.Alias, records[i].PaymentMethods[j].PaymentInfo.PaymentDate, records[i].PaymentMethods[j].PaymentInfo.ExpirationDate, records[i].PaymentMethods[j].PaymentInfo.Month,
                                records[i].PaymentMethods[j].PaymentInfo.Year, records[i].PaymentMethods[j].PaymentInfo.Holder, records[i].PaymentMethods[j].PaymentInfo.NumberHint, records[i].PaymentMethods[j].PaymentInfo.SecurityCodeHint, records[i].PaymentMethods[j].PaymentInfo.TransactionNumber,
                                records[i].PaymentMethods[j].PaymentInfo.AuthorizationCode, records[i].PaymentMethods[j].PaymentInfo.ReceiptCode, records[i].PaymentMethods[j].PaymentInfo.ReconciliationNumber, records[i].PaymentMethods[j].PaymentInfo.ConfirmationNumber, records[i].PaymentMethods[j].PaymentInfo.PaymentType,
                                records[i].PaymentMethods[j].PaymentInfo.Provider, records[i].PaymentMethods[j].PaymentInfo.ProviderDocumentNumber, records[i].PaymentMethods[j].PaymentInfo.PixQRCode, records[i].PaymentMethods[j].PaymentInfo.PixKey, records[i].PaymentMethods[j].PaymentInfo.OrderID,
                                records[i].PaymentMethods[j].PaymentInfo.OrderPaymentMethodID, records[i].PaymentMethods[j].PaymentInfo.PaymentMethodID, records[i].PaymentMethods[j].PaymentInfo.TransactionID, records[i].PaymentMethods[j].PaymentInfo.Status, records[i].PaymentMethods[j].PaymentInfo.Title,
                                records[i].PaymentMethods[j].PaymentInfo.Description, records[i].PaymentMethods[j].PaymentInfo.ImagePath
                            );
                        }
                    }

                    if (records[i].DeliveryMethods.Count() > 0)
                    {
                        for (int j = 0; j < records[i].DeliveryMethods.Count(); j++)
                        {
                            orderDeliveryMethodTable.Rows.Add(
                                records[i].DeliveryMethods[j].LogisticOptionId, records[i].DeliveryMethods[j].LogisticOptionName, records[i].DeliveryMethods[j].LogisticContractId, records[i].DeliveryMethods[j].LogisticContractName, records[i].DeliveryMethods[j].OrderDeliveryMethodID,
                                records[i].DeliveryMethods[j].OrderID, records[i].DeliveryMethods[j].DeliveryMethodID, records[i].DeliveryMethods[j].DeliveryGroupID, records[i].DeliveryMethods[j].Amount, records[i].DeliveryMethods[j].ETA, records[i].DeliveryMethods[j].ETADays,
                                records[i].DeliveryMethods[j].IntegrationID, records[i].DeliveryMethods[j].ScheduleShiftID, records[i].DeliveryMethods[j].ScheduleDisplayName, records[i].DeliveryMethods[j].ScheduleTax, records[i].DeliveryMethods[j].ScheduleDate,
                                records[i].DeliveryMethods[j].DeliveryMethodAlias, records[i].DeliveryMethods[j].PointOfSaleID, records[i].DeliveryMethods[j].PointOfSaleIntegrationID, records[i].DeliveryMethods[j].PointOfSaleName, records[i].DeliveryMethods[j].DeliveryMethodType,
                                records[i].DeliveryMethods[j].ExternalID, records[i].DeliveryMethods[j].WarehouseID, records[i].DeliveryMethods[j].WarehouseIntegrationID, records[i].DeliveryMethods[j].DockID, records[i].DeliveryMethods[j].CarrierName, records[i].DeliveryMethods[j].DeliveryEstimatedDate
                            );
                        }
                    }

                    if (records[i].Discounts.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Discounts.Count(); j++)
                        {
                            orderDiscountTable.Rows.Add(
                                records[i].Discounts[j].DiscountID, records[i].Discounts[j].Reference, records[i].Discounts[j].Amount, records[i].Discounts[j].Message, records[i].Discounts[j].Type
                            );
                        }
                    }

                    if (records[i].Shipments.Count() > 0)
                    {
                        for (int j = 0; j < records[i].Shipments.Count(); j++)
                        {
                            orderShipmentTable.Rows.Add(
                                records[i].Shipments[j].OrderShipmentID, records[i].Shipments[j].OrderID, records[i].Shipments[j].DeliveryMethodID, records[i].Shipments[j].ShipmentNumber, records[i].Shipments[j].ShipmentStatus,
                                records[i].Shipments[j].AssignUserId, records[i].Shipments[j].AssignUserName, records[i].Shipments[j].DockID
                            );

                            if (records[i].Shipments[j].Packages.Count() > 0)
                            {
                                for (int h = 0; h < records[i].Shipments[j].Packages.Count(); h++)
                                {
                                    orderPackageTable.Rows.Add(
                                        records[i].Shipments[j].Packages[h].OrderPackageID, records[i].Shipments[j].Packages[h].OrderShipmentID, records[i].Shipments[j].Packages[h].DeliveryMethodID, records[i].Shipments[j].Packages[h].PackageNumber,
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
                            records[i].OrderInvoice.OrderInvoiceID, records[i].OrderInvoice.Code, records[i].OrderInvoice.Url, records[i].OrderInvoice.FulfillmentID, records[i].OrderInvoice.IsIssued, records[i].OrderInvoice.Series,
                            records[i].OrderInvoice.Number, records[i].OrderInvoice.CFOP, records[i].OrderInvoice.XML, records[i].OrderInvoice.InvoicePdf, records[i].OrderInvoice.Observation, records[i].OrderInvoice.Operation,
                            records[i].OrderInvoice.ProcessedAt, records[i].OrderInvoice.UpdatedAt, records[i].OrderInvoice.IssuedAt, records[i].OrderInvoice.CreatedAt, records[i].OrderInvoice.ID
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

                //_linxCommerceRepositoryBase.CallDbProcMerge();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Domain.LinxCommerce.Entities.Order.Order.Root>> GetRegistersExists(List<string> guids)
        {
            string? identifiers = String.Empty;

            for (int i = 0; i < guids.Count(); i++)
            {

                if (i == guids.Count() - 1)
                    identifiers += $"{guids.ElementAt(i)}";
                else
                    identifiers += $"{guids.ElementAt(i)}, ";
            }

            throw new NotImplementedException();
        }
    }
}
