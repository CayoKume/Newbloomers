namespace Application.WebApp.ViewModels.ExecuteCancellation
{
    public class Order : Domain.WebApp.Entities.Order
    {
        public string? buttonText { get; set; }
        public string? buttonClass { get; set; }
        public string? canceled { get; set; }
        public string? id_motivo { get; set; }
        public string? descricao_motivo { get; set; }
    }

    public class Product : Domain.WebApp.Entities.Product
    {
        public int picked_quantity_product { get; set; }
    }
}
