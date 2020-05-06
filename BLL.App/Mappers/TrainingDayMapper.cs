using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class TrainingDayMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.TrainingDay, TrainingDay>
    {
        public TrainingDayMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public TrainingDay MapDALToBLL(DAL.App.DTO.TrainingDay dalObject) =>
            new TrainingDay()
            {
                Id = dalObject.Id,
                Date = dalObject.Date,
                ExerciseSets = dalObject.ExerciseSets?.Select(BLLMapperContext.ExerciseSetMapper.MapDALToBLL),
                TrainingWeek = dalObject.TrainingWeek == null 
                    ? null 
                    : BLLMapperContext.TrainingWeekMapper.MapDALToBLL(dalObject.TrainingWeek),
                TrainingWeekId = dalObject.TrainingWeekId,
                TrainingDayType = dalObject.TrainingDayType == null 
                    ? null 
                    : BLLMapperContext.TrainingDayTypeMapper.MapDALToBLL(dalObject.TrainingDayType),
                TrainingDayTypeId = dalObject.TrainingDayTypeId
            };

        public DAL.App.DTO.TrainingDay MapBLLToDAL(TrainingDay dalObject) =>
            new DAL.App.DTO.TrainingDay()
            {
                Id = dalObject.Id,
                Date = dalObject.Date,
                TrainingWeekId = dalObject.TrainingWeekId,
                TrainingDayTypeId = dalObject.TrainingDayTypeId
            };
    }
}