using DAL.App.DTO;
using DAL.Base.EF.Mappers;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class ExerciseSetMapper : IBaseDALMapper<Domain.ExerciseSet, ExerciseSet>
    {
        public ExerciseSet MapDomainToDAL(Domain.ExerciseSet domainObject) =>
            new ExerciseSet()
            {
                Id = domainObject.Id,
                Completed = domainObject.Completed,
                Distance = domainObject.Distance,
                Duration = domainObject.Duration,
                ExerciseId = domainObject.ExerciseId,
                Exercise = _exerciseMapper.MapDomainToDAL(domainObject.Exercise),
                NrOfReps = domainObject.NrOfReps,
                SetNumber = domainObject.SetNumber,
                TrainingDay = _trainingDayMapper.MapDomainToDAL(domainObject.TrainingDay),
                TrainingDayId = domainObject.TrainingDayId,
            };

        public Domain.ExerciseSet MapDALToDomain(ExerciseSet dalObject) =>
            new Domain.ExerciseSet()
            {
                Id = dalObject.Id,
                Completed = dalObject.Completed,
                Distance = dalObject.Distance,
                Duration = dalObject.Duration,
                ExerciseId = dalObject.ExerciseId,
                NrOfReps = dalObject.NrOfReps,
                SetNumber = dalObject.SetNumber,
                TrainingDayId = dalObject.TrainingDayId,
            };
    }
}