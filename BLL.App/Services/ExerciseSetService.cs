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

namespace BLL.Services
{
    public class ExerciseSetService : BaseEntityService<IExerciseSetRepository, IAppUnitOfWork, DAL.App.DTO.ExerciseSet,
        BLL.App.DTO.ExerciseSet, IExerciseSetMapper>, IExerciseSetService 
    {
        
        public ExerciseSetService(IAppUnitOfWork unitOfWork, IExerciseSetMapper mapper) 
            : base(unitOfWork, mapper, unitOfWork.ExerciseSets)
        {
        }

        public async Task<IEnumerable<ExerciseSet>> AllWithTrainingDayIdAsync(Guid trainingDayId) =>
            (await ServiceRepository.AllWithTrainingDayIdAsync(trainingDayId)).Select(Mapper.MapDALToBLL);

        public Task<bool> IsPartOfBaseRoutineAsync(Guid exerciseSetId) =>
            ServiceRepository.IsPartOfBaseRoutineAsync(exerciseSetId);

        public async Task<Guid> GetRoutineIdForExerciseSetAsync(ExerciseSet entity) =>
            await ServiceRepository.GetRoutineIdForExerciseSetAsync(Mapper.MapBLLToDAL(entity));

        public async Task<BaseLiftSet> AddAsync(BaseLiftSet baseSet)
        {
            var entityToAdd = await GetDALEntityWithRoutineId(baseSet);
            ServiceRepository.Add(entityToAdd);
            return Mapper.MapDALToBaseLiftSet(entityToAdd);
        }
        public async Task<BaseLiftSet> UpdateAsync(BaseLiftSet baseLiftSet)
        {
            var entityToAdd = await GetDALEntityWithRoutineId(baseLiftSet);
            ServiceRepository.Update(entityToAdd);
            return Mapper.MapDALToBaseLiftSet(entityToAdd);
        }

        public async Task<BaseLiftSet> RemoveAsync(BaseLiftSet baseLiftSet)
        {
            var entityToAdd = await GetDALEntityWithRoutineId(baseLiftSet);
            ServiceRepository.Remove(entityToAdd);
            return Mapper.MapDALToBaseLiftSet(entityToAdd);
        }

        public async Task<BaseLiftSet> FindBaseLiftSetAsync(Guid setId) =>
            Mapper.MapDALToBaseLiftSet(await ServiceRepository.FindAsync(setId));

        public void UpdateBaseExerciseSets(BaseLiftSet baseSet) =>
            ServiceRepository.Update(Mapper.MapBaseLiftSetToDALEntity(baseSet));

        public async Task<IEnumerable<BaseLiftSet>> AllBaseLiftSetsWithTrainingDayIdAsync(Guid id) =>
            (await ServiceRepository.AllWithTrainingDayIdAsync(id)).Select(Mapper.MapDALToBaseLiftSet);

        private async Task<DAL.App.DTO.ExerciseSet> GetDALEntityWithRoutineId(BaseLiftSet liftSet)
        {
            var bllEntity = Mapper.MapDALToBLL(Mapper.MapBaseLiftSetToDALEntity(liftSet));
            var routineId = await GetRoutineIdForExerciseSetAsync(bllEntity);
            bllEntity.WorkoutRoutineId = routineId;
            return Mapper.MapBLLToDAL(bllEntity);
        }
    }
}