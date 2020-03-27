using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ExerciseRepository : EFBaseRepository<Exercise, AppDbContext>, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}