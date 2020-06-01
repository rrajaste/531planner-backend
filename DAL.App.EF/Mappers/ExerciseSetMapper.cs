using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class ExerciseSetMapper : EFBaseMapper, IDALMapper<ExerciseSet, DTO.ExerciseSet>
    {
        public ExerciseSetMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.ExerciseSet MapDomainToDAL(ExerciseSet domainObject)
        {
            return new DTO.ExerciseSet
            {
                Id = domainObject.Id,
                Completed = domainObject.Completed,
                Distance = domainObject.Distance,
                Duration = domainObject.Duration,
                ExerciseInTrainingDayId = domainObject.ExerciseInTrainingDayId,
                WorkoutRoutineId = domainObject.WorkoutRoutineId,
                NrOfReps = domainObject.NrOfReps,
                SetNumber = domainObject.SetNumber,
                SetTypeId = domainObject.SetTypeId,
                SetType = domainObject.SetType == null
                    ? null
                    : DALMapperContext.SetTypeMapper.MapDomainToDAL(domainObject.SetType),
                Weight = domainObject.Weight
            };
        }

        public ExerciseSet MapDALToDomain(DTO.ExerciseSet dalObject)
        {
            return new ExerciseSet
            {
                Id = dalObject.Id,
                ExerciseInTrainingDayId = dalObject.ExerciseInTrainingDayId,
                Completed = dalObject.Completed,
                Distance = dalObject.Distance,
                Duration = dalObject.Duration,
                NrOfReps = dalObject.NrOfReps,
                SetNumber = dalObject.SetNumber,
                SetTypeId = dalObject.SetTypeId,
                Weight = dalObject.Weight,
                WorkoutRoutineId = dalObject.WorkoutRoutineId
            };
        }
    }
}