using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class DailyNutritionIntakeRepository : EFBaseRepository<DailyNutritionIntake,AppDbContext>, IDailyNutritionIntakeRepository
    {
        public DailyNutritionIntakeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}
