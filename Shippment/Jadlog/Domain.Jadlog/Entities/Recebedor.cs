namespace Domain.Jadlog.Entities
{
    public class Recebedor
    {
        public string nome { get; set; }
        public DateTime data { get; set; }

        public Recebedor() { }

        public Recebedor(DTOs.Recebedor recebedor)
        {
            this.nome = recebedor.nome;
            this.data = recebedor.data;
        }
    }
}
