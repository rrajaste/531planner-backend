using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class TrainingDayTypeMapper : EFBaseMapper, IDALMapper<Domain.App.TrainingDayType, TrainingDayType>
    {
        public TrainingDayTypeMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public TrainingDayType MapDomainToDAL(Domain.App.TrainingDayType domainObject) =>
            new TrainingDayType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description
            };

        public Domain.App.TrainingDayType MapDALToDomain(TrainingDayType dalObject) =>
            new Domain.App.TrainingDayType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
    }
}
