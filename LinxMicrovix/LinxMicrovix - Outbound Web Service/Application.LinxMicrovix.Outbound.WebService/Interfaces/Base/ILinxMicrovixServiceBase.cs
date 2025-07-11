﻿using Application.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Base
{
    public interface ILinxMicrovixServiceBase
    {
        public string? BuildBodyRequest(LinxAPIParam jobParameter, string? parametersList, string? cnpj_emp);
        public string? BuildBodyRequest(LinxAPIParam jobParameter, string? parametersList);
        public string? BuildBodyRequest(LinxAPIParam jobParameter);
        public List<Dictionary<string?, string?>> DeserializeResponseToXML(LinxAPIParam jobParameter, string? response);
    }
}
