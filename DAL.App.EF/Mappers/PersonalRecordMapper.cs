using DAL.App.DTO;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class PersonalRecordMapper : IBaseDALMapper<Domain.PersonalRecord, PersonalRecord>
    {
        public PersonalRecord MapDomainToDAL(Domain.PersonalRecord domainObject) =>
            new PersonalRecord()
            {
                Id = domainObject.Id,
                AppUserId = domainObject.Id,
                ExerciseSet = _exerciseSetMapper.MapDomainToDAL(domainObject.ExerciseSet),
                ExerciseSetId = domainObject.ExerciseSetId,
                WorkoutRoutine = _workoutRoutineMapper.MapDomainToDAL(domainObject.WorkoutRoutine),
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