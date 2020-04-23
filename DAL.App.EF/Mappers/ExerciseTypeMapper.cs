using Contracts.DAL.App;
using DAL.App.DTO;
using DAL.Base.EF;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class ExerciseTypeMapper : EFBaseMapper, IDALMapper<Domain.ExerciseType, ExerciseType>
    {
        public ExerciseTypeMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public ExerciseType MapDomainToDAL(Domain.ExerciseType domainObject) =>
            new ExerciseType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                TypeCode = domainObject.TypeCode
            };


        public Domain.ExerciseType MapDALToDomain(ExerciseType dalObject) =>
            new Domain.ExerciseType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                TypeCode = dalObject.TypeCode
            };
    }
}