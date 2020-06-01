using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;
using PublicApi.DTO.V1;
using Culture = Domain.App.Constants.Culture;
using WorkoutRoutine = DAL.App.DTO.WorkoutRoutine;

namespace DAL.App.EF.Mappers
{
    public class WorkoutRoutineMapper : EFBaseMapper, IDALMapper<Domain.App.WorkoutRoutine, WorkoutRoutine>
    {
        public WorkoutRoutineMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public WorkoutRoutine MapDomainToDAL(Domain.App.WorkoutRoutine domainObject)
        {
            var routineInfo = domainObject.WorkoutRoutineInfos == null 
                ? null 
                : GetRoutineInfoForCurrentCulture(domainObject.WorkoutRoutineInfos);
            var routine = new WorkoutRoutine()
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
                TrainingCycles = domainObject.TrainingCycles?.Select(DALMapperContext.TrainingCycleMapper.MapDomainToDAL)
            };
            return routine;
        }

        public Domain.App.WorkoutRoutine MapDALToDomain(WorkoutRoutine dalObject) =>
            new Domain.App.WorkoutRoutine()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.AppUserId,
                RoutineTypeId = dalObject.RoutineTypeId,
                TrainingCycles = dalObject.TrainingCycles?.Select(DALMapperContext.TrainingCycleMapper.MapDALToDomain)
                    .ToList()
            };

        private static WorkoutRoutineInfo GetRoutineInfoForCurrentCulture(ICollection<WorkoutRoutineInfo> routineInfo)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var isCultureSupported = routineInfo.Any(info => info.CultureCode == currentCulture);
            if (isCultureSupported)
            {
                return routineInfo.FirstOrDefault(info => info.CultureCode == currentCulture);
            }

            var foundCulture = routineInfo.FirstOrDefault(info => info.CultureCode == Culture.English);
            if (foundCulture != null)
            {
                return foundCulture;
            }
            throw new ApplicationException("Cannot find routine info for culture " + currentCulture);
        }
    }
}
