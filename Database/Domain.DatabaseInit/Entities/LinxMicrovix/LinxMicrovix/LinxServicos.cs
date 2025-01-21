using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxServicos", Schema = "untreated")]
    public class LinxServicos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_setor { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? cod_servico { get; private set; }

        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "nome")]
        public string? nome { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "desc_setor")]
        public string? desc_setor { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_linha { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "desc_linha")]
        public string? desc_linha { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_marca { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "desc_marca")]
        public string? desc_marca { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? dt_update { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "operacao_servico")]
        public string? operacao_servico { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "servico_km")]
        public string? servico_km { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "desativado")]
        public string? desativado { get; private set; }

        [Column(TypeName = "varchar(4)")]
        [LengthValidation(length: 4, propertyName: "cod_lc11603")]
        public string? cod_lc11603 { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "codigo_nbs")]
        public string? codigo_nbs { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? dt_inclusao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "codigo_ws")]
        public string? codigo_ws { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public LinxServicos() { }

        public LinxServicos(
            List<ValidationResult> listValidations,
            string? id_setor,
            string? cod_servico,
            string? nome,
            string? desc_setor,
            string? id_linha,
            string? desc_linha,
            string? id_marca,
            string? desc_marca,
            string? dt_update,
            string? operacao_servico,
            string? servico_km,
            string? desativado,
            string? cod_lc11603,
            string? codigo_nbs,
            string? dt_inclusao,
            string? timestamp,
            string? codigo_ws,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_setor =
                ConvertToInt32Validation.IsValid(id_setor, "id_setor", listValidations) ?
                Convert.ToInt32(id_setor) :
                0;

            this.id_linha =
                ConvertToInt32Validation.IsValid(id_linha, "id_linha", listValidations) ?
                Convert.ToInt32(id_linha) :
                0;

            this.id_marca =
                ConvertToInt32Validation.IsValid(id_marca, "id_marca", listValidations) ?
                Convert.ToInt32(id_marca) :
                0;

            this.cod_servico =
                ConvertToInt64Validation.IsValid(cod_servico, "cod_servico", listValidations) ?
                Convert.ToInt64(cod_servico) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.dt_update =
               ConvertToDateTimeValidation.IsValid(dt_update, "dt_update", listValidations) ?
               Convert.ToDateTime(dt_update) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.dt_inclusao =
               ConvertToDateTimeValidation.IsValid(dt_inclusao, "dt_inclusao", listValidations) ?
               Convert.ToDateTime(dt_inclusao) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.nome = nome;
            this.desc_setor = desc_setor;
            this.desc_linha = desc_linha;
            this.desc_marca = desc_marca;
            this.cod_lc11603 = cod_lc11603;
            this.operacao_servico = operacao_servico;
            this.desativado = desativado;
            this.codigo_ws = codigo_ws;
            this.codigo_nbs = codigo_nbs;
            this.servico_km = servico_km;
        }
    }
}
