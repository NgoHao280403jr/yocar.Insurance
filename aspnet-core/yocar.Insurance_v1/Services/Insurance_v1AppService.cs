using yocar.Insurance_v1.Localization;
using Volo.Abp.Application.Services;

namespace yocar.Insurance_v1.Services;

/* Inherit your application services from this class. */
public abstract class Insurance_v1AppService : ApplicationService
{
    protected Insurance_v1AppService()
    {
        LocalizationResource = typeof(Insurance_v1Resource);
    }
}