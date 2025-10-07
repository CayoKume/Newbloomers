using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Stone.Entities
{
    public class Zpl
    {
        public Int64 idcontrole { get; set; }
        public string documento { get; set; }
        public Int64 transportadora { get; set; }

        [SkipProperty]
        public string referencekey { get; set; }

        public string zpl { get; set; }
        public bool etiqueta_impressa { get; set; } = false;

        [NotMapped]
        [SkipProperty]
        public Error error { get; set; } = new Error();

        public void SetZpl(string zpl)
        {
            this.zpl = zpl;
        }

        public void SetError(string message, string error)
        {
            this.error = String.IsNullOrEmpty(message) && String.IsNullOrEmpty(error) ? new Error() : new Error(documento, message, error);
        }
    }
}
