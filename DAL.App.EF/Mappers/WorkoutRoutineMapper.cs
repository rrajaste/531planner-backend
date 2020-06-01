using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;
using Domain.App.Constants;

namespace DAL.App.EF.Mappers
{
    public class WorkoutRoutineMapper : EFBaseMapper, IDALMapper<WorkoutRoutine, DTO.WorkoutRoutine>
    {
        public WorkoutRoutineMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.WorkoutRoutine MapDomainToDAL(WorkoutRoutine domainObject)
        {
            var routineInfo = domainObject.WorkoutRoutineInfos == null
                ? null
                : GetRoutineInfoForCurrentCulture(domainObject.WorkoutRoutineInfos);
            var routine = new DTO.WorkoutRoutine
            {
                Id = domainObject.Id,
                AppUserId = domainObject.Id,
                Name = routineInfo?.Name ?? "",
                Description = routineInfo?.Description ?? "",
                IsBaseRoutine = domainObject.AppUserId == null,
                IsPublished = domainObject.CreatedAt <= DateTime.Now && domainObject.ClosedAt > DateTime.Now,
                RoutineType = domainObject.RoutineType == null
                    ? null
                    : DALMapperContext.RoutineTypeMapper.MapDomainToDAL(domainObject.RoutineType),
                RoutineTypeId = domainObject.RoutineTypeId,
                TrainingCycles =
                    domainObject.TrainingCycles?.Select(DALMapperContext.TrainingCycleMapper.MapDomainToDAL)
            };
            return routine;
        }

        public WorkoutRoutine MapDALToDomain(DTO.WorkoutRoutine dalObject)
        {
            return new WorkoutRoutine
            {
                Id = dalObject.Id,
                AppUserId = dalObject.AppUserId,
                RoutineTypeId = dalObject.RoutineTypeId,
                TrainingCycles = dalObject.TrainingCycles?.Select(DALMapperContext.TrainingCycleMapper.MapDALToDomain)
                    .ToList()
            };
        }

        private static WorkoutRoutineInfo GetRoutineInfoForCurrentCulture(ICollection<WorkoutRoutineInfo> routineInfo)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var isCultureSupported = routineInfo.Any(info => info.CultureCode == currentCulture);
            if (isCultureSupported) return routineInfo.FirstOrDefault(info => info.CultureCode == currentCulture);

            var foundCulture = routineInfo.FirstOrDefault(info => info.CultureCode == Culture.English);
            if (foundCulture != null) return foundCulture;
            throw new ApplicationException("Cannot find routine info for culture " + currentCulture);
        }
    }
}