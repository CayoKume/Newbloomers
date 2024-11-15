using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxCommerce.Entities.Catolog.Sku
{
    public class SKUs
    {
        [Column(TypeName = "varchar(60)")]
        public string? UPC { get; set; }

        [Column(TypeName = "bit")]
        public string? DisplayCondition { get; set; }

        [Column(TypeName = "int")]
        public string? DefinitionID { get; set; }

        [Column(TypeName = "int")]
        public string? ConditionID { get; set; }

        [Column(TypeName = "int")]
        public string? UnitOfMeasureID { get; set; }

        [Column(TypeName = "bit")]
        public string? ManageStock { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? MinimumQtyAllowed { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? MaximumQtyAllowed { get; set; }

        [Column(TypeName = "bit")]
        public string? Preorderable { get; set; }

        [Column(TypeName = "datetime")]
        public string? PreorderDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? PreorderLimit { get; set; }

        [Column(TypeName = "bit")]
        public string? Backorderable { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? BackorderLimit { get; set; }

        [Column(TypeName = "int")]
        public string? PurchasingPolicyID { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? WrappingQty { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? Weight { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? Height { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? Width { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? Depth { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? Cost { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? Tax { get; set; }

        [Column(TypeName = "bit")]
        public string? IsVisible { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? VisibleFrom { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? VisibleTo { get; set; }

        [Column(TypeName = "bit")]
        public string? IsDeleted { get; set; }

        [Column(TypeName = "int")]
        public string? ProductID { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? SKU { get; set; }

        [Column(TypeName = "datetime")]
        public string? CreatedDate { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public string? ModifiedDate { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? ModifiedBy { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? IntegrationID { get; set; }


        public List<string?> SupplierID { get; set; }


        public List<string?> ParentsID { get; set; }


        public List<MetadataValue> MetadataValues { get; set; }


        public List<ParentRelation> ParentRelations { get; set; }
    }
}
