using AutoMapper;
using GYM.Management.Categories;
using GYM.Management.Exercises;
using GYM.Management.Expenses;
using GYM.Management.Losses;
using GYM.Management.MemberOrders;
using GYM.Management.Members;
using GYM.Management.Products;
using GYM.Management.SafeTransactions;
using GYM.Management.StockTakings;
using GYM.Management.Trainers;

namespace GYM.Management;

public class ManagementApplicationAutoMapperProfile : Profile
{
    public ManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Exercise, ExerciseDto>().ReverseMap();
        CreateMap<Exercise, ExercisCreateDto>().ReverseMap();
        CreateMap<ExerciseDto, ExercisCreateDto>().ReverseMap();

        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<CategoryDto, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryWithExercises>().ReverseMap();

        CreateMap<Trainer, TrainerDto>().ReverseMap();
        CreateMap<Trainer, TrainerCreateDto>().ReverseMap();
        CreateMap<TrainerDto, TrainerCreateDto>().ReverseMap();

        CreateMap<Member, MemberDto>().ReverseMap();
        CreateMap<Member, MemberCreateDto>().ReverseMap();
        CreateMap<MemberDto, MemberCreateDto>().ReverseMap();

        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<ProductDto, ProductCreateDto>().ReverseMap();

        CreateMap<Expense, ExpenseDto>().ReverseMap();
        CreateMap<Expense, ExpenseCreateDto>().ReverseMap();
        CreateMap<ExpenseDto, ExpenseCreateDto>().ReverseMap();

		CreateMap<MemberOrder, MemberOrderDto>().ReverseMap();
		CreateMap<MemberOrder, MemberOrderCreateDto>().ReverseMap();
		CreateMap<MemberOrderDto, MemberOrderCreateDto>().ReverseMap();

        CreateMap<StockTaking, StockTakingDto>().ReverseMap();
        CreateMap<StockTaking, StockTakingCreateDto>().ReverseMap();
        CreateMap<StockTakingDto, StockTakingCreateDto>().ReverseMap();

		CreateMap<Loss, LossDto>().ReverseMap();
		CreateMap<Loss, LossCreateDto>().ReverseMap();
		CreateMap<LossDto, LossCreateDto>().ReverseMap();

        CreateMap<SafeTransaction, SafeTransactionDto>().ReverseMap();
        CreateMap<SafeTransaction, SafeTransactionDto>().ReverseMap();
        CreateMap<SafeTransactionDto, SafeTransactionCreateDto>().ReverseMap();
    }
}
