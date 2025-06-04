using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Product;
using Domain.LinxCommerce.Entities.Sku;
using Domain.LinxCommerce.Interfaces.Repositorys;

namespace Infrastructure.LinxCommerce.Repositorys
{
    public class SKURepository : ISKURepository
    {
        private readonly ILinxCommerceRepositoryBase _linxCommerceRepositoryBase;

        public SKURepository(ILinxCommerceRepositoryBase linxCommerceRepositoryBase) =>
            _linxCommerceRepositoryBase = linxCommerceRepositoryBase;

        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Sku> records, Guid? parentExecutionGUID)
        {
            try
            {
                var skuTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Sku());
                var metadataValuesTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Sku.MetadataValue());
                var parentRelationsTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new ParentRelation());

                for (int i = 0; i < records.Count(); i++)
                {
                    skuTable.Rows.Add(records[i].lastupdateon, records[i].UPC, records[i].DisplayCondition, records[i].DefinitionID, records[i].SuppliersIDs, records[i].ParentsIDs, records[i].ConditionID, records[i].UnitOfMeasureID, records[i].ManageStock, records[i].MinimumQtyAllowed,
                        records[i].MaximumQtyAllowed, records[i].Preorderable, records[i].PreorderDate, records[i].PreorderLimit, records[i].Backorderable, records[i].BackorderLimit, records[i].PurchasingPolicyID,
                        records[i].WrappingQty, records[i].Weight, records[i].Height, records[i].Width, records[i].Depth, records[i].Cost, records[i].Tax, records[i].IsVisible, records[i].VisibleFrom, records[i].VisibleTo,
                        records[i].IsDeleted, records[i].ProductID, records[i].Name, records[i].SKU, records[i].CreatedDate, records[i].CreatedBy, records[i].ModifiedDate, records[i].ModifiedBy, records[i].IntegrationID);
                
                    for (int j = 0; j < records[i].MetadataValues.Count(); j++)
                    {
                        metadataValuesTable.Rows.Add(records[i].MetadataValues[j].lastupdateon, records[i].MetadataValues[j].ProductID, records[i].MetadataValues[j].PropertyMetadataID, records[i].MetadataValues[j].PropertyName, records[i].MetadataValues[j].PropertyGroup,
                            records[i].MetadataValues[j].InputType, records[i].MetadataValues[j].Value, records[i].MetadataValues[j].SerializedValue, records[i].MetadataValues[j].SerializedBlobValue, records[i].MetadataValues[j].IntegrationID, records[i].MetadataValues[j].FormattedValue,
                            records[i].MetadataValues[j].DisplayName
                        );
                    }

                    for (int h = 0; h < records[i].ParentRelations.Count(); h++)
                    {
                        parentRelationsTable.Rows.Add(records[i].ParentRelations[h].lastupdateon, records[i].ParentRelations[h].ParentID, records[i].ParentRelations[h].ParentSKU, records[i].ParentRelations[h].ParentIntegrationID, records[i].ParentRelations[h].ProductID);
                    }
                };

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                        jobName: jobParameter.jobName,
                        databaseName: jobParameter.databaseName,
                        dataTableName: "SKU",
                        dataTable: skuTable,
                        dataTableRowsNumber: skuTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "SKU", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                        jobName: jobParameter.jobName,
                        databaseName: jobParameter.databaseName,
                        dataTableName: "SKUMetadataValue",
                        dataTable: metadataValuesTable,
                        dataTableRowsNumber: metadataValuesTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "SKUMetadataValue", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                        jobName: jobParameter.jobName,
                        databaseName: jobParameter.databaseName,
                        dataTableName: "SKUParentRelation",
                        dataTable: parentRelationsTable,
                        dataTableRowsNumber: parentRelationsTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "SKUParentRelation", parentExecutionGUID);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Product> records, Guid? parentExecutionGUID)
        {
            try
            {
                var productTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Product());
                var imageTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Image());
                var mediaAssociationTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new MediaAssociation());
                var metadataValueTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.Product.MetadataValue());
                var midiaTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Midia());
                var videoTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Video());

                for (int i = 0; i < records.Count(); i++)
                {
                    productTable.Rows.Add(records[i].lastupdateon, records[i].BrandID, records[i].SkusIDs, records[i].FlagsIDs, records[i].RatingSetID, records[i].MediasIDs, records[i].CategoriesIDs, records[i].CatalogItemType, records[i].PurchasingPolicyID, records[i].IsFreeShipping,
                        records[i].ShippingRegionsIDs, records[i].SearchKeywords, records[i].PageTitle, records[i].UrlFriendly, records[i].MetaDescription, records[i].MetaKeywords, records[i].ShortDescription,
                        records[i].LongDescription, records[i].WarrantyDescription, records[i].TagsIDs, records[i].IsVisible, records[i].VisibleFrom, records[i].VisibleTo, records[i].IsSearchable, records[i].IsUponRequest, records[i].DisplayAvailability, records[i].DisplayStockQty,
                        records[i].DisplayPrice, records[i].IsNew, records[i].NewFrom, records[i].NewTo, records[i].IsGift, records[i].UseAcceptanceTerm, records[i].AcceptanceTermID, records[i].DefinitionID, records[i].IsDeleted, records[i].SendToMarketplace, records[i].ProductID, 
                        records[i].Name, records[i].SKU, records[i].CreatedDate, records[i].CreatedBy, records[i].ModifiedDate, records[i].ModifiedBy, records[i].IntegrationID);

                    for (int j = 0; j < records[i].MetadataValues.Count(); j++)
                    {
                        metadataValueTable.Rows.Add(records[i].MetadataValues[j].lastupdateon, records[i].MetadataValues[j].PropertyMetadataID, records[i].MetadataValues[j].ProductID, records[i].MetadataValues[j].PropertyName, records[i].MetadataValues[j].DisplayName,
                            records[i].MetadataValues[j].FormattedValue, records[i].MetadataValues[j].PropertyGroup
                        );
                    }

                    for (int h = 0; h < records[i].Medias.Count(); h++)
                    {
                        midiaTable.Rows.Add(records[i].Medias[h].lastupdateon, records[i].Medias[h].MediaID, records[i].Medias[h].IsDeleted, records[i].Medias[h].Index, records[i].Medias[h].CreatedDate, records[i].Medias[h].Type, records[i].Medias[h].ParentMediaID, records[i].Medias[h].OriginalFileName);
                        imageTable.Rows.Add(records[i].Medias[h].Image.lastupdateon, records[i].Medias[h].Image.RelativePath, records[i].Medias[h].Image.Extension, records[i].Medias[h].Image.MaxWidth, records[i].Medias[h].Image.MaxHeight, records[i].Medias[h].Image.Width, records[i].Medias[h].Image.Height, records[i].Medias[h].Image.MediaSizeType, records[i].Medias[h].Image.AbsolutePath, records[i].Medias[h].Image.MediaID);
                        videoTable.Rows.Add(records[i].Medias[h].Video.lastupdateon, records[i].Medias[h].Video.Title, records[i].Medias[h].Video.Url, records[i].Medias[h].Video.MediaID);
                    }

                    for (int z = 0; z < records[i].MediaAssociations.Count(); z++)
                    {
                        mediaAssociationTable.Rows.Add(records[i].MediaAssociations[z].lastupdateon, records[i].MediaAssociations[z].ID, records[i].MediaAssociations[z].ProductID, records[i].MediaAssociations[z].MediaID, records[i].MediaAssociations[z].Path, records[i].MediaAssociations[z].Order);
                    }
                };

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                        jobName: jobParameter.jobName,
                        databaseName: jobParameter.databaseName,
                        dataTableName: "Product",
                        dataTable: productTable,
                        dataTableRowsNumber: productTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "Product", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                        jobName: jobParameter.jobName,
                        databaseName: jobParameter.databaseName,
                        dataTableName: "ProductMetadataValues",
                        dataTable: metadataValueTable,
                        dataTableRowsNumber: metadataValueTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "ProductMetadataValues", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                        jobName: jobParameter.jobName,
                        databaseName: jobParameter.databaseName,
                        dataTableName: "ProductMediaAssociations",
                        dataTable: mediaAssociationTable,
                        dataTableRowsNumber: mediaAssociationTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "ProductMediaAssociations", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                        jobName: jobParameter.jobName,
                        databaseName: jobParameter.databaseName,
                        dataTableName: "ProductMedia",
                        dataTable: midiaTable,
                        dataTableRowsNumber: midiaTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "ProductMedia", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                        jobName: jobParameter.jobName,
                        databaseName: jobParameter.databaseName,
                        dataTableName: "ProductMediaVideo",
                        dataTable: videoTable,
                        dataTableRowsNumber: videoTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "ProductMediaVideo", parentExecutionGUID);

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                        jobName: jobParameter.jobName,
                        databaseName: jobParameter.databaseName,
                        dataTableName: "ProductMediaImage",
                        dataTable: imageTable,
                        dataTableRowsNumber: imageTable.Rows.Count
                );

                _linxCommerceRepositoryBase.CallDbProcMerge(jobParameter.schema, "ProductMediaImage", parentExecutionGUID);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool> InsertRecord(LinxCommerceJobParameter jobParameter, Sku? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([UPC], [DisplayCondition], [DefinitionID], [ConditionID], [UnitOfMeasureID], [ManageStock], [MinimumQtyAllowed], [MaximumQtyAllowed], [Preorderable], [PreorderDate], [PreorderLimit], [Backorderable], " +
                          "[BackorderLimit], [PurchasingPolicyID], [WrappingQty], [Weight], [Height], [Width], [Depth], [Cost], [Tax], [IsVisible], [VisibleFrom], [VisibleTo], [IsDeleted], [ProductID], [Name], [SKU], [CreatedDate], [CreatedBy], " +
                          "[ModifiedDate], [ModifiedBy], [IntegrationID], [lastupdateon]) " +
                          "Values " +
                          "(@UPC, @DisplayCondition, @DefinitionID, @ConditionID, @UnitOfMeasureID, @ManageStock, @MinimumQtyAllowed, @MaximumQtyAllowed, @Preorderable, @PreorderDate, @PreorderLimit, @Backorderable, @BackorderLimit, @PurchasingPolicyID, " +
                          "@WrappingQty, @Weight, @Height, @Width, @Depth, @Cost, @Tax, @IsVisible, @VisibleFrom, @VisibleTo, @IsDeleted, @ProductID, @Name, @SKU, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy, @IntegrationID, GETDATE())";

            try
            {
                return await _linxCommerceRepositoryBase.InsertRecord(jobParameter: jobParameter, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
