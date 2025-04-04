using Domain.LinxCommerce.Entities.Parameters;
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
                var metadataValuesTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new MetadataValue());
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
