using System;
using System.Globalization;
using System.Linq;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;

namespace BLL.Mappers
{
    public class TrainingDayMapper : BLLBaseMapper, ITrainingDayMapper
    {
        public TrainingDayMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
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

        public DAL.App.DTO.TrainingDay MapBLLToDAL(TrainingDay bllObject) =>
            new DAL.App.DTO.TrainingDay()
            {
                Id = bllObject.Id,
                Date = bllObject.Date,
                TrainingWeekId = bllObject.TrainingWeekId,
                TrainingDayTypeId = bllObject.TrainingDayTypeId
            };

        public BaseTrainingDay MapDALToBaseTrainingDay(DAL.App.DTO.TrainingDay dalEntity) =>
            new BaseTrainingDay()
            {
                Id = dalEntity.Id,
                DayOfWeek = dalEntity.Date.DayOfWeek,
                ExerciseSets = dalEntity.ExerciseSets?.Select(BLLMapperContext.ExerciseSetMapper.MapDALToBLL),
                TrainingWeek = dalEntity.TrainingWeek == null 
                    ? null 
                    : BLLMapperContext.TrainingWeekMapper.MapDALToBLL(dalEntity.TrainingWeek),
                TrainingWeekId = dalEntity.TrainingWeekId,
                TrainingDayType = dalEntity.TrainingDayType == null 
                    ? null 
                    : BLLMapperContext.TrainingDayTypeMapper.MapDALToBLL(dalEntity.TrainingDayType),
                TrainingDayTypeId = dalEntity.TrainingDayTypeId
            };

        public DAL.App.DTO.TrainingDay MapBaseTrainingDayToDALEntity(BaseTrainingDay baseTrainingDay) =>
            new DAL.App.DTO.TrainingDay()
            {
                Id = baseTrainingDay.Id,
                Date = GetDateFromDayOfWeek(baseTrainingDay.DayOfWeek),
                TrainingWeekId = baseTrainingDay.TrainingWeekId,
                TrainingDayTypeId = baseTrainingDay.TrainingDayTypeId
            };
        
        private static DateTime GetDateFromDayOfWeek(DayOfWeek dayOfWeek)
        {
            var cultureInfo = CultureInfo.GetCultureInfo("ee-EE");
            var baseDates = new DateTime[]
            {
                DateTime.ParseExact("10/05/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact("11/05/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact("12/05/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact("13/05/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact("14/05/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact("15/05/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact("16/05/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            };
            var dayNumber = (int) dayOfWeek;
            return baseDates[dayNumber];
        }
    }
}