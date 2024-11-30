using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaLegendasCadastrosAuxiliares
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "legenda_setor")]
        public string? legenda_setor { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "legenda_linha")]
        public string? legenda_linha { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "legenda_marca")]
        public string? legenda_marca { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "legenda_colecao")]
        public string? legenda_colecao { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "legenda_grade1")]
        public string? legenda_grade1 { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "legenda_grade2")]
        public string? legenda_grade2 { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "legenda_espessura")]
        public string? legenda_espessura { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "legenda_classificacao")]
        public string? legenda_classificacao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public B2CConsultaLegendasCadastrosAuxiliares() { }

        public B2CConsultaLegendasCadastrosAuxiliares(
            List<ValidationResult> listValidations,
            string? empresa,
            string? legenda_setor,
            string? legenda_linha,
            string? legenda_marca,
            string? legenda_colecao,
            string? legenda_grade1,
            string? legenda_grade2,
            string? legenda_espessura,
            string? legenda_classificacao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

            this.legenda_setor =
                String.IsNullOrEmpty(legenda_setor) ? ""
                : legenda_setor.Substring(
                    0,
                    legenda_setor.Length > 20 ? 20
                    : legenda_setor.Length
                );

            this.legenda_linha =
                String.IsNullOrEmpty(legenda_linha) ? ""
                : legenda_linha.Substring(
                    0,
                    legenda_linha.Length > 20 ? 20
                    : legenda_linha.Length
                );

            this.legenda_marca =
                String.IsNullOrEmpty(legenda_marca) ? ""
                : legenda_marca.Substring(
                    0,
                    legenda_marca.Length > 20 ? 20
                    : legenda_marca.Length
                );

            this.legenda_colecao =
                String.IsNullOrEmpty(legenda_colecao) ? ""
                : legenda_colecao.Substring(
                    0,
                    legenda_colecao.Length > 20 ? 20
                    : legenda_colecao.Length
                );

            this.legenda_grade1 =
                String.IsNullOrEmpty(legenda_grade1) ? ""
                : legenda_grade1.Substring(
                    0,
                    legenda_grade1.Length > 20 ? 20
                    : legenda_grade1.Length
                );

            this.legenda_grade2 =
                String.IsNullOrEmpty(legenda_grade2) ? ""
                : legenda_grade2.Substring(
                    0,
                    legenda_grade2.Length > 20 ? 20
                    : legenda_grade2.Length
                );

            this.legenda_espessura =
                String.IsNullOrEmpty(legenda_espessura) ? ""
                : legenda_espessura.Substring(
                    0,
                    legenda_espessura.Length > 20 ? 20
                    : legenda_espessura.Length
                );

            this.legenda_classificacao =
                String.IsNullOrEmpty(legenda_classificacao) ? ""
                : legenda_classificacao.Substring(
                    0,
                    legenda_classificacao.Length > 20 ? 20
                    : legenda_classificacao.Length
                );

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);
        }
    }
}
