using Domain.LinxCommerce.Entities.Customer;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Customer
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Phone)
                .MaximumLength(20)
                .WithMessage(x => $"Property: Phone | Value: {x.Phone}, Tamanho do texto: {x.Phone.Length} excede ao permitido: 20")
                .Must((x, phone) =>
                {
                    if (phone != null && phone.Length > 20)
                        x.Phone = x.Phone.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.Phone2)
                .MaximumLength(20)
                .WithMessage(x => $"Property: Phone2 | Value: {x.Phone2}, Tamanho do texto: {x.Phone2.Length} excede ao permitido: 20")
                .Must((x, phone2) =>
                {
                    if (phone2 != null && phone2.Length > 20)
                        x.Phone2 = x.Phone2.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.CellPhone)
                .MaximumLength(20)
                .WithMessage(x => $"Property: CellPhone | Value: {x.CellPhone}, Tamanho do texto: {x.CellPhone.Length} excede ao permitido: 20")
                .Must((x, cellPhone) =>
                {
                    if (cellPhone != null && cellPhone.Length > 20)
                        x.CellPhone = x.CellPhone.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.Fax)
                .MaximumLength(10)
                .WithMessage(x => $"Property: Fax | Value: {x.Fax}, Tamanho do texto: {x.Fax.Length} excede ao permitido: 10")
                .Must((x, fax) =>
                {
                    if ( fax != null && fax.Length > 10)
                        x.Fax = x.Fax.Substring(0, 10);
                    return true;
                });
        }
    }
}
