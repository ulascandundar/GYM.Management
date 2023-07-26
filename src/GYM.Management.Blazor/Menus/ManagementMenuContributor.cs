﻿using System.Threading.Tasks;
using GYM.Management.Localization;
using GYM.Management.MultiTenancy;
using GYM.Management.Permissions;
using Volo.Abp.Authorization.Permissions;
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
	).RequirePermissions(ManagementPermissions.Exercise.Default).AddItem(
		new ApplicationMenuItem(
			"gym.Exercise",
			"Egzersiz Listesi",
			url: "/Exercise"
		)
	)
);

        context.Menu.AddItem(
    new ApplicationMenuItem(
        "Safe",
        "Kasa",
        icon: "fa fa-bicycle"
    ).RequirePermissions(ManagementPermissions.Safe.Default).AddItem(
        new ApplicationMenuItem(
            "gym.Safe",
            "Kasa",
            url: "/safe"
        )
    )
);

        context.Menu.AddItem(
    new ApplicationMenuItem(
        "Kategori",
        "Kategoriler",
        icon: "fa fa-cubes"
    ).RequirePermissions(ManagementPermissions.Category.Default).AddItem(
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
	).RequirePermissions(ManagementPermissions.Trainer.Default).AddItem(
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
    ).RequirePermissions(ManagementPermissions.Member.Default).AddItem(
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
    ).RequirePermissions(ManagementPermissions.Product.Default).AddItem(
        new ApplicationMenuItem(
            "gym.Urun",
            "Ürün Listesi",
            url: "/product"
        ).RequirePermissions(ManagementPermissions.Product.Default)
    ).AddItem(new ApplicationMenuItem(
    "gym.Urun.StokSayim",
    "Stok Sayımları",
    url: "/stocktakings"
).RequirePermissions(ManagementPermissions.Product.StockTakingHistory)).AddItem(new ApplicationMenuItem(
    "gym.Urun.Zaiyat",
    "Zaiyat Geçmişi",
    url: "/loss"
).RequirePermissions(ManagementPermissions.Product.StockLossHistory))
);



        context.Menu.AddItem(new ApplicationMenuItem(
    "Giderler",
    "Giderler",
    icon: "fa fa-book"
).RequirePermissions(ManagementPermissions.Expense.Default).AddItem(new ApplicationMenuItem(
    "gym.Giderler.GiderListesi",
    "Gider Listesi",
    url: "/expense"
).RequirePermissions(ManagementPermissions.Exercise.Default)).AddItem(new ApplicationMenuItem(
    "gym.Giderler.KartRaporlari",
    "Kart Raporları",
    url: "/expensereport"
).RequirePermissions(ManagementPermissions.Exercise.Default)));
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
