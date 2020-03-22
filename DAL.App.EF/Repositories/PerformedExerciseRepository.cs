using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PerformedExerciseRepository : BaseRepository<PerformedExercise>, IPerformedExerciseRepository
    {
        public PerformedExerciseRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}