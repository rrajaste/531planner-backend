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
using DAL.App.DTO;
using TrainingCycle = BLL.App.DTO.TrainingCycle;
using WorkoutRoutine = DAL.App.DTO.WorkoutRoutine;

namespace BLL.Services
{
    public class WorkoutRoutineService : BaseEntityService<IWorkoutRoutineRepository, IAppUnitOfWork,
            WorkoutRoutine, App.DTO.WorkoutRoutine, IBLLMapper<WorkoutRoutine, App.DTO.WorkoutRoutine>>,
        IWorkoutRoutineService
    {
        public WorkoutRoutineService(IAppUnitOfWork unitOfWork,
            IBLLMapper<WorkoutRoutine, App.DTO.WorkoutRoutine> mapper)
            : base(unitOfWork, mapper, unitOfWork.WorkoutRoutines)
        {
        }

        public async Task<App.DTO.WorkoutRoutine> ActiveRoutineForUserWithIdAsync(Guid userId)
        {
            return Mapper.MapDALToBLL(
                await ServiceRepository.ActiveRoutineForUserWithIdAsync(userId)
            );
        }

        public Task<bool> ActiveRoutineWithIdExistsForUserAsync(Guid routineId, Guid userId)
        {
            return ServiceRepository.ActiveRoutineWithIdExistsForUserAsync(routineId, userId);
        }

        public async Task<IEnumerable<App.DTO.WorkoutRoutine>> AllInactiveRoutinesForUserWithIdAsync(Guid userId)
        {
            return (
                await ServiceRepository.AllInactiveBaseRoutinesAsync()
            ).Select(Mapper.MapDALToBLL);
        }

        public async Task<IEnumerable<App.DTO.WorkoutRoutine>> AllActiveBaseRoutinesAsync()
        {
            return (
                await ServiceRepository.AllActiveBaseRoutinesAsync()
            ).Select(Mapper.MapDALToBLL);
        }

        public async Task<IEnumerable<App.DTO.WorkoutRoutine>> AllInactiveBaseRoutinesAsync()
        {
            return (
                await ServiceRepository.AllInactiveBaseRoutinesAsync()
            ).Select(Mapper.MapDALToBLL);
        }

        public async Task<IEnumerable<App.DTO.WorkoutRoutine>> AllUnPublishedBaseRoutinesAsync()
        {
            return (
                await ServiceRepository.AllUnPublishedBaseRoutinesAsync()
            ).Select(Mapper.MapDALToBLL);
        }

        public async Task<IEnumerable<App.DTO.WorkoutRoutine>> AllPublishedBaseRoutinesAsync()
        {
            return (
                await ServiceRepository.AllPublishedBaseRoutinesAsync()
            ).Select(Mapper.MapDALToBLL);
        }

        public async Task<App.DTO.WorkoutRoutine> FindBaseRoutineAsync(Guid id)
        {
            return Mapper.MapDALToBLL(
                await ServiceRepository.FindBaseRoutineAsync(id)
            );
        }

        public Task<bool> BaseRoutineWithIdExistsAsync(Guid id)
        {
            return ServiceRepository.BaseRoutineWithIdExistsAsync(id);
        }

        public async Task AddWithBaseCycleAsync(App.DTO.WorkoutRoutine dto)
        {
            await ServiceRepository.AddWithBaseCycleAsync(Mapper.MapBLLToDAL(dto));
        }

        public async Task<App.DTO.WorkoutRoutine> ChangeRoutinePublishStatus(Guid routineId, bool isPublished)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.ChangeRoutinePublishStatus(routineId, isPublished));
        }

        public async Task<App.DTO.WorkoutRoutine> FindWithWeekIdAsync(Guid weekId)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.FindWithWeekIdAsync(weekId));
        }

        public async Task<App.DTO.WorkoutRoutine> FindWithTrainingDayIdAsync(Guid trainingDayId)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.FindWithTrainingDayIdAsync(trainingDayId));
        }

        public async Task<App.DTO.WorkoutRoutine> FindFullRoutineWithIdAsync(Guid routineId)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.FindFullRoutineWithIdAsync(routineId));
        }

        public async Task<bool> UserWithIdHasActiveRoutineAsync(Guid userId)
        {
            return await ServiceRepository.UserWithIdHasActiveRoutineAsync(userId);
        }

        public App.DTO.WorkoutRoutine GenerateNewFiveThreeOneRoutine(NewFiveThreeOneRoutineInfo routineInfo)
        {
            var generator = new FiveThreeOneRoutineGenerator(routineInfo);
            var generatedRoutine = generator.GenerateNewRoutine();
            return generatedRoutine;
        }

        public TrainingCycle GenerateNewCycleForFiveThreeOneRoutine(App.DTO.WorkoutRoutine baseRoutine,
            NewFiveThreeOneCycleInfo cycleInfo)
        {
            // TODO: Fix this entire ugly workaround of a method

            var oldRoutineMaxCycleNumber = baseRoutine.TrainingCycles.Max(cycle => cycle.CycleNumber);
            var oldCycle =
                baseRoutine.TrainingCycles.FirstOrDefault(cycle => cycle.CycleNumber == oldRoutineMaxCycleNumber);
            var oldCycleEndingDate = oldCycle.EndingDate;
            if (oldCycleEndingDate == null)
                throw new ApplicationException("Cannot generate a new training cycle: old cycle's ending date is null");

            var newCycleStartingDate = ((DateTime) oldCycleEndingDate).AddDays(1);

            var routineInfo = new NewFiveThreeOneRoutineInfo
            {
                BaseRoutine = baseRoutine,
                CycleInfo = cycleInfo,
                StartingDate = newCycleStartingDate
            };

            var generator = new FiveThreeOneRoutineGenerator(routineInfo);
            var generatedCycle = generator.GenerateNewTrainingCycle(baseRoutine);
            return generatedCycle;
        }

        public void AddTranslationToWorkoutRoutine(WorkoutRoutineTranslation dto, Guid workoutRoutineId)
        {
            var routineInfo = new WorkoutRoutineInfo
            {
                CultureCode = dto.CultureCode,
                Description = dto.Description,
                Name = dto.Name,
                WorkoutRoutineId = workoutRoutineId
            };
            UnitOfWork.WorkoutRoutineInfos.Add(routineInfo);
        }

        public void UpdateTranslation(WorkoutRoutineTranslation translation, Guid routineId)
        {
            UnitOfWork.WorkoutRoutineInfos.Update(MapTranslationToRoutineInfo(translation, routineId));
        }

        public async Task<IEnumerable<WorkoutRoutineTranslation>> AllTranslationsForWorkoutRoutineWithIdAsync(
            Guid routineId)
        {
            var routineInfos = await UnitOfWork
                .WorkoutRoutineInfos
                .AllForWorkoutRoutineWithIdAsync(routineId);
            return routineInfos.Select(MapRoutineInfoToTranslation);
        }

        public void UpdateBaseRoutine(App.DTO.WorkoutRoutine routine)
        {
            ServiceRepository.UpdateBaseRoutine(Mapper.MapBLLToDAL(routine));
        }

        private static WorkoutRoutineInfo MapTranslationToRoutineInfo(WorkoutRoutineTranslation translation,
            Guid routineId)
        {
            return new WorkoutRoutineInfo
            {
                CultureCode = translation.CultureCode,
                Description = translation.Description,
                Name = translation.Name,
                Id = translation.Id,
                WorkoutRoutineId = routineId
            };
        }

        private WorkoutRoutineTranslation MapRoutineInfoToTranslation(WorkoutRoutineInfo routineInfo)
        {
            return new WorkoutRoutineTranslation
            {
                CultureCode = routineInfo.CultureCode,
                Description = routineInfo.Description,
                Name = routineInfo.Name,
                Id = routineInfo.Id
            };
        }
    }
}