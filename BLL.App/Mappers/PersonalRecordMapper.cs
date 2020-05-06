using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class PersonalRecordMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.PersonalRecord, PersonalRecord>
    {
        public PersonalRecordMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public PersonalRecord MapDALToBLL(DAL.App.DTO.PersonalRecord dalObject) =>
            new PersonalRecord()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.Id,
                ExerciseSet = dalObject.ExerciseSet == null 
                    ? null 
                    : BLLMapperContext.ExerciseSetMapper.MapDALToBLL(dalObject.ExerciseSet),
                ExerciseSetId = dalObject.ExerciseSetId,
            };

        public DAL.App.DTO.PersonalRecord MapBLLToDAL(PersonalRecord dalObject) =>
            new DAL.App.DTO.PersonalRecord()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.Id,
                ExerciseSetId = dalObject.ExerciseSetId,
            };
    }
}