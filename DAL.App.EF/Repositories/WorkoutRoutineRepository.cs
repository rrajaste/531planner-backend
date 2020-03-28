using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class WorkoutRoutineRepository : EFBaseRepository<WorkoutRoutine, AppDbContext>, IWorkoutRoutineRepository
    {
        public WorkoutRoutineRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}