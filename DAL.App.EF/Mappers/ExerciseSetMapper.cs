using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class ExerciseSetMapper : EFBaseMapper, IDALMapper<Domain.App.ExerciseSet, ExerciseSet>
    {
        public ExerciseSetMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public ExerciseSet MapDomainToDAL(Domain.App.ExerciseSet domainObject) =>
            new ExerciseSet()
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

        public Domain.App.ExerciseSet MapDALToDomain(ExerciseSet dalObject) =>
            new Domain.App.ExerciseSet()
            {
                Id = dalObject.Id,
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
