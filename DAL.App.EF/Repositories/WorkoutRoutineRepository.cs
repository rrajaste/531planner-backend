using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkoutRoutineRepository : EFBaseRepository<AppDbContext, Domain.WorkoutRoutine, DAL.App.DTO.WorkoutRoutine>,
        IWorkoutRoutineRepository
    {
        public WorkoutRoutineRepository(AppDbContext repoDbContext, IDALMapper<WorkoutRoutine, DTO.WorkoutRoutine> mapper) 
            : base(repoDbContext, mapper)
        {
        }

        public async Task<DAL.App.DTO.WorkoutRoutine> ActiveRoutineForUserIdAsync(Guid id) =>
            Mapper.MapDomainToDAL(
                await RepoDbSet
                    .FirstOrDefaultAsync(r =>
                        r.AppUserId == id && r.ClosedAt > DateTime.Now)
                );


        public async Task<IEnumerable<DAL.App.DTO.WorkoutRoutine>> AllNonActiveRoutinesForUserIdAsync(Guid id) => (
            await RepoDbSet
                .Where(r => r.AppUserId == id && r.ClosedAt <= DateTime.Now)
                .ToListAsync()
            ).Select(Mapper.MapDomainToDAL);

        public async Task<IEnumerable<DAL.App.DTO.WorkoutRoutine>> AllBaseRoutinesAsync() => (
            await RepoDbSet
                .Where(r => r.IsBaseRoutine)
                .ToListAsync()
            ).Select(Mapper.MapDomainToDAL);
    }
}