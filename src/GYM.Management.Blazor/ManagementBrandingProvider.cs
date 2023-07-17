using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace GYM.Management.Blazor;

[Dependency(ReplaceServices = true)]
public class ManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Gym";
	public override string LogoUrl => "logopng";

	public override string LogoReverseUrl => "logopng";
}
