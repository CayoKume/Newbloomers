using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebJobsApplication.Domain.Entites
{
    public class LinxAPILog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? method { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? execution_date { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? parameters_interval { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? response { get; set; }
    }
}
