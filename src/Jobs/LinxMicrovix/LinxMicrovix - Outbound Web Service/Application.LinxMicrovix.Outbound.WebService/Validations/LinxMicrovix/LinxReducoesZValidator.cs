using Application.Core.Validations.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Validations.LinxMicrovix
{
    public class LinxReducoesZValidator : AbstractValidator<LinxReducoesZ>
    {
        public LinxReducoesZValidator()
        {
        }
    }
}
