using Application.IntegrationsCore.Validations.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.CustomValidations.LinxMicrovix
{
    public class LinxReducoesZValidator : AbstractValidator<LinxReducoesZ>
    {
        public LinxReducoesZValidator()
        {
        }
    }
}
