using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ExerciseTypeRepository : BaseRepository<ExerciseType>, IExerciseTypeRepository
    {
        public ExerciseTypeRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}