using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class ExerciseTypeMapper : EFBaseMapper, IDALMapper<Domain.App.ExerciseType, ExerciseType>
    {
        public ExerciseTypeMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public ExerciseType MapDomainToDAL(Domain.App.ExerciseType domainObject) =>
            new ExerciseType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                TypeCode = domainObject.TypeCode
            };


        public Domain.App.ExerciseType MapDALToDomain(ExerciseType dalObject) =>
            new Domain.App.ExerciseType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                TypeCode = dalObject.TypeCode
            };
    }
}