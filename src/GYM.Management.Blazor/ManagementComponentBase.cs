using GYM.Management.Localization;
using Volo.Abp.AspNetCore.Components;

namespace GYM.Management.Blazor;

public abstract class ManagementComponentBase : AbpComponentBase
{
    protected ManagementComponentBase()
    {
        LocalizationResource = typeof(ManagementResource);
    }
}
