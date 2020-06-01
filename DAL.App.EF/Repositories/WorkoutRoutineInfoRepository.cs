using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkoutRoutineInfoRepository :
        EFBaseRepository<AppDbContext, WorkoutRoutineInfo, DTO.WorkoutRoutineInfo>,
        IWorkoutRoutineInfoRepository
    {
        public WorkoutRoutineInfoRepository(AppDbContext repoDbContext,
            IDALMapper<WorkoutRoutineInfo, DTO.WorkoutRoutineInfo> mapper)
            : base(repoDbContext, mapper)
        {
        }

        public async Task<IEnumerable<DTO.WorkoutRoutineInfo>> AllForWorkoutRoutineWithIdAsync(Guid routineId)
        {
            var routineInfos = await RepoDbSet
                .Where(info => info.WorkoutRoutineId == routineId)
                .ToListAsync();
            return routineInfos.Select(Mapper.MapDomainToDAL);
        }
    }
}