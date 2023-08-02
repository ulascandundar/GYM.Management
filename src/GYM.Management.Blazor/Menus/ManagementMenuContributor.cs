using System.Threading.Tasks;
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
        "Test",
        "Testler",
        icon: "fa fa-rocket"
    ).RequirePermissions(ManagementPermissions.Member.AppointmentTransaction).AddItem(
        new ApplicationMenuItem(
            "gym.Test",
            "Test Listesi",
            url: "/AppointmentTransaction"
        ).RequirePermissions(ManagementPermissions.Member.AppointmentTransaction)
    ).RequirePermissions(ManagementPermissions.Member.AppointmentTransaction)
);

        context.Menu.AddItem(
   new ApplicationMenuItem(
       "Diger",
       "Diğer",
       icon: "fa fa-tasks"

   ).AddItem(
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
).AddItem(
    new ApplicationMenuItem(
        "Safe",
        "Kasa",
        icon: "fa fa-archive"
    ).RequirePermissions(ManagementPermissions.Safe.Default).AddItem(
        new ApplicationMenuItem(
            "gym.Safe",
            "Kasa",
            url: "/safe"
        )
    )
).AddItem(
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
).AddItem(
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
).AddItem(
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
).AddItem(
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
).AddItem(new ApplicationMenuItem(
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
).RequirePermissions(ManagementPermissions.Exercise.Default)).AddItem(new ApplicationMenuItem("gym.Giderypes", "Gider Tipleri", url: "/expensetype").RequirePermissions(ManagementPermissions.ExpenseType.Default))).AddItem(new ApplicationMenuItem(
            "gym.Grafikler",
            "Grafikler",
            icon: "fa fa-bar-chart"
            ).RequirePermissions(ManagementPermissions.Graphic.Default).AddItem(
                new ApplicationMenuItem(
                    "gym.",
                    "Gider Grafiği",
                    url: "/expensechart"
                    )
            ))
);

//        context.Menu.AddItem(
//	new ApplicationMenuItem(
//		"Exercise",
//		"Egzersizler",
//		icon: "fa fa-bicycle"
//	).RequirePermissions(ManagementPermissions.Exercise.Default).AddItem(
//		new ApplicationMenuItem(
//			"gym.Exercise",
//			"Egzersiz Listesi",
//			url: "/Exercise"
//		)
//	)
//);

//        context.Menu.AddItem(
//    new ApplicationMenuItem(
//        "Safe",
//        "Kasa",
//        icon: "fa fa-bicycle"
//    ).RequirePermissions(ManagementPermissions.Safe.Default).AddItem(
//        new ApplicationMenuItem(
//            "gym.Safe",
//            "Kasa",
//            url: "/safe"
//        )
//    )
//);

//        context.Menu.AddItem(
//    new ApplicationMenuItem(
//        "Kategori",
//        "Kategoriler",
//        icon: "fa fa-cubes"
//    ).RequirePermissions(ManagementPermissions.Category.Default).AddItem(
//        new ApplicationMenuItem(
//            "gym.Kategori",
//            "Kategori Listesi",
//            url: "/category"
//        )
//    )
//);
//        context.Menu.AddItem(
//    new ApplicationMenuItem(
//        "Antrenor",
//        "Antrenorler",
//        icon: "fa fa-address-card"
//	).RequirePermissions(ManagementPermissions.Trainer.Default).AddItem(
//        new ApplicationMenuItem(
//            "gym.Antrenor",
//            "Antrenör Listesi",
//            url: "/trainer"
//        )
//    )
//);

//        context.Menu.AddItem(
//    new ApplicationMenuItem(
//        "Uye",
//        "Uyeler",
//        icon: "fa fa-users"
//    ).RequirePermissions(ManagementPermissions.Member.Default).AddItem(
//        new ApplicationMenuItem(
//            "gym.Uye",
//            "Üye Listesi",
//            url: "/Member"
//        )
//    ).AddItem(new ApplicationMenuItem("gym.UyeRandevuGecmisi","Üye Randevu Geçmişi", url: "/AppointmentTransaction")).RequirePermissions(ManagementPermissions.Member.AppintmentTransaction)
//);

//        context.Menu.AddItem(
//    new ApplicationMenuItem(
//        "Urun",
//        "Urunler",
//        icon: "fa fa-tint"
//    ).RequirePermissions(ManagementPermissions.Product.Default).AddItem(
//        new ApplicationMenuItem(
//            "gym.Urun",
//            "Ürün Listesi",
//            url: "/product"
//        ).RequirePermissions(ManagementPermissions.Product.Default)
//    ).AddItem(new ApplicationMenuItem(
//    "gym.Urun.StokSayim",
//    "Stok Sayımları",
//    url: "/stocktakings"
//).RequirePermissions(ManagementPermissions.Product.StockTakingHistory)).AddItem(new ApplicationMenuItem(
//    "gym.Urun.Zaiyat",
//    "Zaiyat Geçmişi",
//    url: "/loss"
//).RequirePermissions(ManagementPermissions.Product.StockLossHistory))
//);



//        context.Menu.AddItem(new ApplicationMenuItem(
//    "Giderler",
//    "Giderler",
//    icon: "fa fa-book"
//).RequirePermissions(ManagementPermissions.Expense.Default).AddItem(new ApplicationMenuItem(
//    "gym.Giderler.GiderListesi",
//    "Gider Listesi",
//    url: "/expense"
//).RequirePermissions(ManagementPermissions.Exercise.Default)).AddItem(new ApplicationMenuItem(
//    "gym.Giderler.KartRaporlari",
//    "Kart Raporları",
//    url: "/expensereport"
//).RequirePermissions(ManagementPermissions.Exercise.Default)));

//        context.Menu.AddItem(new ApplicationMenuItem(
//            "gym.Grafikler",
//            "Grafikler",
//            icon: "fa fa-bar-chart"
//            ).RequirePermissions(ManagementPermissions.Graphic.Default).AddItem(
//                new ApplicationMenuItem(
//                    "gym.",
//                    "Gider Grafiği",
//                    url: "/expensechart"
//                    )
//            ));
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
