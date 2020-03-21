using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class DailyNutritionIntakeRepository : BaseRepository<DailyNutritionIntake>, IDailyNutritionIntakeRepository
    {
        public DailyNutritionIntakeRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}
