using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ExerciseTypeRepository : EFBaseRepository<ExerciseType, AppDbContext>, IExerciseTypeRepository
    {
        public ExerciseTypeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}