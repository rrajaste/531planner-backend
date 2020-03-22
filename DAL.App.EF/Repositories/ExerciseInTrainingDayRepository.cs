using Contracts.DAL.App;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ExerciseInTrainingDayRepository : BaseRepository<ExerciseInTrainingDay>, IExerciseInTrainingDayRepository
    {
        public ExerciseInTrainingDayRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}