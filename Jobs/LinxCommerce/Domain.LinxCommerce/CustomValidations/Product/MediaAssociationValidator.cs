using Domain.LinxCommerce.Entities.Product;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Product
{
    public class MediaAssociationValidator : AbstractValidator<MediaAssociation>
    {
        public MediaAssociationValidator()
        {
            RuleFor(x => x.Path)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Path | Value: {x.Path}, Tamanho do texto: {x.Path.Length} excede ao permitido: 50")
                .Must((x, Path) =>
                {
                    if (Path != null && Path.Length > 50)
                        x.Path = x.Path.Substring(0, 50);
                    return true;
                });
        }
    }
}
