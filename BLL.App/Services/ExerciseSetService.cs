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

        public async Task<ExerciseSet> AddBaseSetAsync(ExerciseSet dto) =>
            Mapper.MapDALToBLL(await ServiceRepository.AddBaseSetAsync(Mapper.MapBLLToDAL(dto)));

        public async Task<BaseLiftSet> AddBaseLiftSetAsync(BaseLiftSet baseSet) =>
            Mapper.MapDALToBaseLiftSet(
                await ServiceRepository.AddBaseSetAsync(Mapper.MapBaseLiftSetToDALEntity(baseSet)));

        public async Task<BaseLiftSet> FindBaseLiftSetAsync(Guid setId) =>
            Mapper.MapDALToBaseLiftSet(await ServiceRepository.FindAsync(setId));

        public void UpdateBaseExerciseSets(BaseLiftSet baseSet) =>
            ServiceRepository.Update(Mapper.MapBaseLiftSetToDALEntity(baseSet));
    }
}