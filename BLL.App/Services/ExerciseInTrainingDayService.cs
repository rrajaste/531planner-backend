using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.Services
{
    public class ExerciseInTrainingDayService : BaseEntityService<IExerciseInTrainingDayRepository, IAppUnitOfWork,
            ExerciseInTrainingDay,
            App.DTO.ExerciseInTrainingDay, IBLLMapper<ExerciseInTrainingDay, App.DTO.ExerciseInTrainingDay>>,
        IExerciseInTrainingDayService
    {
        public ExerciseInTrainingDayService(IAppUnitOfWork unitOfWork,
            IBLLMapper<ExerciseInTrainingDay, App.DTO.ExerciseInTrainingDay> mapper)
            : base(unitOfWork, mapper, unitOfWork.ExercisesInTrainingDay)
        {
        }

        public async Task<IEnumerable<App.DTO.ExerciseInTrainingDay>> AllWithBaseTrainingDayIdAsync(Guid trainingDayId)
        {
            return (await ServiceRepository.AllWithBaseTrainingDayIdAsync(trainingDayId)).Select(Mapper.MapDALToBLL);
        }

        public async Task<bool> IsPartOfBaseRoutineAsync(Guid id)
        {
            return await ServiceRepository.IsPartOfBaseRoutineAsync(id);
        }
    }
}