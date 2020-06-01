using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using Domain.App.Enums;

namespace BLL.Mappers
{
    public class TrainingDayMapper : BLLBaseMapper, ITrainingDayMapper
    {
        public TrainingDayMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public BaseTrainingDay MapDALToBLL(DAL.App.DTO.TrainingDay dalObject)
        {
            var trainingDay = new BaseTrainingDay()
            {
                Id = dalObject.Id,
                DayOfWeek = dalObject.Date.DayOfWeek,
                TrainingWeekId = dalObject.TrainingWeekId,
                TrainingDayType = dalObject.TrainingDayType == null
                    ? null
                    : BLLMapperContext.TrainingDayTypeMapper.MapDALToBLL(dalObject.TrainingDayType),
                TrainingDayTypeId = dalObject.TrainingDayTypeId
            };
            return AddExercisesToTrainingDay(trainingDay, dalObject);
        }
        
        public DAL.App.DTO.TrainingDay MapBLLToDAL(BaseTrainingDay bllObject) =>
            new DAL.App.DTO.TrainingDay()
            {
                Id = bllObject.Id,
                Date = GetDateFromDayOfWeek(bllObject.DayOfWeek),
                TrainingWeekId = bllObject.TrainingWeekId,
                TrainingDayTypeId = bllObject.TrainingDayTypeId,
                ExercisesInTrainingDay = bllObject.AccessoryLifts?
                    .Select(BLLMapperContext.ExerciseInTrainingDayMapper.MapBLLToDAL)
                    .Concat(bllObject.MainLifts?
                        .Select(BLLMapperContext.ExerciseInTrainingDayMapper.MapBLLToDAL))
            };

        public UserTrainingDay MapDALToUserTrainingDay(DAL.App.DTO.TrainingDay dalEntity)
        {
            var userTrainingDay = new UserTrainingDay()
            {
                Id = dalEntity.Id,
                Date = dalEntity.Date,
                TrainingWeekId = dalEntity.TrainingWeekId,
                TrainingDayType = dalEntity.TrainingDayType == null
                    ? null
                    : BLLMapperContext.TrainingDayTypeMapper.MapDALToBLL(dalEntity.TrainingDayType),
                TrainingDayTypeId = dalEntity.TrainingDayTypeId
            };
            return AddExercisesToTrainingDay(userTrainingDay, dalEntity);
        }

        public DAL.App.DTO.TrainingDay MapUserTrainingDayToDALEntity(UserTrainingDay userTrainingDay) =>
            new DAL.App.DTO.TrainingDay()
            {
                Id = userTrainingDay.Id,
                Date = userTrainingDay.Date,
                TrainingWeekId = userTrainingDay.TrainingWeekId,
                TrainingDayTypeId = userTrainingDay.TrainingDayTypeId,
                ExercisesInTrainingDay = userTrainingDay.AccessoryLifts?
                    .Select(BLLMapperContext.ExerciseInTrainingDayMapper.MapBLLToDAL)
                    .Concat(userTrainingDay.MainLifts?
                        .Select(BLLMapperContext.ExerciseInTrainingDayMapper.MapBLLToDAL))
            };

        private static DateTime GetDateFromDayOfWeek(DayOfWeek dayOfWeek)
        {
            var baseDates = new DateTime[]
            {
                DateTime.ParseExact("17/05/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture),
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
        
        private TDay AddExercisesToTrainingDay<TDay>(TDay returnDto, DAL.App.DTO.TrainingDay sourceDto)
            where TDay : TrainingDay<Guid>
        {
            var mainLifts = new List<ExerciseInTrainingDay>();
            var accessoryLifts = new List<ExerciseInTrainingDay>();
            
            if (sourceDto.ExercisesInTrainingDay != null)
                foreach (var exercise in sourceDto.ExercisesInTrainingDay)
                {
                    switch (exercise.ExerciseType?.TypeCode)
                    {
                        case ExerciseTypeTypeCodes.MainLift:
                        {
                            var mappedExercise = BLLMapperContext.ExerciseInTrainingDayMapper.MapDALToBLL(exercise);
                            mainLifts.Add(mappedExercise);
                            break;
                        }
                        case ExerciseTypeTypeCodes.Accessory:
                        {
                            var mappedExercise = BLLMapperContext.ExerciseInTrainingDayMapper.MapDALToBLL(exercise);
                            accessoryLifts.Add(mappedExercise);
                            break;
                        }
                    }
                }
            returnDto.MainLifts = mainLifts;
            returnDto.AccessoryLifts = accessoryLifts;
            return returnDto;
        }
    }
}
