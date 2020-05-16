using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Contracts.DAL.App.Mappers;
using Domain.App;
using Microsoft.EntityFrameworkCore;
namespace DAL.App.EF.Repositories
{
    public class TrainingWeekRepository : EFBaseRepository<AppDbContext, TrainingWeek, DAL.App.DTO.TrainingWeek>,
        ITrainingWeekRepository
    {
        public TrainingWeekRepository(AppDbContext repoDbContext, IDALMapper<TrainingWeek, DAL.App.DTO.TrainingWeek> mapper) 
            : base(repoDbContext, mapper)
        {
        }

        public async Task<IEnumerable<DTO.TrainingWeek>> AllWithBaseRoutineIdAsync(Guid baseRoutineId)
        {
            var trainingCycle = await RepoDbContext
                .TrainingCycles
                    .Include(c => c.TrainingWeeks)
                    .ThenInclude(w => w.TrainingDays)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.WorkoutRoutineId.Equals(baseRoutineId));
            
            var mappedWeeks = trainingCycle.TrainingWeeks.Select(Mapper.MapDomainToDAL);
            return mappedWeeks;
        }

        public async Task<bool> IsPartOfBaseRoutineAsync(Guid id) => 
            await RepoDbSet
                .Include(w => w.TrainingCycle)
                .ThenInclude(c => c!.WorkoutRoutine)
                .AnyAsync( w=> 
                    w.Id == id 
                    && w.TrainingCycle!.WorkoutRoutine!.AppUserId == null
                );

        public async Task<DTO.TrainingWeek> FindAsync(Guid id, bool includeTrainingDays=false)
        {
            var query = RepoDbSet;
            if (includeTrainingDays)
            {
                query.Include(w => w.TrainingDays);
            }
            var result = await query.AsNoTracking().FirstOrDefaultAsync(w => w.Id == id);
            return Mapper.MapDomainToDAL(result);
        }
    }
}