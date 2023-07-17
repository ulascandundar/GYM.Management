using Volo.Abp.Modularity;

namespace GYM.Management;

[DependsOn(
    typeof(ManagementApplicationModule),
    typeof(ManagementDomainTestModule)
    )]
public class ManagementApplicationTestModule : AbpModule
{

}
