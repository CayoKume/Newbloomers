namespace Domain.WebApi.Models
{
    public class AttendenceOrder : Order
    {
        private List<AttendenceProduct> _itens = new List<AttendenceProduct>();

        public string? contacted { get; set; }

        public List<AttendenceProduct> itens { get { return _itens; } set { _itens = value; } }
    }
}
