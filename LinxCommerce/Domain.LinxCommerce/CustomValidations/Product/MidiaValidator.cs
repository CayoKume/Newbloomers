using Domain.LinxCommerce.CustomValidations.Validations;
using Domain.LinxCommerce.Entities.Product;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Product
{
    public class MidiaValidator : AbstractValidator<Midia>
    {
        public MidiaValidator()
        {
            RuleFor(x => x.OriginalFileName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: OriginalFileName | Value: {x.OriginalFileName}, Tamanho do texto: {x.OriginalFileName.Length} excede ao permitido: 60")
                .Must((x, OriginalFileName) =>
                {
                    if (OriginalFileName != null && OriginalFileName.Length > 60)
                        x.OriginalFileName = x.OriginalFileName.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.CreatedDate)
                .Must((x, createdDate) =>
                {
                    if (createdDate == null || createdDate.Value < new DateTime(1753, 1, 1))
                        x.CreatedDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.CreatedDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: CreatedDate | Value: {x.CreatedDate}, Error when trying to convert value: {x.CreatedDate.ToString()} to DateTime");

            RuleFor(x => x.Image)
                .SetValidator(new ImageValidator());

            RuleFor(x => x.Video)
                .SetValidator(new VideoValidator());

            RuleForEach(x => x.MediaAssociations)
                .SetValidator(new MediaAssociationValidator());
        }
    }
}
