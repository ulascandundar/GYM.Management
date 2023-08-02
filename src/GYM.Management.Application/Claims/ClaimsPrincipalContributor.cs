using GYM.Management.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;

namespace GYM.Management.Claims
{
    public class SocialSecurityNumberClaimsPrincipalContributor : IAbpClaimsPrincipalContributor, ITransientDependency
    {
        public async Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
        {
            var identity = context.ClaimsPrincipal.Identities.FirstOrDefault();
            var userId = identity?.FindUserId();
            if (userId.HasValue)
            {
                var userService = context.ServiceProvider.GetRequiredService<IIdentityUserRepository>(); //Your custom service
                var user = await userService.GetAsync(userId.Value);
                var result = user.GetProperty<UserType>("UserType");
                var trainerId = user.GetProperty<UserType>("TrainerId");
                if (result != null)
                {
                    identity.AddClaim(new Claim("UserType", result.ToString()));
                    identity.AddClaim(new Claim("TrainerId", trainerId.ToString()));
                }
            }
        }
    }

    public static class CurrentUserExtensions
    {
        public static string GetUserType(this ICurrentUser currentUser)
        {
            return currentUser.FindClaimValue("UserType");
        }

        public static string GetTrainerId(this ICurrentUser currentUser)
        {
            return currentUser.FindClaimValue("TrainerId");
        }
    }
}
