using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class TrainingDayTypeMapper : EFBaseMapper, IDALMapper<Domain.TrainingDayType, TrainingDayType>
    {
        public TrainingDayTypeMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public TrainingDayType MapDomainToDAL(Domain.TrainingDayType domainObject) =>
            new TrainingDayType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description
            };

        public Domain.TrainingDayType MapDALToDomain(TrainingDayType dalObject) =>
            new Domain.TrainingDayType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
    }
}
