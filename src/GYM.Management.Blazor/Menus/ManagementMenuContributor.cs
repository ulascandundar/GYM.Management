using System.Threading.Tasks;
using GYM.Management.Localization;
using GYM.Management.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace GYM.Management.Blazor.Menus;

public class ManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<ManagementResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ManagementMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );
		context.Menu.AddItem(
	new ApplicationMenuItem(
		"Exercise",
		"Egzersizler",
		icon: "fa fa-bicycle"
	).AddItem(
		new ApplicationMenuItem(
			"gym.Exercise",
			"Egzersiz Listesi",
			url: "/Exercise"
		)
	)
);

        context.Menu.AddItem(
    new ApplicationMenuItem(
        "Kategori",
        "Kategoriler",
        icon: "fa fa-cubes"
    ).AddItem(
        new ApplicationMenuItem(
            "gym.Kategori",
            "Kategori Listesi",
            url: "/category"
        )
    )
);
        context.Menu.AddItem(
    new ApplicationMenuItem(
        "Antrenor",
        "Antrenorler",
        icon: "fa fa-address-card"
	).AddItem(
        new ApplicationMenuItem(
            "gym.Antrenor",
            "Antrenör Listesi",
            url: "/trainer"
        )
    )
);

        context.Menu.AddItem(
    new ApplicationMenuItem(
        "Uye",
        "Uyeler",
        icon: "fa fa-users"
    ).AddItem(
        new ApplicationMenuItem(
            "gym.Uye",
            "Üye Listesi",
            url: "/Member"
        )
    )
);

        context.Menu.AddItem(
    new ApplicationMenuItem(
        "Urun",
        "Urunler",
        icon: "fa fa-tint"
    ).AddItem(
        new ApplicationMenuItem(
            "gym.Urun",
            "Ürün Listesi",
            url: "/product"
        )
    )
);
        context.Menu.AddItem(new ApplicationMenuItem(
    "Giderler",
    "Giderler",
    icon: "fa fa-book"
).AddItem(new ApplicationMenuItem(
    "gym.Giderler.GiderListesi",
    "Gider Listesi",
    url: "/expense"
)).AddItem(new ApplicationMenuItem(
    "gym.Giderler.KartRaporlari",
    "Kart Raporları",
    url: "/expensereport"
)));
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
