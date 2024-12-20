using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxOrdensServico
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? numero_os { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? data_os { get; private set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? data_envio_laboratorio { get; private set; }
        
        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "cancelado")]
        public string? cancelado { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_laboratorio { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_posicao_os_ramo_optico { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? compartilhar_hub_laboratorios { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? cod_cliente_os { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? cod_vendedor { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? numero_sequencial_antecipacao_financeira { get; private set; }
        
        [Column(TypeName = "varchar(44)")]
        [LengthValidation(length: 44, propertyName: "chave_nfe_laboratorio")]
        public string? chave_nfe_laboratorio { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxOrdensServico() { }

        public LinxOrdensServico(
            List<ValidationResult> listValidations,
            string? numero_os,
            string? empresa,
            string? data_os,
            string? data_envio_laboratorio,
            string? cancelado,
            string? id_laboratorio,
            string? id_posicao_os_ramo_optico,
            string? compartilhar_hub_laboratorios,
            string? cod_cliente_os,
            string? cod_vendedor,
            string? numero_sequencial_antecipacao_financeira,
            string? chave_nfe_laboratorio,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.numero_os =
                ConvertToInt32Validation.IsValid(numero_os, "numero_os", listValidations) ?
                Convert.ToInt32(numero_os) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_laboratorio =
                ConvertToInt32Validation.IsValid(id_laboratorio, "id_laboratorio", listValidations) ?
                Convert.ToInt32(id_laboratorio) :
                0;

            this.id_posicao_os_ramo_optico =
                ConvertToInt32Validation.IsValid(id_posicao_os_ramo_optico, "id_posicao_os_ramo_optico", listValidations) ?
                Convert.ToInt32(id_posicao_os_ramo_optico) :
                0;

            this.cod_cliente_os =
                ConvertToInt32Validation.IsValid(cod_cliente_os, "cod_cliente_os", listValidations) ?
                Convert.ToInt32(cod_cliente_os) :
                0;

            this.cod_vendedor =
                ConvertToInt32Validation.IsValid(cod_vendedor, "cod_vendedor", listValidations) ?
                Convert.ToInt32(cod_vendedor) :
                0;

            this.numero_sequencial_antecipacao_financeira =
                ConvertToInt32Validation.IsValid(numero_sequencial_antecipacao_financeira, "numero_sequencial_antecipacao_financeira", listValidations) ?
                Convert.ToInt32(numero_sequencial_antecipacao_financeira) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.compartilhar_hub_laboratorios =
                ConvertToBooleanValidation.IsValid(compartilhar_hub_laboratorios, "compartilhar_hub_laboratorios", listValidations) ?
                Convert.ToBoolean(compartilhar_hub_laboratorios) :
                false;

            this.data_os =
                ConvertToDateTimeValidation.IsValid(data_os, "data_os", listValidations) ?
                Convert.ToDateTime(data_os) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_envio_laboratorio =
                ConvertToDateTimeValidation.IsValid(data_envio_laboratorio, "data_envio_laboratorio", listValidations) ?
                Convert.ToDateTime(data_envio_laboratorio) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.cancelado = cancelado;
            this.chave_nfe_laboratorio = chave_nfe_laboratorio;
        }
    }
}
