using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PerformedExerciseRepository : EFBaseRepository<PerformedExercise, AppDbContext>, IPerformedExerciseRepository
    {
        public PerformedExerciseRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}