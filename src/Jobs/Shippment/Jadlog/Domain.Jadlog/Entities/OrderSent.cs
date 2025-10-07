using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Jadlog.Entities
{
    public class OrderSent
    {
        public string cte { get; set; }
        public string codigo { get; set; }
        public string shipmentId { get; set; }
        public string pedido { get; set; }
        public string status { get; set; }
        public DateTime dtEnvio { get; set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        [SkipProperty]
        public Erro erro { get; set; }
        
        public OrderSent() { }

        public OrderSent(DTOs.Response.Rootobject pedido, string cod_pedido, string request)
        {
            this.codigo = pedido.codigo == null ? "" : pedido.codigo;
            this.shipmentId = pedido.shipmentId == null ? "" : pedido.shipmentId;
            this.status = pedido.status;
            this.pedido = cod_pedido;
            this.recordKey = cod_pedido;
            this.recordXml = request;
            this.dtEnvio = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

            if (pedido.erro != null)
                this.erro = new Erro(pedido.erro, cod_pedido);
        }
    }
}
