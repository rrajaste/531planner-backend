using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkoutRoutineRepository : EFBaseRepository<WorkoutRoutine, AppDbContext>, IWorkoutRoutineRepository
    {
        public WorkoutRoutineRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }

        public WorkoutRoutine ActiveRoutineForUserId(Guid id)
        {
            return RepoDbSet.FirstOrDefault(r => r.AppUserId == id && r.ClosedAt > DateTime.Now);
        }

        public async Task<WorkoutRoutine> ActiveRoutineForUserIdAsync(Guid id)
        {
            return await RepoDbSet.FirstOrDefaultAsync(r => r.AppUserId == id && r.ClosedAt > DateTime.Now);
        }

        public IEnumerable<WorkoutRoutine> AllNonActiveRoutinesForUserId(Guid id)
        {
            return RepoDbSet.Where(r => r.AppUserId == id && r.ClosedAt <= DateTime.Now).ToList();
        }

        public async Task<IEnumerable<WorkoutRoutine>> AllNonActiveRoutinesForUserIdAsync(Guid id)
        {
            return await RepoDbSet.Where(r => r.AppUserId == id && r.ClosedAt <= DateTime.Now).ToListAsync();
        }

        public IEnumerable<WorkoutRoutine> AllBaseRoutines()
        {
            return RepoDbSet.Where(r => r.IsBaseRoutine).ToList();
        }

        public async Task<IEnumerable<WorkoutRoutine>> AllBaseRoutinesAsync()
        {
            return await RepoDbSet.Where(r => r.IsBaseRoutine).ToListAsync();
        }
    }
}