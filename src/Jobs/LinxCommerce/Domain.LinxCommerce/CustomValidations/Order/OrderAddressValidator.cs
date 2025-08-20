using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderAddressValidator : AbstractValidator<OrderAddress>
    {
        public OrderAddressValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Name | Value: {x.Name}, Tamanho do texto: {x.Name.Length} excede ao permitido: 50")
                .Must((x, name) =>
                {
                    if (name != null && name.Length > 50)
                        x.Name = x.Name.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.AddressLine)
                .MaximumLength(250)
                .WithMessage(x => $"Property: AddressLine | Value: {x.AddressLine}, Tamanho do texto: {x.AddressLine.Length} excede ao permitido: 250")
                .Must((x, addressLine) =>
                {
                    if (addressLine != null && addressLine.Length > 250)
                        x.AddressLine = x.AddressLine.Substring(0, 250);
                    return true;
                });

            RuleFor(x => x.City)
                .MaximumLength(40)
                .WithMessage(x => $"Property: City | Value: {x.City}, Tamanho do texto: {x.City.Length} excede ao permitido: 40")
                .Must((x, city) =>
                {
                    if (city != null && city.Length > 40)
                        x.City = x.City.Substring(0, 40);
                    return true;
                });

            RuleFor(x => x.Neighbourhood)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Neighbourhood | Value: {x.Neighbourhood}, Tamanho do texto: {x.Neighbourhood.Length} excede ao permitido: 60")
                .Must((x, neighbourhood) =>
                {
                    if (neighbourhood != null && neighbourhood.Length > 60)
                        x.Neighbourhood = x.Neighbourhood.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Number)
                .MaximumLength(20)
                .WithMessage(x => $"Property: Number | Value: {x.Number}, Tamanho do texto: {x.Number.Length} excede ao permitido: 20")
                .Must((x, number) =>
                {
                    if (number != null && number.Length > 20)
                        x.Number = x.Number.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.State)
                .MaximumLength(20)
                .WithMessage(x => $"Property: State | Value: {x.State}, Tamanho do texto: {x.State.Length} excede ao permitido: 20")
                .Must((x, state) =>
                {
                    if (state != null && state.Length > 20)
                        x.State = x.State.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.PostalCode)
                .MaximumLength(9)
                .WithMessage(x => $"Property: PostalCode | Value: {x.PostalCode}, Tamanho do texto: {x.PostalCode.Length} excede ao permitido: 9")
                .Must((x, postalCode) =>
                {
                    if (postalCode != null && postalCode.Length > 9)
                        x.PostalCode = x.PostalCode.Substring(0, 9);
                    return true;
                });

            RuleFor(x => x.AddressNotes)
                .MaximumLength(60)
                .WithMessage(x => $"Property: AddressNotes | Value: {x.AddressNotes}, Tamanho do texto: {x.AddressNotes.Length} excede ao permitido: 60")
                .Must((x, addressNotes) =>
                {
                    if (addressNotes != null && addressNotes.Length > 60)
                        x.AddressNotes = x.AddressNotes.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Landmark)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Landmark | Value: {x.Landmark}, Tamanho do texto: {x.Landmark.Length} excede ao permitido: 60")
                .Must((x, landmark) =>
                {
                    if (landmark != null && landmark.Length > 60)
                        x.Landmark = x.Landmark.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.ContactName)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ContactName | Value: {x.ContactName}, Tamanho do texto: {x.ContactName.Length} excede ao permitido: 50")
                .Must((x, contactName) =>
                {
                    if (contactName != null && contactName.Length > 50)
                        x.ContactName = x.ContactName.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.ContactDocumentNumber)
                .MaximumLength(14)
                .WithMessage(x => $"Property: ContactDocumentNumber | Value: {x.ContactDocumentNumber}, Tamanho do texto: {x.ContactDocumentNumber.Length} excede ao permitido: 14")
                .Must((x, contactDocumentNumber) =>
                {
                    if (contactDocumentNumber != null && contactDocumentNumber.Length > 14)
                        x.ContactDocumentNumber = x.ContactDocumentNumber.Substring(0, 14);
                    return true;
                });

            RuleFor(x => x.ContactPhone)
                .MaximumLength(20)
                .WithMessage(x => $"Property: ContactPhone | Value: {x.ContactPhone}, Tamanho do texto: {x.ContactPhone.Length} excede ao permitido: 20")
                .Must((x, contactPhone) =>
                {
                    if (contactPhone != null && contactPhone.Length > 20)
                        x.ContactPhone = x.ContactPhone.Substring(0, 20);
                    return true;
                });
        }
    }
}
