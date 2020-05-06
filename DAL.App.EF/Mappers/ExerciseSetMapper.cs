using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class ExerciseSetMapper : EFBaseMapper, IDALMapper<Domain.ExerciseSet, ExerciseSet>
    {
        public ExerciseSetMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public ExerciseSet MapDomainToDAL(Domain.ExerciseSet domainObject) =>
            new ExerciseSet()
            {
                Id = domainObject.Id,
                Completed = domainObject.Completed,
                Distance = domainObject.Distance,
                Duration = domainObject.Duration,
                ExerciseId = domainObject.ExerciseId,
                Exercise = domainObject.Exercise == null 
                    ? null 
                    : DALMapperContext.ExerciseMapper.MapDomainToDAL(domainObject.Exercise),
                NrOfReps = domainObject.NrOfReps,
                SetNumber = domainObject.SetNumber,
                TrainingDay = domainObject.TrainingDay == null 
                ? null 
                : DALMapperContext.TrainingDayMapper.MapDomainToDAL(domainObject.TrainingDay),
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
