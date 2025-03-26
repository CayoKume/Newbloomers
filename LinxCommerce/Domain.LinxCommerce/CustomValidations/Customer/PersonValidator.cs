using Domain.LinxCommerce.CustomValidations.Validations;
using Domain.LinxCommerce.Entities.Customer;
using FluentValidation;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.LinxCommerce.CustomValidations.Customer
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Surname)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Surname | Value: {x.Surname}, Tamanho do texto: {x.Surname.Length} excede ao permitido: 60")
                .Must((x, surname) =>
                {
                    if (surname != null && surname.Length > 60)
                        x.Surname = x.Surname.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Gender)
                .MaximumLength(1)
                .WithMessage(x => $"Property: Gender | Value: {x.Gender}, Tamanho do texto: {x.Gender.Length} excede ao permitido: 1")
                .Must((x, gender) =>
                {
                    if (gender != null && gender.Length > 1)
                        x.Gender = x.Gender.Substring(0, 1);
                    return true;
                });

            RuleFor(x => x.RG)
                .MaximumLength(14)
                .WithMessage(x => $"Property: RG | Value: {x.RG}, Tamanho do texto: {x.RG.Length} excede ao permitido: 14")
                .Must((x, rg) =>
                {
                    if (rg != null && rg.Length > 14)
                        x.RG = x.RG.Substring(0, 14);
                    return true;
                });

            RuleFor(x => x.Cpf)
                .MaximumLength(14)
                .WithMessage(x => $"Property: Cpf | Value: {x.Cpf}, Tamanho do texto: {x.Cpf.Length} excede ao permitido: 14")
                .Must((x, cpf) =>
                {
                    if (cpf != null && cpf.Length > 14)
                        x.Cpf = x.Cpf.Substring(0, 14);
                    return true;
                });

            RuleFor(x => x.WebSiteID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: WebSiteID | Value: {x.WebSiteID}, Tamanho do texto: {x.WebSiteID.Length} excede ao permitido: 60")
                .Must((x, webSiteID) =>
                {
                    if (webSiteID != null && webSiteID.Length > 60)
                        x.WebSiteID = x.WebSiteID.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Name)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Name | Value: {x.Name}, Tamanho do texto: {x.Name.Length} excede ao permitido: 60")
                .Must((x, name) =>
                {
                    if (name != null && name.Length > 60)
                        x.Name = x.Name.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Email)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Email | Value: {x.Email}, Tamanho do texto: {x.Email.Length} excede ao permitido: 60")
                .Must((x, email) =>
                {
                    if (email != null && email.Length > 60)
                        x.Email = x.Email.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Password)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Password | Value: {x.Password}, Tamanho do texto: {x.Password.Length} excede ao permitido: 60")
                .Must((x, password) =>
                {
                    if (password != null && password.Length > 60)
                        x.Password = x.Password.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Cnpj)
                .MaximumLength(14)
                .WithMessage(x => $"Property: Cnpj | Value: {x.Cnpj}, Tamanho do texto: {x.Cnpj.Length} excede ao permitido: 14")
                .Must((x, cnpj) =>
                {
                    if (cnpj != null && cnpj.Length > 14)
                        x.Cnpj = x.Cnpj.Substring(0, 14);
                    return true;
                });

            RuleFor(x => x.TradingName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: TradingName | Value: {x.TradingName}, Tamanho do texto: {x.TradingName.Length} excede ao permitido: 60")
                .Must((x, tradingName) =>
                {
                    if (tradingName != null && tradingName.Length > 60)
                        x.TradingName = x.TradingName.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.CustomerGroupID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CustomerGroupID | Value: {x.CustomerGroupID}, Tamanho do texto: {x.CustomerGroupID.Length} excede ao permitido: 60")
                .Must((x, customerGroupID) =>
                {
                    if (customerGroupID != null && customerGroupID.Length > 60)
                        x.CustomerGroupID = x.CustomerGroupID.Substring(0, 60);
                    return true;
                });

            RuleForEach(x => x.Groups)
                .SetValidator(new GroupsValidator());

            RuleFor(x => x.Contact)
                .SetValidator(new ContactValidator());

            RuleForEach(x => x.Address)
                .SetValidator(new PersonAddressValidator());

            RuleFor(x => x.EmailConfirmation)
                .SetValidator(new EmailConfirmationValidator());

            RuleFor(x => x.BirthDate)
                .Must((x, birthDate) =>
                {
                    if (birthDate == null || birthDate.Value < new DateTime(1753, 1, 1))
                        x.BirthDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.BirthDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: BirthDate | Value: {x.BirthDate}, Error when trying to convert value: {x.BirthDate.ToString()} to DateTime");

            RuleFor(x => x.CreatedDate)
                .Must((x, createdDate) =>
                {
                    if (createdDate == null || createdDate.Value < new DateTime(1753, 1, 1))
                        x.CreatedDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.BirthDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: CreatedDate | Value: {x.CreatedDate}, Error when trying to convert value: {x.CreatedDate.ToString()} to DateTime");
        }
    }
}
