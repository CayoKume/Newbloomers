namespace Domain.Stone.Entities
{
    public class CarrierMetadata
    {
        /// <summary>
        /// auto increment property created to be the primary key of the migration
        /// </summary>
        public Int32? id { get; private set; }

        public string? type { get; set; }
        public string? status { get; set; }
        public string? description { get; set; }
        public DateTime? createdAt { get; set; }
        public Place? place { get; set; }
    }
}
