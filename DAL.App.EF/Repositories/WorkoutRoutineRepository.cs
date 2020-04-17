using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkoutRoutineRepository : EFBaseRepository<AppDbContext, Domain.WorkoutRoutine, DAL.App.DTO.WorkoutRoutine>,
        IWorkoutRoutineRepository
    {
        public WorkoutRoutineRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }

        public async Task<DAL.App.DTO.WorkoutRoutine> ActiveRoutineForUserIdAsync(Guid id) =>
            Mapper.Map(
                await RepoDbSet
                    .FirstOrDefaultAsync(r =>
                        r.AppUserId == id && r.ClosedAt > DateTime.Now)
                );


        public async Task<IEnumerable<DAL.App.DTO.WorkoutRoutine>> AllNonActiveRoutinesForUserIdAsync(Guid id) => (
            await RepoDbSet
                .Where(r => r.AppUserId == id && r.ClosedAt <= DateTime.Now)
                .ToListAsync()
            ).Select(Mapper.Map);

        public async Task<IEnumerable<DAL.App.DTO.WorkoutRoutine>> AllBaseRoutinesAsync() => (
            await RepoDbSet
                .Where(r => r.IsBaseRoutine)
                .ToListAsync()
            ).Select(Mapper.Map);
    }
}