using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.Diagnostics.CodeAnalysis;
using yocar.Insurance_v1.Entities.Garages;

namespace yocar.Insurance_v1.Entities.InsuranceCompanies
{
    public abstract class InsuranceCompanyBase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string Description { get; set; }

        public virtual ICollection<Garage> Garages { get; set; } = new HashSet<Garage>();

        protected InsuranceCompanyBase() { }

        public InsuranceCompanyBase(Guid id, string name, string description)
        {
            Id = id;
            Check.NotNull(name, nameof(name));
            Check.NotNull(description, nameof(description));
            Name = name;
            Description = description;
        }
    }

    public class InsuranceCompany : InsuranceCompanyBase
    {
        protected InsuranceCompany() { }

        public InsuranceCompany(Guid id, string name, string description)
            : base(id, name, description)
        {
        }
    }
}
