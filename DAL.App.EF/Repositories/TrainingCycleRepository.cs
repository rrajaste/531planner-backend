using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class TrainingCycleRepository :
        EFBaseRepository<AppDbContext, Domain.App.TrainingCycle, DAL.App.DTO.TrainingCycle>,
        ITrainingCycleRepository
    {
        public TrainingCycleRepository(AppDbContext repoDbContext, IDALMapper<Domain.App.TrainingCycle, DAL.App.DTO.TrainingCycle> mapper) 
            : base(repoDbContext, mapper)
        {
        }

        public async Task<IEnumerable<TrainingCycle>> AllWithRoutineIdForUserWithIdAsync(Guid id, Guid? userId) => (
            await RepoDbSet
                .Include(cycle => cycle.WorkoutRoutine)
                .Where(cycle => 
                    cycle.WorkoutRoutineId == id && cycle.WorkoutRoutine.AppUserId == userId
                    ).ToListAsync()
            ).Select(Mapper.MapDomainToDAL);

        public async Task<IEnumerable<TrainingCycle>> AllWithBaseRoutineIdAsync(Guid id) =>
            await AllWithRoutineIdForUserWithIdAsync(id, null);

        public async Task<TrainingCycle> FindWithRoutineIdForUserWithIdAsync(Guid id, Guid? userId) =>
            Mapper.MapDomainToDAL(
                await RepoDbSet
                    .Include(cycle => cycle.WorkoutRoutine)
                    .FirstOrDefaultAsync(cycle => 
                        cycle.WorkoutRoutine.Id == id 
                        && cycle.WorkoutRoutine.AppUserId == userId)
                );

        public Task<TrainingCycle> FindWithBaseRoutineIdAsync(Guid id) => 
            FindWithRoutineIdForUserWithIdAsync(id, null);
    }
}