using GYM.Management.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace GYM.Management;

[DependsOn(
    typeof(ManagementEntityFrameworkCoreTestModule)
    )]
public class ManagementDomainTestModule : AbpModule
{

}
