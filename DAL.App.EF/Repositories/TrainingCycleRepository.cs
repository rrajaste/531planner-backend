using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingCycleRepository : EFBaseRepository<TrainingCycle, AppDbContext>, ITrainingCycleRepository
    {
        public TrainingCycleRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }

        public async Task<IEnumerable<TrainingCycle>> AllWithRoutineIdAuthorizeAsync(Guid routineId, Guid userId)
        {
            return await RepoDbSet
                .Include(c => c.WorkoutRoutine)
                .Where(c => c.Id == routineId && c.WorkoutRoutine.AppUserId == userId).ToListAsync();
        }

        public async Task<TrainingCycle> FindAuthorizeAsync(Guid? id, Guid userId)
        {
            return await RepoDbSet
                .Include(c => c.WorkoutRoutine)
                .FirstOrDefaultAsync(c => c.Id == id && c.WorkoutRoutine.AppUserId == id);
        }
    }
}