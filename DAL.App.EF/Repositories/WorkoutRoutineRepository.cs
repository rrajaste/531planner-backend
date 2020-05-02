using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Contracts.DAL.App.Mappers;
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

        public async Task<DTO.WorkoutRoutine> ActiveRoutineForUserWithIdAsync(Guid userId) =>
            Mapper.MapDomainToDAL(
                await RepoDbSet.SingleOrDefaultAsync(
                    w => w.AppUserId == userId 
                         && w.CreatedAt <= DateTime.Now 
                         && w.ClosedAt > DateTime.Now)
                );

        public async Task<IEnumerable<DTO.WorkoutRoutine>> AllInactiveRoutinesForUserWithIdAsync(Guid userId) => (
            await RepoDbSet.Where(
                w => w.AppUserId == userId
                     && w.CreatedAt <= DateTime.Now
                     && w.ClosedAt < DateTime.Now
                    ).ToListAsync()
                ).Select(Mapper.MapDomainToDAL);

        public async Task<IEnumerable<DTO.WorkoutRoutine>> AllActiveBaseRoutinesAsync() => (
            await RepoDbSet.Where(
                w => w.AppUserId == null
                     && w.ClosedAt > DateTime.Now
                     && w.CreatedAt <= DateTime.Now
                    ).ToListAsync()
                ).Select(Mapper.MapDomainToDAL);

        public async Task<IEnumerable<DTO.WorkoutRoutine>> AllInactiveBaseRoutinesAsync() => (
            await RepoDbSet.Where(
                w => w.AppUserId == null
                     && w.ClosedAt >= DateTime.Now
                     && w.CreatedAt <= DateTime.Now
                ).ToListAsync()
            ).Select(Mapper.MapDomainToDAL);

        public async Task<IEnumerable<DTO.WorkoutRoutine>> AllUnPublishedBaseRoutinesAsync() => (
            await RepoDbSet.Where(
                w => w.AppUserId == null
                     && w.ClosedAt >= DateTime.Now
                     && w.CreatedAt == DateTime.MaxValue
                ).ToListAsync()
            ).Select(Mapper.MapDomainToDAL);

        public async Task<DTO.WorkoutRoutine> FindBaseRoutineAsync(Guid id) =>
            Mapper.MapDomainToDAL(
                await RepoDbSet.Where(
                    w => w.AppUserId == null
                         && w.Id == id
                ).SingleOrDefaultAsync()
            );
    }
}