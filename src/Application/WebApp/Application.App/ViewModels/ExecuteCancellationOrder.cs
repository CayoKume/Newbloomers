namespace Application.App.ViewModels.ExecuteCancellation
{
    public class Order : Domain.App.Entities.Order
    {
        public string? buttonText { get; set; }
        public string? buttonClass { get; set; }
        public string? canceled { get; set; }
        public string? id_motivo { get; set; }
        public string? descricao_motivo { get; set; }
    }

    public class Product : Domain.App.Entities.Product
    {
        public int picked_quantity_product { get; set; }
    }
}
