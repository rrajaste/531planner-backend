using System.Data.SqlTypes;
using Contracts.DAL.App;
using DAL.App.DTO;
using DAL.Base.EF;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class PersonalRecordMapper : EFBaseMapper, IDALMapper<Domain.PersonalRecord, PersonalRecord>
    {
        public PersonalRecordMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public PersonalRecord MapDomainToDAL(Domain.PersonalRecord domainObject) =>
            new PersonalRecord()
            {
                Id = domainObject.Id,
                AppUserId = domainObject.Id,
                ExerciseSet = domainObject.ExerciseSet == null 
                    ? null 
                    : MapperContext.ExerciseSetMapper.MapDomainToDAL(domainObject.ExerciseSet),
                ExerciseSetId = domainObject.ExerciseSetId,
                WorkoutRoutine = domainObject.WorkoutRoutine == null 
                    ? null 
                    : MapperContext.WorkoutRoutineMapper.MapDomainToDAL(domainObject.WorkoutRoutine),
                WorkoutRoutineId = domainObject.WorkoutRoutineId
            };
        
        public Domain.PersonalRecord MapDALToDomain(PersonalRecord dalObject) =>
            new Domain.PersonalRecord()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.Id,
                ExerciseSetId = dalObject.ExerciseSetId,
                WorkoutRoutineId = dalObject.WorkoutRoutineId
            };
    }
}