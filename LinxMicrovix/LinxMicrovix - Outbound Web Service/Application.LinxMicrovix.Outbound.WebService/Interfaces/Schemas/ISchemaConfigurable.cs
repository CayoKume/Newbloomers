using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Schemas
{
    public interface ISchemaConfigurable
    {
        string SetEcomSchema();
        string SetErpSchema();
        string SetUnteatredSchema();
    }
}
