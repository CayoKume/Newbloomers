namespace Domain.Stone.Entities
{
    public class Carrier
    {
        /// <summary>
        /// auto increment property created to be the primary key of the migration
        /// </summary>
        public Int32? id { get; set; }

        public string? name { get; set; }
        public string? service { get; set; }
    }
}
