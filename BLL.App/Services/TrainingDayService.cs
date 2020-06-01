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
using TrainingDay = DAL.App.DTO.TrainingDay;

namespace BLL.Services
{
    public class TrainingDayService : BaseEntityService<ITrainingDayRepository, IAppUnitOfWork,
            TrainingDay, BaseTrainingDay, ITrainingDayMapper>,
        ITrainingDayService
    {
        public TrainingDayService(IAppUnitOfWork unitOfWork, ITrainingDayMapper mapper)
            : base(unitOfWork, mapper, unitOfWork.TrainingDays)
        {
        }

        public async Task<IEnumerable<BaseTrainingDay>> AllWithTrainingWeekIdAsync(Guid trainingWeekId)
        {
            return (await ServiceRepository.AllWithTrainingWeekIdAsync(trainingWeekId)).Select(Mapper.MapDALToBLL);
        }

        public Task<bool> IsPartOfBaseRoutineAsync(Guid trainingDayId)
        {
            return ServiceRepository.IsPartOfBaseRoutineAsync(trainingDayId);
        }

        public async Task<BaseTrainingDay> FindWithExerciseSetIdAsync(Guid id)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.FindWithExerciseSetIdAsync(id));
        }

        public async Task<BaseTrainingDay> FindWithExerciseInTrainingDayIdAsync(Guid id)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.FindWithExerciseInTrainingDayIdAsync(id));
        }

        public UserTrainingDay Add(UserTrainingDay dto)
        {
            return Mapper.MapDALToUserTrainingDay(ServiceRepository.Add(Mapper.MapUserTrainingDayToDALEntity(dto)));
        }

        public UserTrainingDay Update(UserTrainingDay dto)
        {
            return Mapper.MapDALToUserTrainingDay(ServiceRepository.Update(Mapper.MapUserTrainingDayToDALEntity(dto)));
        }


        public async Task<IEnumerable<DayOfWeek>> GetUnusedDaysInWeekWithIdAsync(Guid trainingWeekId)
        {
            var trainingDaysInWeek = await UnitOfWork.TrainingDays.AllWithTrainingWeekIdAsync(trainingWeekId);
            var mappedTrainingDays = trainingDaysInWeek.Select(Mapper.MapDALToBLL);
            var usedDaysOfWeek = mappedTrainingDays.Select(d => d.DayOfWeek);
            var allDaysOfWeek = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList();
            allDaysOfWeek.RemoveAll(dayOfWeek => usedDaysOfWeek.Contains(dayOfWeek));
            return allDaysOfWeek;
        }
    }
}