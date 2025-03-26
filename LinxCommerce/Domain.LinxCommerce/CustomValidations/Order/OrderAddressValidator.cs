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
                .WithMessage(x => $"Property: Name | Value: {x.Name}, Tamanho do texto: {x.Name.Length} excede ao permitido: 50");

            RuleFor(x => x.AddressLine)
                .MaximumLength(250)
                .WithMessage(x => $"Property: AddressLine | Value: {x.AddressLine}, Tamanho do texto: {x.AddressLine.Length} excede ao permitido: 250");

            RuleFor(x => x.City)
                .MaximumLength(40)
                .WithMessage(x => $"Property: City | Value: {x.City}, Tamanho do texto: {x.City.Length} excede ao permitido: 40");

            RuleFor(x => x.Neighbourhood)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Neighbourhood | Value: {x.Neighbourhood}, Tamanho do texto: {x.Neighbourhood.Length} excede ao permitido: 60");

            RuleFor(x => x.Number)
                .MaximumLength(20)
                .WithMessage(x => $"Property: Number | Value: {x.Number}, Tamanho do texto: {x.Number.Length} excede ao permitido: 20");

            RuleFor(x => x.State)
                .MaximumLength(20)
                .WithMessage(x => $"Property: State | Value: {x.State}, Tamanho do texto: {x.State.Length} excede ao permitido: 20");

            RuleFor(x => x.PostalCode)
                .MaximumLength(9)
                .WithMessage(x => $"Property: PostalCode | Value: {x.PostalCode}, Tamanho do texto: {x.PostalCode.Length} excede ao permitido: 9");

            RuleFor(x => x.AddressNotes)
                .MaximumLength(60)
                .WithMessage(x => $"Property: AddressNotes | Value: {x.AddressNotes}, Tamanho do texto: {x.AddressNotes.Length} excede ao permitido: 60");

            RuleFor(x => x.Landmark)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Landmark | Value: {x.Landmark}, Tamanho do texto: {x.Landmark.Length} excede ao permitido: 60");

            RuleFor(x => x.ContactName)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ContactName | Value: {x.ContactName}, Tamanho do texto: {x.ContactName.Length} excede ao permitido: 50");

            RuleFor(x => x.ContactDocumentNumber)
                .MaximumLength(14)
                .WithMessage(x => $"Property: ContactDocumentNumber | Value: {x.ContactDocumentNumber}, Tamanho do texto: {x.ContactDocumentNumber.Length} excede ao permitido: 14");

            RuleFor(x => x.ContactPhone)
                .MaximumLength(20)
                .WithMessage(x => $"Property: ContactPhone | Value: {x.ContactPhone}, Tamanho do texto: {x.ContactPhone.Length} excede ao permitido: 20");
        }
    }
}
