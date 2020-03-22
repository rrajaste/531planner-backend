using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkoutRoutineRepository : BaseRepository<WorkoutRoutine>, IWorkoutRoutineRepository
    {
        public WorkoutRoutineRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}