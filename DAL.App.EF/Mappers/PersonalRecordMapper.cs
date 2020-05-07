using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class PersonalRecordMapper : EFBaseMapper, IDALMapper<Domain.App.PersonalRecord, PersonalRecord>
    {
        public PersonalRecordMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public PersonalRecord MapDomainToDAL(Domain.App.PersonalRecord domainObject) =>
            new PersonalRecord()
            {
                Id = domainObject.Id,
                AppUserId = domainObject.Id,
                ExerciseSet = domainObject.ExerciseSet == null 
                    ? null 
                    : DALMapperContext.ExerciseSetMapper.MapDomainToDAL(domainObject.ExerciseSet),
                ExerciseSetId = domainObject.ExerciseSetId,
            };

        public Domain.App.PersonalRecord MapDALToDomain(PersonalRecord dalObject) =>
            new Domain.App.PersonalRecord()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.Id,
                ExerciseSetId = dalObject.ExerciseSetId,
            };
    }
}