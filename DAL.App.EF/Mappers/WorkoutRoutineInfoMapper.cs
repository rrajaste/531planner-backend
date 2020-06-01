using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class WorkoutRoutineInfoMapper : EFBaseMapper, IDALMapper<WorkoutRoutineInfo, DTO.WorkoutRoutineInfo>
    {
        public WorkoutRoutineInfoMapper(IAppDALMapperContext context) : base(context)
        {
        }

        public DTO.WorkoutRoutineInfo MapDomainToDAL(WorkoutRoutineInfo domainObject)
        {
            return new DTO.WorkoutRoutineInfo
            {
                Description = domainObject.Description,
                Id = domainObject.Id,
                Name = domainObject.Name,
                WorkoutRoutineId = domainObject.WorkoutRoutineId,
                CultureCode = domainObject.CultureCode
            };
        }

        public WorkoutRoutineInfo MapDALToDomain(DTO.WorkoutRoutineInfo dalObject)
        {
            return new WorkoutRoutineInfo
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                WorkoutRoutineId = dalObject.WorkoutRoutineId,
                CultureCode = dalObject.CultureCode
            };
        }
    }
}