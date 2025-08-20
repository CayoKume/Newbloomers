using Domain.LinxCommerce.Entities.Product;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Product
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.RelativePath)
                .MaximumLength(800)
                .WithMessage(x => $"Property: RelativePath | Value: {x.RelativePath}, Tamanho do texto: {x.RelativePath.Length} excede ao permitido: 800")
                .Must((x, RelativePath) =>
                {
                    if (RelativePath != null && RelativePath.Length > 800)
                        x.RelativePath = x.RelativePath.Substring(0, 800);
                    return true;
                });

            RuleFor(x => x.AbsolutePath)
                .MaximumLength(800)
                .WithMessage(x => $"Property: Name | Value: {x.AbsolutePath}, Tamanho do texto: {x.AbsolutePath.Length} excede ao permitido: 800")
                .Must((x, AbsolutePath) =>
                {
                    if (AbsolutePath != null && AbsolutePath.Length > 800)
                        x.AbsolutePath = x.AbsolutePath.Substring(0, 800);
                    return true;
                });
        }
    }
}
