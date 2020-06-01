using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class WorkoutRoutineInfoMapper : EFBaseMapper, IDALMapper<Domain.App.WorkoutRoutineInfo, WorkoutRoutineInfo>
    {
        public WorkoutRoutineInfoMapper(IAppDALMapperContext context) : base(context)
        {
        }

        public WorkoutRoutineInfo MapDomainToDAL(Domain.App.WorkoutRoutineInfo domainObject)
        {
            return new WorkoutRoutineInfo()
            {
                Description = domainObject.Description,
                Id = domainObject.Id,
                Name = domainObject.Name,
                WorkoutRoutineId = domainObject.WorkoutRoutineId,
                CultureCode = domainObject.CultureCode
            };
        }

        public Domain.App.WorkoutRoutineInfo MapDALToDomain(WorkoutRoutineInfo dalObject)
        {
            return new Domain.App.WorkoutRoutineInfo()
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