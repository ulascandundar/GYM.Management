﻿using GYM.Management.AppointmentTransactions;
using GYM.Management.Categories;
using GYM.Management.Debts;
using GYM.Management.ExerciseCategories;
using GYM.Management.Exercises;
using GYM.Management.Expenses;
using GYM.Management.ExpenseTypes;
using GYM.Management.Gains;
using GYM.Management.Losses;
using GYM.Management.MemberOrders;
using GYM.Management.Members;
using GYM.Management.Products;
using GYM.Management.Safes;
using GYM.Management.SafeTransactions;
using GYM.Management.StockTakings;
using GYM.Management.Trainers;
using GYM.Management.Wallets;
using GYM.Management.WalletTransactions;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace GYM.Management.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ManagementDbContext :
    AbpDbContext<ManagementDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Member> Member { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<MemberOrder> MemberOrders { get; set; }
    public DbSet<Gain> Gains { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<WalletTransaction> WalletTransactions { get; set; }
    public DbSet<StockTaking> StockTakings { get; set; }
    public DbSet<Loss> Losses { get; set; }
    public DbSet<Safe> Safes { get; set; }
    public DbSet<SafeTransaction> SafeTransactions  { get; set; }
    public DbSet<AppointmentTransaction> AppointmentTransactions { get; set; }
    public DbSet<ExpenseType> ExpenseTypes { get; set; }
    public DbSet<Debt> Debts { get; set; }
    public ManagementDbContext(DbContextOptions<ManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        builder.Entity<Expense>()
            .Property(o => o.ExpenseTypeId)
            .HasDefaultValue(Guid.Parse(StaticConsts.Spending));
        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(ManagementConsts.DbTablePrefix + "YourEntities", ManagementConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
