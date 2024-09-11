using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.Diagnostics.CodeAnalysis;
using yocar.Insurance_v1.Entities.Garages;

namespace yocar.Insurance_v1.Entities.Brands
{
    public abstract class BrandBase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string Slug { get; set; }

        [NotNull]
        public virtual string Description { get; set; }

        public virtual bool IsVerified { get; set; }
        public virtual ICollection<Garage> Garages { get; set; } = new HashSet<Garage>();
        protected BrandBase() { }

        public BrandBase(Guid id, string name, string slug, string description, bool isVerified)
        {
            Id = id;
            Check.NotNull(name, nameof(name));
            Check.NotNull(slug, nameof(slug));
            Check.NotNull(description, nameof(description));
            Name = name;
            Slug = slug;
            Description = description;
            IsVerified = isVerified;
        }
    }

    public class Brand : BrandBase
    {
        protected Brand() { }

        public Brand(Guid id, string name, string slug, string description, bool isVerified)
            : base(id, name, slug, description, isVerified)
        {
        }
    }
}
