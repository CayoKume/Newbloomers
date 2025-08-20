namespace Domain.Stone.Entities
{
    public class Address
    {
        /// <summary>
        /// auto increment property created to be the primary key of the migration
        /// </summary>
        public Int32? id { get; private set; }

        public string? cidade { get; set; }
        public string? uf { get; set; }
    }
}
