
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using BLL.App.DTO;

namespace BLL.Services
{
    public class ExerciseInTrainingDayService : BaseEntityService<IExerciseInTrainingDayRepository, IAppUnitOfWork, DAL.App.DTO.ExerciseInTrainingDay,
        BLL.App.DTO.ExerciseInTrainingDay, IBLLMapper<DAL.App.DTO.ExerciseInTrainingDay, BLL.App.DTO.ExerciseInTrainingDay>>, IExerciseInTrainingDayService 
    {
        public ExerciseInTrainingDayService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.ExerciseInTrainingDay, ExerciseInTrainingDay> mapper) 
            : base(unitOfWork, mapper, unitOfWork.ExercisesInTrainingDay)
        {
        }

        public async Task<IEnumerable<ExerciseInTrainingDay>> AllWithBaseTrainingDayIdAsync(Guid trainingDayId) =>
            (await ServiceRepository.AllWithBaseTrainingDayIdAsync(trainingDayId)).Select(Mapper.MapDALToBLL);

        public async Task<bool> IsPartOfBaseRoutineAsync(Guid id) => 
            await ServiceRepository.IsPartOfBaseRoutineAsync(id);
    }
}