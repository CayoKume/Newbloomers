using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebJobsApplication.Domain.Entites
{
    public class LinxAPIParam
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string? method { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? parameters_timestamp { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? parameters_dateinterval { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? parameters_individual { get; set; }

        [Column(TypeName = "BIT")]
        public bool? ativo { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? last_execution { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? last_response { get; set; }
    }
}
