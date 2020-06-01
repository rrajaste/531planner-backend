using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ExerciseSet = DAL.App.DTO.ExerciseSet;

namespace BLL.Services
{
    public class ExerciseSetService : BaseEntityService<IExerciseSetRepository, IAppUnitOfWork, ExerciseSet,
        App.DTO.ExerciseSet, IExerciseSetMapper>, IExerciseSetService
    {
        public ExerciseSetService(IAppUnitOfWork unitOfWork, IExerciseSetMapper mapper)
            : base(unitOfWork, mapper, unitOfWork.ExerciseSets)
        {
        }

        public async Task<IEnumerable<App.DTO.ExerciseSet>> AllWithExerciseInTrainingDayIdAsync(
            Guid exerciseInTrainingDayId)
        {
            return (await ServiceRepository.AllWithExerciseInTrainingDayIdAsync(exerciseInTrainingDayId)).Select(
                Mapper.MapDALToBLL);
        }

        public Task<bool> IsPartOfBaseRoutineAsync(Guid exerciseSetId)
        {
            return ServiceRepository.IsPartOfBaseRoutineAsync(exerciseSetId);
        }

        public async Task<Guid> GetRoutineIdForExerciseSetAsync(Guid exerciseInTrainingDayId)
        {
            return await ServiceRepository.GetRoutineIdForExerciseSetAsync(exerciseInTrainingDayId);
        }

        public async Task<BaseLiftSet> AddBaseLiftSetAsync(BaseLiftSet baseSet)
        {
            var entityToAdd = Mapper.MapBaseLiftSetToDALEntity(baseSet);
            var routineId =
                await ServiceRepository.GetRoutineIdForExerciseSetAsync(entityToAdd.ExerciseInTrainingDayId);
            entityToAdd.WorkoutRoutineId = routineId;
            entityToAdd.SetNumber = await GetSetNumber(baseSet);
            ServiceRepository.Add(entityToAdd);
            return Mapper.MapDALToBaseLiftSet(entityToAdd);
        }

        public async Task<BaseLiftSet> UpdateAsync(BaseLiftSet baseLiftSet)
        {
            var entityToAdd = await GetDALEntityWithRoutineId(baseLiftSet);
            var setNumber = (await UnitOfWork.ExerciseSets.FindAsync(entityToAdd.Id)).SetNumber;
            entityToAdd.SetNumber = setNumber;
            entityToAdd.WorkoutRoutineId = await GetRoutineIdForExerciseSetAsync(baseLiftSet.ExerciseInTrainingDayId);
            ServiceRepository.Update(entityToAdd);
            return Mapper.MapDALToBaseLiftSet(entityToAdd);
        }

        public async Task<BaseLiftSet> RemoveAsync(BaseLiftSet baseLiftSet)
        {
            var entityToAdd = await GetDALEntityWithRoutineId(baseLiftSet);
            ServiceRepository.Remove(entityToAdd);
            return Mapper.MapDALToBaseLiftSet(entityToAdd);
        }

        public async Task<BaseLiftSet> FindBaseLiftSetAsync(Guid setId)
        {
            return Mapper.MapDALToBaseLiftSet(await ServiceRepository.FindAsync(setId));
        }

        public async Task<IEnumerable<BaseLiftSet>> AllBaseLiftSetsWithTrainingDayIdAsync(Guid id)
        {
            return (await ServiceRepository.AllWithExerciseInTrainingDayIdAsync(id)).Select(Mapper.MapDALToBaseLiftSet);
        }

        public async Task NormalizeSetNumbersAsync(Guid exerciseInTrainingDayId)
        {
            var exerciseSets =
                await UnitOfWork.ExerciseSets.AllWithExerciseInTrainingDayIdAsync(exerciseInTrainingDayId);
            var exerciseSetsList = exerciseSets.ToList();
            for (var i = 1; i <= exerciseSetsList.Count(); i++)
            {
                var exerciseSet = exerciseSetsList[i - 1];
                exerciseSet.SetNumber = i;
                ServiceRepository.Update(exerciseSet);
            }
        }

        private async Task<ExerciseSet> GetDALEntityWithRoutineId(BaseLiftSet liftSet)
        {
            var bllEntity = Mapper.MapDALToBLL(Mapper.MapBaseLiftSetToDALEntity(liftSet));
            var routineId = await GetRoutineIdForExerciseSetAsync(bllEntity.ExerciseInTrainingDayId);
            bllEntity.WorkoutRoutineId = routineId;
            return Mapper.MapBLLToDAL(bllEntity);
        }

        private async Task<int> GetSetNumber(BaseLiftSet liftSet)
        {
            var exerciseSets =
                await UnitOfWork.ExerciseSets.AllWithExerciseInTrainingDayIdAsync(liftSet.ExerciseInTrainingDayId);
            var setNumber = 1;
            if (exerciseSets != null && exerciseSets.Any()) setNumber += exerciseSets.Max(set => set.SetNumber);
            return setNumber;
        }
    }
}