using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Services;
using BLL.RoutineGenerators;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using WorkoutRoutine = BLL.App.DTO.WorkoutRoutine;

namespace BLL.Services
{
    public class WorkoutRoutineService : BaseEntityService<IWorkoutRoutineRepository, IAppUnitOfWork,
            DAL.App.DTO.WorkoutRoutine, WorkoutRoutine, IBLLMapper<DAL.App.DTO.WorkoutRoutine, WorkoutRoutine>>,
        IWorkoutRoutineService
    {
        public WorkoutRoutineService(IAppUnitOfWork unitOfWork,
            IBLLMapper<DAL.App.DTO.WorkoutRoutine, WorkoutRoutine> mapper)
            : base(unitOfWork, mapper, unitOfWork.WorkoutRoutines)
        {
        }

        public async Task<WorkoutRoutine> ActiveRoutineForUserWithIdAsync(Guid userId) =>
            Mapper.MapDALToBLL(
                await ServiceRepository.ActiveRoutineForUserWithIdAsync(userId)
            );

        public Task<bool> ActiveRoutineWithIdExistsForUserAsync(Guid routineId, Guid userId) =>
            ServiceRepository.ActiveRoutineWithIdExistsForUserAsync(routineId, userId);

        public async Task<IEnumerable<WorkoutRoutine>> AllInactiveRoutinesForUserWithIdAsync(Guid userId) => (
            await ServiceRepository.AllInactiveBaseRoutinesAsync()
        ).Select(Mapper.MapDALToBLL);

        public async Task<IEnumerable<WorkoutRoutine>> AllActiveBaseRoutinesAsync() => (
            await ServiceRepository.AllActiveBaseRoutinesAsync()
        ).Select(Mapper.MapDALToBLL);

        public async Task<IEnumerable<WorkoutRoutine>> AllInactiveBaseRoutinesAsync() => (
            await ServiceRepository.AllInactiveBaseRoutinesAsync()
        ).Select(Mapper.MapDALToBLL);

        public async Task<IEnumerable<WorkoutRoutine>> AllUnPublishedBaseRoutinesAsync() => (
            await ServiceRepository.AllUnPublishedBaseRoutinesAsync()
        ).Select(Mapper.MapDALToBLL);

        public async Task<IEnumerable<WorkoutRoutine>> AllPublishedBaseRoutinesAsync() => (
            await ServiceRepository.AllPublishedBaseRoutinesAsync()
        ).Select(Mapper.MapDALToBLL);

        public async Task<WorkoutRoutine> FindBaseRoutineAsync(Guid id) =>
            Mapper.MapDALToBLL(
                await ServiceRepository.FindBaseRoutineAsync(id)
            );

        public Task<bool> BaseRoutineWithIdExistsAsync(Guid id) =>
            ServiceRepository.BaseRoutineWithIdExistsAsync(id);

        public async Task<WorkoutRoutine> AddWithBaseCycleAsync(WorkoutRoutine dto) =>
            Mapper.MapDALToBLL(await ServiceRepository.AddWithBaseCycleAsync(Mapper.MapBLLToDAL(dto)));

        public async Task<WorkoutRoutine> ChangeRoutinePublishStatus(Guid routineId, bool isPublished) =>
            Mapper.MapDALToBLL(await ServiceRepository.ChangeRoutinePublishStatus(routineId, isPublished));

        public async Task<WorkoutRoutine> FindWithWeekIdAsync(Guid weekId) =>
            Mapper.MapDALToBLL(await ServiceRepository.FindWithWeekIdAsync(weekId));

        public async Task<WorkoutRoutine> FindWithTrainingDayIdAsync(Guid trainingDayId) =>
            Mapper.MapDALToBLL(await ServiceRepository.FindWithTrainingDayIdAsync(trainingDayId));

        public async Task<WorkoutRoutine> FindFullRoutineWithIdAsync(Guid routineId) =>
            Mapper.MapDALToBLL(await ServiceRepository.FindFullRoutineWithIdAsync(routineId));

        public WorkoutRoutine GenerateNewFiveThreeOneRoutine(NewFiveThreeOneRoutineInfo routineInfo)
        {
            var generator = new FiveThreeOneRoutineGenerator(routineInfo);
            var generatedRoutine = generator.GenerateNewRoutine();
            return generatedRoutine;
        }

        public async Task<TrainingCycle> GenerateNewCycleForFiveThreeOneRoutine(WorkoutRoutine baseRoutine, NewFiveThreeOneCycleInfo cycleInfo)
        {
            var oldRoutineMaxCycleNumber = baseRoutine.TrainingCycles.Max(cycle => cycle.CycleNumber);
            var oldCycle = baseRoutine.TrainingCycles.FirstOrDefault(cycle => cycle.CycleNumber == oldRoutineMaxCycleNumber);
            var oldCycleEndingDate = oldCycle.EndingDate;
            if (oldCycleEndingDate == null)
            {
                throw new ApplicationException("Cannot generate a new training cycle: old cycle's ending date is null");
            }

            var newCycleStartingDate = ((DateTime) oldCycleEndingDate).AddDays(1);

            var routineInfo = new NewFiveThreeOneRoutineInfo()
            {
                BaseRoutine = baseRoutine,
                CycleInfo = cycleInfo,
                StartingDate = newCycleStartingDate
            };

            var generator = new FiveThreeOneRoutineGenerator(routineInfo);
            var generatedRoutine = generator.GenerateNewRoutine();
            var generatedCycle = generatedRoutine.TrainingCycles.FirstOrDefault();
            generatedCycle.CycleNumber = oldCycle.CycleNumber++;
            return generatedCycle;
        }
    }
}