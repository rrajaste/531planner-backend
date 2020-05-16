using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.DTO.Enums;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using TrainingDay = BLL.App.DTO.TrainingDay;

namespace BLL.Services
{
    public class TrainingDayService : BaseEntityService<ITrainingDayRepository, IAppUnitOfWork,
            DAL.App.DTO.TrainingDay, BLL.App.DTO.TrainingDay, ITrainingDayMapper>,
        ITrainingDayService
    {
        public TrainingDayService(IAppUnitOfWork unitOfWork, ITrainingDayMapper mapper)
            : base(unitOfWork, mapper, unitOfWork.TrainingDays)
        {
        }

        public async Task<IEnumerable<TrainingDay>> AllWithTrainingWeekIdAsync(Guid trainingWeekId) =>
            (await ServiceRepository.AllWithTrainingWeekIdAsync(trainingWeekId)).Select(Mapper.MapDALToBLL);

        public Task<bool> IsPartOfBaseRoutineAsync(Guid trainingDayId) =>
            ServiceRepository.IsPartOfBaseRoutineAsync(trainingDayId);

        public BaseTrainingDay Add(BaseTrainingDay dto) => 
            Mapper.MapDALToBaseTrainingDay(ServiceRepository.Add(Mapper.MapBaseTrainingDayToDALEntity(dto)));

        public async Task<BaseTrainingDay> FindBaseTrainingDay(Guid id) =>
            Mapper.MapDALToBaseTrainingDay(await ServiceRepository.FindAsync(id));
    }
}