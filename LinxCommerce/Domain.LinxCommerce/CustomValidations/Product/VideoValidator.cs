using Domain.LinxCommerce.Entities.Product;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Product
{
    public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Title | Value: {x.Title}, Tamanho do texto: {x.Title.Length} excede ao permitido: 60")
                .Must((x, Title) =>
                {
                    if (Title != null && Title.Length > 60)
                        x.Title = x.Title.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Url)
                .MaximumLength(800)
                .WithMessage(x => $"Property: Url | Value: {x.Url}, Tamanho do texto: {x.Url.Length} excede ao permitido: 800")
                .Must((x, Url) =>
                {
                    if (Url != null && Url.Length > 800)
                        x.Url = x.Url.Substring(0, 800);
                    return true;
                });
        }
    }
}
