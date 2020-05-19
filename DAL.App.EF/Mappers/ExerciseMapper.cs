using System;
using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class ExerciseMapper : EFBaseMapper, IDALMapper<Domain.App.Exercise, Exercise>
    {
        public ExerciseMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public Exercise MapDomainToDAL(Domain.App.Exercise domainObject) =>
            new Exercise()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                TargetMuscleGroups = domainObject.TargetMuscleGroups?
                    .Select(
                        t => t.MuscleGroup != null 
                            ? DALMapperContext.MuscleGroupMapper.MapDomainToDAL(t.MuscleGroup) 
                            : throw new ApplicationException("Muscle group cannot be null!")
                        )
            };

        public Domain.App.Exercise MapDALToDomain(Exercise dalObject) =>
            new Domain.App.Exercise()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
            };
    }
}