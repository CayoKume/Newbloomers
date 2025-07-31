using Domain.Core.Extensions;
using Domain.Movidesk.Dtos.Persons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Movidesk.Models.Persons
{
    public class Person
    {
        public Int64 id { get; private set; }
        public string? codeReferenceAdditional { get; private set; }
        public bool isActive { get; private set; }
        public int? personType { get; private set; }
        public int? profileType { get; private set; }
        public string? accessProfile { get; private set; }
        public string? businessName { get; private set; }
        public string? corporateName { get; private set; }
        public string? cpfCnpj { get; private set; }
        public string? userName { get; private set; }
        public string? role { get; private set; }
        public string? bossId { get; private set; }
        public string? classification { get; private set; }
        public string? cultureId { get; private set; }
        public string? timeZoneId { get; private set; }
        public DateTime createdDate { get; private set; }
        public string? observations { get; private set; }
        public List<Address> addresses { get; private set; } = new List<Address>();
        public List<Contact> contacts { get; private set; } = new List<Contact>();
        public List<Email> emails { get; private set; } = new List<Email>();
        public List<Relationship> relationships { get; private set; } = new List<Relationship>();

        /// <summary>
        /// property created to be the FieldKeyValue of the [auditing].[Records] table
        /// </summary>
        public string? RecordKey { get; private set; }

        /// <summary>
        /// property created to be the RecordText of the [auditing].[Records] table
        /// </summary>
        public string? RecordResponse { get; private set; }

        public Person() { }

        public Person(Domain.Movidesk.Dtos.Persons.Person person)
        {
            id = Convert.ToInt64(person.id);
            codeReferenceAdditional = person.codeReferenceAdditional;
            isActive = Convert.ToBoolean(person.isActive);
            personType = Convert.ToInt32(person.personType);
            profileType = Convert.ToInt32(person.profileType);
            accessProfile = person.accessProfile;
            businessName = person.businessName;
            corporateName = person.corporateName;
            cpfCnpj = person.cpfCnpj;
            userName = person.userName;
            role = person.role;
            bossId = person.bossId;
            classification = person.classification;
            cultureId = person.cultureId;
            timeZoneId = person.timeZoneId;
            createdDate = Convert.ToDateTime(createdDate);
            observations = person.observations;

            person.addresses?.ForEach(x => addresses.Add(new Address(x, id)));
            person.contacts?.ForEach(x => contacts.Add(new Contact(x, id)));
            person.emails?.ForEach(x => emails.Add(new Email(x, id)));
            person.relationships?.ForEach(x => relationships.Add(new Relationship(x, id)));

            RecordKey = $"[{person.id?.ToString()}] | [{person.cpfCnpj?.ToString()}]";

            //API da Movidesk não possui um end-pooint para busca individual da entidade Person, por isso para não logar a response contendo todos os Dtos, a serialização a baixo é feita
            RecordResponse = Newtonsoft.Json.JsonConvert.SerializeObject(person);
        }
    }
}
