using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.Diagnostics.CodeAnalysis;
using yocar.Insurance_v1.Entities.InsuranceCompanies;
using yocar.Insurance_v1.Entities.Brands;

namespace yocar.Insurance_v1.Entities.Garages
{
    public abstract class GarageBase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string Address { get; set; }

        public virtual Guid InsuranceCompanyId { get; set; }

        public virtual InsuranceCompany InsuranceCompany { get; set; }
        public virtual Guid? BrandId { get; set; } // Optional foreign key
        public virtual Brand? Brand { get; set; } // Optional navigation property
        protected GarageBase() { }

        public GarageBase(Guid id, string name, string address, Guid insuranceCompanyId)
        {
            Id = id;
            Check.NotNull(name, nameof(name));
            Check.NotNull(address, nameof(address));
            Name = name;
            Address = address;
            InsuranceCompanyId = insuranceCompanyId;
        }
    }

    public class Garage : GarageBase
    {
        protected Garage() { }

        public Garage(Guid id, string name, string address, Guid insuranceCompanyId)
            : base(id, name, address, insuranceCompanyId)
        {
        }
    }
}
