namespace Domain.WebApi.Models
{
    public class ExecuteCancellationOrder : Order
    {
        private List<ExecuteCancellationProduct> _itens = new List<ExecuteCancellationProduct>();

        public string suport { get; set; }
        public int reason { get; set; }
        public string obs { get; set; }
        public string? canceled { get; set; }
        public string? id_motivo { get; set; }
        public string? descricao_motivo { get; set; }

        public List<ExecuteCancellationProduct> itens { get { return _itens; } set { _itens = value; } }
    }
}
