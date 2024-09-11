using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.Diagnostics.CodeAnalysis;

namespace yocar.Insurance_v1.Entities.Locations
{
    public abstract class LocationBase : FullAuditedAggregateRoot<Guid>
    {
        public virtual double Latitude { get; set; }

        public virtual double Longitude { get; set; }

        [NotNull]
        public virtual string Address { get; set; }

        public virtual Guid WardId { get; set; }
        protected LocationBase() { }

        public LocationBase(Guid id, double latitude, double longitude, string address, Guid wardId)
        {
            Id = id;
            Latitude = latitude;
            Longitude = longitude;
            Check.NotNull(address, nameof(address));
            Address = address;
            WardId = wardId;
        }
    }

    public class Location : LocationBase
    {
        protected Location() { }

        public Location(Guid id, double latitude, double longitude, string address,Guid wardId)
            : base(id, latitude, longitude, address, wardId)
        {
        }
    }
}
