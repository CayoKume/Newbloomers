using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.Auditing
{
    public class Record
    {
        /// <summary>
        /// 
        /// </summary>
        [SkipProperty]
        public Int32? IdRecord { get; private set; }

        public string? FieldKeyValue { get; private set; }
        public string? RecordText { get; private set; }
        public Guid? Execution { get; private set; }

        public Record() { }

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <param name="key"></param>
        /// <param name="regXML"></param>
        public Record(
            string key,
            string? regXML
        )
        {
            FieldKeyValue = key;
            RecordText = regXML;
        }
    }
}
