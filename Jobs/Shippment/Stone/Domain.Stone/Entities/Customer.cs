namespace Domain.Stone.Entities
{
    public class Customer
    {
        /// <summary>
        /// auto increment property created to be the primary key of the migration
        /// </summary>
        public Int32? id { get; private set; }

        public string? name { get; set; }
        public string? phoneNumber { get; set; }
        public string? document { get; set; }
    }
}
