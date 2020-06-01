using System.Collections.Generic;
using System.Linq;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;
using Domain.App.Constants;
using ExerciseSet = BLL.App.DTO.ExerciseSet;

namespace BLL.Mappers
{
    public class ExerciseInTrainingDayMapper : BLLBaseMapper,
        IBLLMapper<ExerciseInTrainingDay, App.DTO.ExerciseInTrainingDay>
    {
        public ExerciseInTrainingDayMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.ExerciseInTrainingDay MapDALToBLL(ExerciseInTrainingDay dalObject)
        {
            var exerciseInTrainingDay = new App.DTO.ExerciseInTrainingDay
            {
                Id = dalObject.Id,
                ExerciseId = dalObject.ExerciseId,
                TrainingDayId = dalObject.TrainingDayId,
                Exercise = dalObject.Exercise == null
                    ? null
                    : BLLMapperContext.ExerciseMapper.MapDALToBLL(dalObject.Exercise),
                ExerciseTypeId = dalObject.ExerciseTypeId,
                ExerciseType = dalObject.ExerciseType == null
                    ? null
                    : BLLMapperContext.ExerciseTypeMapper.MapDALToBLL(dalObject.ExerciseType)
            };
            return AddExerciseSets(exerciseInTrainingDay, dalObject);
        }

        public ExerciseInTrainingDay MapBLLToDAL(App.DTO.ExerciseInTrainingDay bllObject)
        {
            return new ExerciseInTrainingDay
            {
                Id = bllObject.Id,
                ExerciseId = bllObject.ExerciseId,
                ExerciseTypeId = bllObject.ExerciseTypeId,
                TrainingDayId = bllObject.TrainingDayId,
                ExerciseSets = bllObject.WarmUpSets?
                    .Select(BLLMapperContext.ExerciseSetMapper.MapBLLToDAL)
                    .Concat(bllObject.WorkSets?
                        .Select(BLLMapperContext.ExerciseSetMapper.MapBLLToDAL))
            };
        }

        private App.DTO.ExerciseInTrainingDay AddExerciseSets(App.DTO.ExerciseInTrainingDay returnDto,
            ExerciseInTrainingDay sourceDto)
        {
            var workSets = new List<ExerciseSet>();
            var warmUpSets = new List<ExerciseSet>();

            if (sourceDto.ExerciseSets != null)
                foreach (var set in sourceDto.ExerciseSets)
                    switch (set.SetType?.TypeCode)
                    {
                        case ExerciseSetTypeCodes.WorkSet:
                        {
                            var mappedSet = BLLMapperContext.ExerciseSetMapper.MapDALToBLL(set);
                            workSets.Add(mappedSet);
                            break;
                        }
                        case ExerciseSetTypeCodes.WarmUp:
                        {
                            var mappedSet = BLLMapperContext.ExerciseSetMapper.MapDALToBLL(set);
                            warmUpSets.Add(mappedSet);
                            break;
                        }
                    }

            returnDto.WorkSets = workSets;
            returnDto.WarmUpSets = warmUpSets;
            return returnDto;
        }
    }
}