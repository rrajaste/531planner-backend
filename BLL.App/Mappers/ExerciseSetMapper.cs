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
                ExerciseInTrainingDayId = dalObject.ExerciseInTrainingDayId,
                WorkoutRoutineId = dalObject.WorkoutRoutineId,
                Completed = dalObject.Completed,
                Weight = dalObject.Weight,
                Distance = dalObject.Distance,
                Duration = dalObject.Duration,
                NrOfReps = dalObject.NrOfReps,
                SetNumber = dalObject.SetNumber,
                SetTypeId = dalObject.SetTypeId,
                SetType = dalObject.SetType == null 
                    ? null 
                    : BLLMapperContext.SetTypeMapper.MapDALToBLL(dalObject.SetType)  
            };
        
        public DAL.App.DTO.ExerciseSet MapBLLToDAL(ExerciseSet bllObject) =>
            new DAL.App.DTO.ExerciseSet()
            {
                Id = bllObject.Id,
                ExerciseInTrainingDayId = bllObject.ExerciseInTrainingDayId,
                WorkoutRoutineId = bllObject.WorkoutRoutineId,
                Completed = bllObject.Completed,
                Distance = bllObject.Distance,
                Duration = bllObject.Duration,
                NrOfReps = bllObject.NrOfReps,
                SetNumber = bllObject.SetNumber,
                SetTypeId = bllObject.SetTypeId,
                Weight = bllObject.Weight
            };

        public BaseLiftSet MapDALToBaseLiftSet(DAL.App.DTO.ExerciseSet dalEntity)
        {
            if (dalEntity.NrOfReps == null)
            {
                throw new ApplicationException("Number of reps cannot be null on a base lift set");
            }
            if (dalEntity.Weight == null)
            {
                throw new ApplicationException("Weight percentage cannot be null on a base lift set");
            }
            var baseLiftSet = new BaseLiftSet()
            {
                Id = dalEntity.Id,
                ExerciseInTrainingDayId = dalEntity.ExerciseInTrainingDayId,
                SetNumber = dalEntity.SetNumber,
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
                ExerciseInTrainingDayId = baseLiftSet.ExerciseInTrainingDayId,
                NrOfReps = baseLiftSet.NrOfReps,
                SetNumber = baseLiftSet.SetNumber,
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
                
                SetNumber = dalEntity.SetNumber,
                ExerciseInTrainingDayId = dalEntity.ExerciseInTrainingDayId,
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
                NrOfReps = userLiftSet.NrOfReps,
                SetNumber = userLiftSet.SetNumber,
                ExerciseInTrainingDayId = userLiftSet.ExerciseInTrainingDayId,
                SetTypeId = userLiftSet.SetTypeId,
                Weight = userLiftSet.Weight
            };
    }
}

