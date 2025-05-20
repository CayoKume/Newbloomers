using Domain.IntegrationsCore.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxUsuarios
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime lastupdateon { get; private set; }

        public Int32? usuario_id { get; private set; }

        [LengthValidation(length: 30, propertyName: "usuario_login")]
        public string? usuario_login { get; private set; }

        [LengthValidation(length: 50, propertyName: "usuario_nome")]
        public string? usuario_nome { get; private set; }

        [LengthValidation(length: 60, propertyName: "usuario_email")]
        public string? usuario_email { get; private set; }

        public Int32? usuario_grupo_id { get; private set; }

        [LengthValidation(length: 1, propertyName: "grupo_usuarios")]
        public string? grupo_usuarios { get; private set; }

        [LengthValidation(length: 1, propertyName: "usuario_supervisor")]
        public string? usuario_supervisor { get; private set; }

        [LengthValidation(length: 14, propertyName: "usuario_doc")]
        public string? usuario_doc { get; private set; }

        public Int32? vendedor { get; private set; }

        public DateTime? data_criacao { get; private set; }

        [LengthValidation(length: 1, propertyName: "desativado")]
        public string? desativado { get; private set; }

        public string? empresas { get; private set; }

        public Int32? portal { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxUsuarios() { }

        public LinxUsuarios(
            List<ValidationResult> listValidations,
            string? usuario_id,
            string? usuario_login,
            string? usuario_nome,
            string? usuario_email,
            string? portal,
            string? usuario_grupo_id,
            string? grupo_usuarios,
            string? usuario_supervisor,
            string? usuario_doc,
            string? vendedor,
            string? data_criacao,
            string? desativado,
            string? empresas,
            string? timestamp,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.usuario_id =
                ConvertToInt32Validation.IsValid(usuario_id, "usuario_id", listValidations) ?
                Convert.ToInt32(usuario_id) :
                0;

            this.usuario_grupo_id =
                ConvertToInt32Validation.IsValid(usuario_grupo_id, "usuario_grupo_id", listValidations) ?
                Convert.ToInt32(usuario_grupo_id) :
                0;

            this.vendedor =
                ConvertToInt32Validation.IsValid(vendedor, "vendedor", listValidations) ?
                Convert.ToInt32(vendedor) :
                0;

            this.data_criacao =
                ConvertToDateTimeValidation.IsValid(data_criacao, "data_criacao", listValidations) ?
                Convert.ToDateTime(data_criacao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.usuario_login = usuario_login;
            this.usuario_nome = usuario_nome;
            this.usuario_email = usuario_email;
            this.grupo_usuarios = grupo_usuarios;
            this.usuario_supervisor = usuario_supervisor;
            this.usuario_doc = usuario_doc;
            this.desativado = desativado;
            this.empresas = empresas;
            this.recordKey = $"[{usuario_id}]|[{usuario_doc}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
