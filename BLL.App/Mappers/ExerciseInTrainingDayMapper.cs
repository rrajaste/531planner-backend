using System.Collections.Generic;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using Domain.App.Enums;

namespace BLL.Mappers
{
    public class ExerciseInTrainingDayMapper : BLLBaseMapper,
        IBLLMapper<DAL.App.DTO.ExerciseInTrainingDay, ExerciseInTrainingDay>
    {
        public ExerciseInTrainingDayMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public ExerciseInTrainingDay MapDALToBLL(DAL.App.DTO.ExerciseInTrainingDay dalObject)
        {

            var exerciseInTrainingDay = new ExerciseInTrainingDay()
            {
                Id = dalObject.Id,
                ExerciseId = dalObject.ExerciseId,
                Exercise = dalObject.Exercise == null
                    ? null
                    : BLLMapperContext.ExerciseMapper.MapDALToBLL(dalObject.Exercise),
                ExerciseTypeId = dalObject.ExerciseTypeId,
                ExerciseType = dalObject.ExerciseType == null
                    ? null
                    : BLLMapperContext.ExerciseTypeMapper.MapDALToBLL(dalObject.ExerciseType),
            };
            return AddExerciseSets(exerciseInTrainingDay, dalObject);
        }

        public DAL.App.DTO.ExerciseInTrainingDay MapBLLToDAL(ExerciseInTrainingDay bllObject) =>
            new DAL.App.DTO.ExerciseInTrainingDay()
            {
                Id = bllObject.Id,
                ExerciseId = bllObject.ExerciseId,
                ExerciseTypeId = bllObject.ExerciseTypeId,
                TrainingDayId = bllObject.TrainingDayId
            };

        private ExerciseInTrainingDay AddExerciseSets(ExerciseInTrainingDay returnDto,
            DAL.App.DTO.ExerciseInTrainingDay sourceDto)
        {
            var workSets = new List<ExerciseSet>();
            var warmUpSets = new List<ExerciseSet>();

            if (sourceDto.ExerciseSets != null)
                foreach (var set in sourceDto.ExerciseSets)
                {
                    switch (set.SetType?.TypeCode)
                    {
                        case ExerciseSetTypeCodes.WorkSet:
                        {
                            var mappedExercise = BLLMapperContext.ExerciseSetMapper.MapDALToBLL(set);
                            workSets.Add(mappedExercise);
                            break;
                        }
                        case ExerciseSetTypeCodes.WarmUp:
                        {
                            var mappedExercise = BLLMapperContext.ExerciseSetMapper.MapDALToBLL(set);
                            warmUpSets.Add(mappedExercise);
                            break;
                        }
                    }
                }
            returnDto.WorkSets = workSets;
            returnDto.WarmUpSets = warmUpSets;
            return returnDto;
        }
    }
}