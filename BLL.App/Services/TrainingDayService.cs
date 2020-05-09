using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using TrainingDay = BLL.App.DTO.TrainingDay;

namespace BLL.Services
{
    public class TrainingDayService : BaseEntityService<ITrainingDayRepository, IAppUnitOfWork,
        DAL.App.DTO.TrainingDay, BLL.App.DTO.TrainingDay>, ITrainingDayService 
    {
        public TrainingDayService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.TrainingDay, TrainingDay> mapper) 
            : base(unitOfWork, mapper, unitOfWork.TrainingDays)
        {
        }

        public async Task<IEnumerable<TrainingDay>> AllWithTrainingWeekIdAsync(Guid trainingWeekId) =>
            (await ServiceRepository.AllWithTrainingWeekIdAsync(trainingWeekId)).Select(Mapper.MapDALToBLL);

        public Task<bool> IsPartOfBaseRoutineAsync(Guid trainingDayId) =>
            ServiceRepository.IsPartOfBaseRoutineAsync(trainingDayId);
    }
}