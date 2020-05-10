using System;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;

namespace BLL.Mappers
{
    public class ExerciseSetMapper : BLLBaseMapper, IExerciseSetMapper
    {
        public ExerciseSetMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public ExerciseSet MapDALToBLL(DAL.App.DTO.ExerciseSet dalObject) =>
            new ExerciseSet()
            {
                Id = dalObject.Id,
                Completed = dalObject.Completed,
                Distance = dalObject.Distance,
                Duration = dalObject.Duration,
                ExerciseId = dalObject.ExerciseId,
                Exercise = dalObject.Exercise == null 
                    ? null 
                    : BLLMapperContext.ExerciseMapper.MapDALToBLL(dalObject.Exercise),
                NrOfReps = dalObject.NrOfReps,
                SetNumber = dalObject.SetNumber,
                TrainingDay = dalObject.TrainingDay == null 
                ? null 
                : BLLMapperContext.TrainingDayMapper.MapDALToBLL(dalObject.TrainingDay),
                TrainingDayId = dalObject.TrainingDayId,
                SetTypeId = dalObject.SetTypeId,
                SetType = dalObject.SetType == null 
                    ? null 
                    : BLLMapperContext.SetTypeMapper.MapDALToBLL(dalObject.SetType)  
            };
        
        public DAL.App.DTO.ExerciseSet MapBLLToDAL(ExerciseSet bllObject) =>
            new DAL.App.DTO.ExerciseSet()
            {
                Id = bllObject.Id,
                Completed = bllObject.Completed,
                Distance = bllObject.Distance,
                Duration = bllObject.Duration,
                ExerciseId = bllObject.ExerciseId,
                NrOfReps = bllObject.NrOfReps,
                SetNumber = bllObject.SetNumber,
                TrainingDayId = bllObject.TrainingDayId,
                SetTypeId = bllObject.SetTypeId,
                Weight = bllObject.Weight
            };

        public BaseLiftSet MapDALToBaseLiftSet(DAL.App.DTO.ExerciseSet dalEntity)
        {
            if (dalEntity.NrOfReps == null)
            {
                throw new ApplicationException("Number of reps cannot be null on a lift set");
            }
            if (dalEntity.Weight == null)
            {
                throw new ApplicationException("Weight percentage cannot be null on a lift set");
            }
            var baseLiftSet = new BaseLiftSet()
            {
                Id = dalEntity.Id,
                ExerciseId = dalEntity.ExerciseId,
                Exercise = dalEntity.Exercise == null 
                    ? null 
                    : BLLMapperContext.ExerciseMapper.MapDALToBLL(dalEntity.Exercise),
                SetNumber = dalEntity.SetNumber,
                TrainingDay = dalEntity.TrainingDay == null 
                    ? null 
                    : BLLMapperContext.TrainingDayMapper.MapDALToBLL(dalEntity.TrainingDay),
                TrainingDayId = dalEntity.TrainingDayId,
                SetTypeId = dalEntity.SetTypeId,
                SetType = dalEntity.SetType == null 
                    ? null 
                    : BLLMapperContext.SetTypeMapper.MapDALToBLL(dalEntity.SetType),
                NrOfReps = (int) dalEntity.NrOfReps,
                WeightPercentageOfOneRepMax = (float) dalEntity.Weight
            };
            return baseLiftSet;
        }
        
        public DAL.App.DTO.ExerciseSet MapBaseLiftSetToDALEntity(BaseLiftSet baseLiftSet) => 
            new DAL.App.DTO.ExerciseSet()
            {
                Id = baseLiftSet.Id,
                ExerciseId = baseLiftSet.ExerciseId,
                NrOfReps = baseLiftSet.NrOfReps,
                SetNumber = baseLiftSet.SetNumber,
                TrainingDayId = baseLiftSet.TrainingDayId,
                SetTypeId = baseLiftSet.SetTypeId,
                Weight = baseLiftSet.WeightPercentageOfOneRepMax
            };

        public UserLiftSet MapDALToUserLiftSet(DAL.App.DTO.ExerciseSet dalEntity)
        {
            if (dalEntity.NrOfReps == null)
            {
                throw new ApplicationException("Number of reps cannot be null on a lift set");
            }
            if (dalEntity.Weight == null)
            {
                throw new ApplicationException("Weight cannot be null on a lift set");
            }
            
            var baseLiftSet = new UserLiftSet()
            {
                Id = dalEntity.Id,
                ExerciseId = dalEntity.ExerciseId,
                Exercise = dalEntity.Exercise == null 
                    ? null 
                    : BLLMapperContext.ExerciseMapper.MapDALToBLL(dalEntity.Exercise),
                SetNumber = dalEntity.SetNumber,
                TrainingDay = dalEntity.TrainingDay == null 
                    ? null 
                    : BLLMapperContext.TrainingDayMapper.MapDALToBLL(dalEntity.TrainingDay),
                TrainingDayId = dalEntity.TrainingDayId,
                SetTypeId = dalEntity.SetTypeId,
                SetType = dalEntity.SetType == null 
                    ? null 
                    : BLLMapperContext.SetTypeMapper.MapDALToBLL(dalEntity.SetType),
                NrOfReps = (int) dalEntity.NrOfReps,
                Weight = (float) dalEntity.Weight
            };
            return baseLiftSet;
        }

        public DAL.App.DTO.ExerciseSet MapUserLiftSetToDALEntity(UserLiftSet userLiftSet) =>
            new DAL.App.DTO.ExerciseSet()
            {
                Id = userLiftSet.Id,
                ExerciseId = userLiftSet.ExerciseId,
                NrOfReps = userLiftSet.NrOfReps,
                SetNumber = userLiftSet.SetNumber,
                TrainingDayId = userLiftSet.TrainingDayId,
                SetTypeId = userLiftSet.SetTypeId,
                Weight = userLiftSet.Weight
            };
    }
}

