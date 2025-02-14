using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.Customer
{
    public class Person
    {
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? RG { get; set; }
        public string? Cpf { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Int32 CustomerID { get; set; }
        public Int32? CustomerStatusID { get; set; }
        public string? WebSiteID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Guid? CustomerHash { get; set; }
        public string? Password { get; set; }
        public Int32? CustomerType { get; set; }
        public string? Cnpj { get; set; }
        public string? TradingName { get; set; }
        public string? CustomerGroupID { get; set; }

        [SkipProperty]
        public List<Groups> Groups { get; set; }

        [SkipProperty]
        public Contact Contact { get; set; }

        [SkipProperty]
        public List<PersonAddress> Address { get; set; } = new List<PersonAddress>();

        [SkipProperty]
        public EmailConfirmation EmailConfirmation { get; set; }

        [SkipProperty]
        public Dictionary<int, string> Responses { get; set; } = new Dictionary<int, string>();

        public static void Compare(List<Person?> customersAPIList, List<Person?> customersDboList)
        {
            if (customersDboList.Count() > 0)
            {
                foreach (var cDbo in customersDboList)
                {
                    try
                    {
                        var cAPI = customersAPIList
                                    .Where(cAPI =>
                                            cAPI.CustomerID == cDbo.CustomerID
                                    ).FirstOrDefault();

                        customersAPIList.Remove(
                            customersAPIList
                                .Where(cAPI =>
                                    cAPI.Surname == cDbo.Surname &&
                                    cAPI.BirthDate == cDbo.BirthDate &&
                                    cAPI.Gender == cDbo.Gender &&
                                    cAPI.RG == cDbo.RG &&
                                    cAPI.Cpf == cDbo.Cpf &&
                                    cAPI.CreatedDate == cDbo.CreatedDate &&
                                    cAPI.CustomerStatusID == cDbo.CustomerStatusID &&
                                    cAPI.WebSiteID == cDbo.WebSiteID &&
                                    cAPI.Name == cDbo.Name &&
                                    cAPI.Email == cDbo.Email &&
                                    cAPI.CustomerHash == cDbo.CustomerHash &&
                                    cAPI.Password == cDbo.Password &&
                                    cAPI.CustomerType == cDbo.CustomerType &&
                                    cAPI.Cnpj == cDbo.Cnpj &&
                                    cAPI.TradingName == cDbo.TradingName &&
                                    (cAPI.Groups.Count() > 0 ? String.Join(", ", cAPI.Groups.Select(x => x.CustomerGroupID)) : null) == cDbo.CustomerGroupID &&
                                    cAPI.Contact == cDbo.Contact &&
                                    cAPI.EmailConfirmation == cDbo.EmailConfirmation &&
                                    cAPI.Address.SequenceEqual(cDbo.Address)
                                ).FirstOrDefault()
                        );

                        if (cAPI.Address.Count() > 0 && cDbo.Address.Count() > 0)
                            cAPI.Address = PersonAddress.Compare(cAPI.Address, cDbo.Address);

                        cDbo.Address.AddRange(cAPI.Address);
                    }
                    catch (Exception ex)
                    {
                        throw new InternalException(
                            stage: EnumStages.Compare,
                            error: EnumError.Compare,
                            level: EnumMessageLevel.Error,
                            message: $"Error when comparing two lists of records",
                            exceptionMessage: ex.Message
                        );
                    }
                }
            }
        }
    }
}
