namespace Domain.Stone.Entities
{
    public class DeliveryAddress
    {
        /// <summary>
        /// auto increment property created to be the primary key of the migration
        /// </summary>
        public Int32? id { get; private set; }

        public string? address { get; set; }
        public string? addressNumber { get; set; }
        public string? city { get; set; }
        public string? complement { get; set; }
        public string? country { get; set; }
        public string? countryState { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public string? neighborhood { get; set; }
        public string? zipCode { get; set; }
    }
}
