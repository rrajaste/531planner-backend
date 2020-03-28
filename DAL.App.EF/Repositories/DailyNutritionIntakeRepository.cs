using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class DailyNutritionIntakeRepository : EFBaseRepository<DailyNutritionIntake, AppDbContext>,
        IDailyNutritionIntakeRepository
    {
        public DailyNutritionIntakeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}