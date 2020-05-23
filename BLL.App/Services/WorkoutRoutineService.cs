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

        public WorkoutRoutine GenerateNewFiveThreeOneRoutine(NewFiveThreeOneRoutineInfo info)
        {
            var generator = new FiveThreeOneRoutineGenerator(info);
            var generatedRoutine = generator.GenerateNewRoutine();
            return generatedRoutine;
        }
    }
}