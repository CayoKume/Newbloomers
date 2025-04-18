using Application.IntegrationsCore.Interfaces;
using Application.LinxCommerce.Interfaces;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Product;
using Domain.LinxCommerce.Entities.Responses;
using Domain.LinxCommerce.Entities.Sku;
using Domain.LinxCommerce.Interfaces.Api;
using Domain.LinxCommerce.Interfaces.Repositorys;
using FluentValidation;

namespace Application.LinxCommerce.Services
{
    public class SKUService : ISKUService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxCommerceRepositoryBase _linxCommerceRepositoryBase;
        private readonly IValidator<Sku> _validator;
        private readonly IValidator<Product> _productValidator;
        private readonly ISKURepository _skuRepository;

        public SKUService(IAPICall apiCall, ILoggerService logger, ILinxCommerceRepositoryBase linxCommerceRepositoryBase, IValidator<Sku> validator, IValidator<Product> productValidator, ISKURepository skuRepository) =>
            (_apiCall, _logger, _linxCommerceRepositoryBase, _validator, _productValidator, _skuRepository) = (apiCall, logger, linxCommerceRepositoryBase, validator, productValidator, skuRepository);

        public Task<bool?> ActivateProduct(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> AddProductAssociation(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> AddProductAssociations(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> AddProductToBundle(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> AddSKUsToProducts(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> AddSkuToMix(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> AddSKUToProduct(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> ChangeSKUInventories(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> ChangeSKUInventory(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteAssociationList(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteBrand(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteBundle(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteCatalog(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteCatalogMedia(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteCategory(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteCategoryGroup(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteConditionalProductPrice(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteConditionalProductPrices(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteFlag(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteOffer(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteProduct(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteProductAdditional(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteProductAdditionalList(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteProductAuction(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteProductAuctionBid(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteProductBySku(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteProductDataSource(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteProductPriceChange(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteSKU(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteSKUBySku(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteTag(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteWarehouse(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DesactivateBrand(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DisableProductByIntegrationID(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> Dump(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> EditMixRelation(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> EditProductBundleRelation(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetAssociationList(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetBrand(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetBundle(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetBundleBySku(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCatalog(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCategory(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCategoryGroup(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCategoryProperties(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCategoryPropertyValues(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetDeletedProduct(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetDeletedSKU(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetFlag(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetMasterCatalog(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetMix(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetMixRelation(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetOffer(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProduct(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductAdditional(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductAdditionalList(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductAuction(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductAuctionBids(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductBundleRelation(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductByIntegrationID(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductCategories(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductCondition(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductDataSource(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductDefinition(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductIDBySkuIntegrationID(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductPrice(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductPriceChange(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductPriceChanges(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductsByIntegrationID(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetProductSEO(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> GetSKU(LinxCommerceJobParameter jobParameter, int productID)
        {
            try
            {
                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    intIdentifier: productID,
                    route: "/v1/Catalog/API.svc/web/GetSKU"
                );

                var skus = Newtonsoft.Json.JsonConvert.DeserializeObject<Sku>(response);

                //await _skuRepository.InsertRecord(jobParameter, skus);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public Task<bool?> GetSKU(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetSKUByIntegrationID(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetSKUsByIntegrationID(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetSupplier(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetTag(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetUnitOfMeasure(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetWarehouse(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetWarehouseByIntegrationID(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> MakeProductAuctionTransition(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> MergeConditionalProductPrice(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> MergeConditionalProductPrices(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> MoveCategory(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RemoveCatalogItem(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RemoveProductAssociation(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RemoveProductAssociations(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RemoveProductFromBundle(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RemoveSKUFromMix(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RemoveSKUFromProduct(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RunProductWorkflow(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveAssociationList(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveAssociationLists(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveBrand(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveBrands(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveBundle(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveBundles(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCatalog(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCatalogMedia(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCatalogMixMedia(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCatalogs(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCategories(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCategory(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCategoryGroup(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCategoryGroups(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveFlag(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveFlags(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveMix(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveMixes(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveOffer(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveOffers(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProduct(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductAdditional(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductAdditionalList(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductAuction(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductAuctionBid(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductDataSource(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductDefinition(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductPrice(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductPriceBulk(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductPriceChange(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductPriceChanges(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductPrices(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductReview(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProductReviews(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveProducts(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveSKU(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveSKUs(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveSKUToProduct(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveSupplier(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveSuppliers(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveTag(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveTags(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveUnitOfMeasure(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveUnitOfMeasures(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveWarehouse(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveWarehouses(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchAssociationList(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchBrands(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchBundle(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchCatalog(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchCategory(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchCategoryGroups(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchFlag(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchMix(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchOffers(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> SearchProductByDateInterval(LinxCommerceJobParameter jobParameter)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxCommerceProduct);

                var objectRequest = new
                {
                    Page = new { PageIndex = 0, PageSize = 10000 },
                    Where = $"(CreatedDate>=\"{DateTime.Now.Date:yyyy-MM-dd}T00:00:00\" && CreatedDate<=\"{DateTime.Now.Date:yyyy-MM-dd}T23:59:59\")",
                    WhereMetadata = "",
                    OrderBy = "ProductID",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter,
                    objectRequest,
                    "/v1/Catalog/API.svc/web/SearchProduct"
                );

                var productAPIList = new List<Product>();
                var productsIDs = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchProducts.Root>(response);
                var groupedIDs = productsIDs.Result.GroupBy(x => x.ProductID).Select(g => g.First()).ToList();

                foreach (var productID in groupedIDs)
                {
                    string route = String.Empty;

                    var getProductResponse = await _apiCall.PostRequest(
                        jobParameter: jobParameter,
                        intIdentifier: productID.ProductID,
                        route: "/v1/Catalog/API.svc/web/GetProduct"
                    );

                    var product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(getProductResponse);
                    var validations = _productValidator.Validate(product);

                    if (validations.Errors.Count() > 0)
                    {
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            _logger.AddMessage(
                                stage: EnumStages.DeserializeXMLToObject,
                                error: EnumError.Validation,
                                logLevel: EnumMessageLevel.Warning,
                                message: $"Error when convert record - ProductID: {product.ProductID} | Name: {product.Name}\n" +
                                         $"{validations.Errors[j]}"
                            );
                        }
                    }

                    productAPIList.Add(new Product(product, getProductResponse));
                }

                if (productAPIList.Count() > 0)
                {
                    _skuRepository.BulkInsertIntoTableRaw(jobParameter, productAPIList, _logger.GetExecutionGuid());

                    productAPIList.ForEach(p =>
                        _logger.AddRecord(
                            p.ProductID.ToString(),
                            p.Responses
                                .Where(pair => pair.Key == p.ProductID)
                                .Select(pair => pair.Value)
                                .FirstOrDefault()
                        )
                    );

                    _logger.AddMessage(
                        $"Concluída com sucesso: {productAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );
                }
                else
                    _logger.AddMessage(
                        $"Concluída com sucesso: {productAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );

                return true;
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return true;
        }

        public async Task<bool?> SearchProductByQueue(LinxCommerceJobParameter jobParameter)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxCommerceProduct);

                var objectRequest = new
                {
                    QueueID = 21,
                    Page = new { PageIndex = 0, PageSize = 1000 },
                    Where = $"EntityKeyName==\"CatalogItemID\" && EntityTypeName==\"EZ.Store.Model.Catalog.Product\"",
                    WhereMetadata = "",
                    OrderBy = "QueueItemID",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter,
                    objectRequest,
                    "/v1/Queue/API.svc/web/SearchQueueItems"
                );

                var productAPIList = new List<Product>();
                var enqueuedItens = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchQueuedItem.Root>(response);
                var enqueuedProducts = enqueuedItens
                                    .Result
                                    .Where(x => x.EntityKeyName == "CatalogItemID")
                                    .GroupBy(y => y.EntityKeyValue)
                                    .Select(g => g.First())
                                    .ToList();

                foreach (var enqueuedProduct in enqueuedProducts)
                {
                    string route = String.Empty;

                    var getProductResponse = await _apiCall.PostRequest(
                        jobParameter: jobParameter,
                        intIdentifier: Convert.ToInt32(enqueuedProduct.EntityKeyValue),
                        route: "/v1/Catalog/API.svc/web/GetProduct"
                    );

                    var product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(getProductResponse);
                    var validations = _productValidator.Validate(product);

                    if (validations.Errors.Count() > 0)
                    {
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            _logger.AddMessage(
                                stage: EnumStages.DeserializeXMLToObject,
                                error: EnumError.Validation,
                                logLevel: EnumMessageLevel.Warning,
                                message: $"Error when convert record - ProductID: {product.ProductID} | Name: {product.Name}\n" +
                                         $"{validations.Errors[j]}"
                            );
                        }
                    }

                    productAPIList.Add(new Product(product, getProductResponse));
                }

                if (productAPIList.Count() > 0)
                {
                    _skuRepository.BulkInsertIntoTableRaw(jobParameter, productAPIList, _logger.GetExecutionGuid());

                    productAPIList.ForEach(p =>
                        _logger.AddRecord(
                            p.ProductID.ToString(),
                            p.Responses
                                .Where(pair => pair.Key == p.ProductID)
                                .Select(pair => pair.Value)
                                .FirstOrDefault()
                        )
                    );

                    _logger.AddMessage(
                        $"Concluída com sucesso: {productAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );

                    //remover da fila de integração apenas se o registro for inserido no banco de dados
                    var listQueueItemID = new List<string>();

                    foreach (var enqueuedproduct in enqueuedProducts)
                    {
                        listQueueItemID.Add(enqueuedproduct.QueueItemID);
                    }

                    var dequeueObjectRequest = new { QueueItems = listQueueItemID };

                    var dequeueResponse = await _apiCall.PostRequest(
                        jobParameter,
                        dequeueObjectRequest,
                        "/v1/Queue/API.svc/web/DequeueQueueItems"
                    );
                }
                else
                    _logger.AddMessage(
                        $"Concluída com sucesso: {productAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );

                return true;
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return true;
        }

        public Task<bool?> SearchProductAdditionalLists(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchProductAdditionals(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchProductAuctions(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchProductConditions(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchProductDataSource(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchProductDefinitions(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchProductPrices(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchProductReviews(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchProductShortDefinitions(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> SearchSKUByDateInterval(LinxCommerceJobParameter jobParameter)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxCommerceSku);

                var objectRequest = new
                {
                    Page = new { PageIndex = 0, PageSize = 1000 },
                    Where = $"(CreatedDate>=\"{DateTime.Now.AddDays(-1).Date:yyyy-MM-dd}T00:00:00\" && CreatedDate<=\"{DateTime.Now.Date:yyyy-MM-dd}T23:59:59\")",
                    WhereMetadata = "",
                    OrderBy = "ProductID",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter,
                    objectRequest,
                    "/v1/Catalog/API.svc/web/SearchSKU"
                );

                var skuAPIList = new List<Sku>();
                var productsIDs = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchSKU.Root>(response);

                foreach (var productID in productsIDs.Result)
                {
                    string route = String.Empty;

                    var getSkuResponse = await _apiCall.PostRequest(
                        jobParameter: jobParameter,
                        intIdentifier: productID.ProductID,
                        route: "/v1/Catalog/API.svc/web/GetSKU"
                    );

                    var sku = Newtonsoft.Json.JsonConvert.DeserializeObject<Sku>(getSkuResponse);
                    var validations = _validator.Validate(sku);

                    if (validations.Errors.Count() > 0)
                    {
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            _logger.AddMessage(
                                stage: EnumStages.DeserializeXMLToObject,
                                error: EnumError.Validation,
                                logLevel: EnumMessageLevel.Warning,
                                message: $"Error when convert record - ProductID: {sku.ProductID} | Name: {sku.Name}\n" +
                                         $"{validations.Errors[j]}"
                            );
                        }
                    }

                    skuAPIList.Add(new Sku(sku, getSkuResponse));
                }

                if (skuAPIList.Count() > 0)
                {
                    _skuRepository.BulkInsertIntoTableRaw(jobParameter, skuAPIList, _logger.GetExecutionGuid());

                    skuAPIList.ForEach(p =>
                        _logger.AddRecord(
                            p.ProductID.ToString(),
                            p.Responses
                                .Where(pair => pair.Key == p.ProductID)
                                .Select(pair => pair.Value)
                                .FirstOrDefault()
                        )
                    );

                    _logger.AddMessage(
                        $"Concluída com sucesso: {skuAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );
                }
                else
                    _logger.AddMessage(
                        $"Concluída com sucesso: {skuAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );

                return true;
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return true;
        }

        public async Task<bool?> SearchSKUByQueue(LinxCommerceJobParameter jobParameter)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxCommerceSku);

                var objectRequest = new
                {
                    QueueID = 21,
                    Page = new { PageIndex = 0, PageSize = 1000 },
                    Where = $"EntityKeyName==\"CatalogItemID\" && EntityTypeName==\"EZ.Store.Model.Catalog.StockKeepUnit\"",
                    WhereMetadata = "",
                    OrderBy = "QueueItemID",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter,
                    objectRequest,
                    "/v1/Queue/API.svc/web/SearchQueueItems"
                );

                var skuAPIList = new List<Sku>();
                var enqueuedItens = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchQueuedItem.Root>(response);
                var enqueuedSKU = enqueuedItens
                                    .Result
                                    .Where(x => x.EntityKeyName == "CatalogItemID")
                                    .GroupBy(y => y.EntityKeyValue)
                                    .Select(g => g.First())
                                    .ToList();

                foreach (var productID in enqueuedSKU)
                {
                    string route = String.Empty;

                    var getSkuResponse = await _apiCall.PostRequest(
                        jobParameter: jobParameter,
                        intIdentifier: Convert.ToInt32(productID.EntityKeyValue),
                        route: "/v1/Catalog/API.svc/web/GetSKU"
                    );

                    var sku = Newtonsoft.Json.JsonConvert.DeserializeObject<Sku>(getSkuResponse);
                    var validations = _validator.Validate(sku);

                    if (validations.Errors.Count() > 0)
                    {
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            _logger.AddMessage(
                                stage: EnumStages.DeserializeXMLToObject,
                                error: EnumError.Validation,
                                logLevel: EnumMessageLevel.Warning,
                                message: $"Error when convert record - ProductID: {sku.ProductID} | Name: {sku.Name}\n" +
                                         $"{validations.Errors[j]}"
                            );
                        }
                    }

                    skuAPIList.Add(new Sku(sku, getSkuResponse));
                }

                if (skuAPIList.Count() > 0)
                {
                    _skuRepository.BulkInsertIntoTableRaw(jobParameter, skuAPIList, _logger.GetExecutionGuid());

                    skuAPIList.ForEach(p =>
                        _logger.AddRecord(
                            p.ProductID.ToString(),
                            p.Responses
                                .Where(pair => pair.Key == p.ProductID)
                                .Select(pair => pair.Value)
                                .FirstOrDefault()
                        )
                    );

                    _logger.AddMessage(
                        $"Concluída com sucesso: {skuAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );

                    //remover da fila de integração apenas se o registro for inserido no banco de dados
                    var listQueueItemID = new List<string>();

                    foreach (var enqueuedsku in enqueuedSKU)
                    {
                        listQueueItemID.Add(enqueuedsku.QueueItemID);
                    }

                    var dequeueObjectRequest = new { QueueItems = listQueueItemID };

                    var dequeueResponse = await _apiCall.PostRequest(
                        jobParameter,
                        dequeueObjectRequest,
                        "/v1/Queue/API.svc/web/DequeueQueueItems"
                    );
                }
                else
                    _logger.AddMessage(
                        $"Concluída com sucesso: {skuAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );

                return true;
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return true;
        }

        public Task<bool?> SearchSupplier(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchTags(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchUnitOfMeasure(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchWarehouse(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SetProductAuctionWinner(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SetProductVisibility(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> UpdateOfferStatus(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> UpdateProduct(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }
    }
}
