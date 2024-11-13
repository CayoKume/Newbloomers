using IntegrationsCore.Domain.Entities.Parameters;
using LinxCommerce.Domain.Entities.Catolog.Sku;
using LinxCommerce.Infrastructure.Repository.Base;

namespace LinxCommerce.Infrastructure.Repository.Catolog.SKURepository
{
    public class SKURepository : ISKURepository
    {
        private readonly ILinxCommerceRepositoryBase<SKUs> _linxCommerceRepositoryBase;

        public SKURepository(ILinxCommerceRepositoryBase<SKUs> linxCommerceRepositoryBase) =>
            (_linxCommerceRepositoryBase) = (linxCommerceRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<SKUs> records)
        {
            try
            {
                var table = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new SKUs());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].UPC, records[i].DisplayCondition, records[i].DefinitionID, records[i].ConditionID, records[i].UnitOfMeasureID, records[i].ManageStock, records[i].MinimumQtyAllowed,
                        records[i].MaximumQtyAllowed, records[i].Preorderable, records[i].PreorderDate, records[i].PreorderLimit, records[i].Backorderable, records[i].BackorderLimit, records[i].PurchasingPolicyID,
                        records[i].WrappingQty, records[i].Weight, records[i].Height, records[i].Width, records[i].Depth, records[i].Cost, records[i].Tax, records[i].IsVisible, records[i].VisibleFrom, records[i].VisibleTo,
                        records[i].IsDeleted, records[i].ProductID, records[i].Name, records[i].SKU, records[i].CreatedDate, records[i].CreatedBy, records[i].ModifiedDate, records[i].ModifiedBy, records[i].IntegrationID);
                };

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobParameter: jobParameter,
                    dataTable: table,
                    dataTableRowsNumber: table.Rows.Count
                );

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CreateTableMerge(LinxCommerceJobParameter jobParameter)
        {
            string? sql = @"";

            try
            {
                return await _linxCommerceRepositoryBase.ExecuteQueryCommand(jobParameter: jobParameter, sql: sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertParametersIfNotExists(LinxCommerceJobParameter jobParameter)
        {
            try
            {
                return await _linxCommerceRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        parameters_timestamp = @"",
                        parameters_dateinterval = @"",
                        parameters_individual = @"",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxCommerceJobParameter jobParameter, SKUs? record)
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
