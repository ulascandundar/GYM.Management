using GYM.Management.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace GYM.Management.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ManagementController : AbpControllerBase
{
    protected ManagementController()
    {
        LocalizationResource = typeof(ManagementResource);
    }
}
