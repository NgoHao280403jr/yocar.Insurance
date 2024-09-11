using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.Diagnostics.CodeAnalysis;

namespace yocar.Insurance_v1.Entities.ContactPersons
{
    public abstract class ContactPersonBase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string Email { get; set; }

        [NotNull]
        public virtual string Phone { get; set; }

        protected ContactPersonBase() { }

        public ContactPersonBase(Guid id, string name, string email, string phone)
        {
            Id = id;
            Check.NotNull(name, nameof(name));
            Check.NotNull(email, nameof(email));
            Check.NotNull(phone, nameof(phone));
            Name = name;
            Email = email;
            Phone = phone;
        }
    }

    public class ContactPerson : ContactPersonBase
    {
        protected ContactPerson() { }

        public ContactPerson(Guid id, string name, string email, string phone)
            : base(id, name, email, phone)
        {
        }
    }
}
