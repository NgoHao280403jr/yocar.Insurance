using Microsoft.Extensions.Localization;
using yocar.Insurance_v1.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace yocar.Insurance_v1;

[Dependency(ReplaceServices = true)]
public class Insurance_v1BrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<Insurance_v1Resource> _localizer;

    public Insurance_v1BrandingProvider(IStringLocalizer<Insurance_v1Resource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
