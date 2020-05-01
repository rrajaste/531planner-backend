using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using WorkoutRoutine = BLL.App.DTO.WorkoutRoutine;

namespace BLL.Services
{
    public class WorkoutRoutineService : BaseEntityService<IWorkoutRoutineRepository, IAppUnitOfWork, 
        DAL.App.DTO.WorkoutRoutine, BLL.App.DTO.WorkoutRoutine>, IWorkoutRoutineService 
    {
        public WorkoutRoutineService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.WorkoutRoutine, BLL.App.DTO.WorkoutRoutine>(), 
                unitOfWork.WorkoutRoutines)
        {
        }

        public async Task<WorkoutRoutine> ActiveRoutineForUserWithIdAsync(Guid userId) =>
            Mapper.Map<DAL.App.DTO.WorkoutRoutine, BLL.App.DTO.WorkoutRoutine>(
                await ServiceRepository.ActiveRoutineForUserWithIdAsync(userId)
            );
        public async Task<IEnumerable<WorkoutRoutine>> AllInactiveRoutinesForUserWithIdAsync(Guid userId) => (
                await ServiceRepository.AllInactiveBaseRoutinesAsync()
            ).Select(Mapper.Map<DAL.App.DTO.WorkoutRoutine, BLL.App.DTO.WorkoutRoutine>);
        public async Task<IEnumerable<WorkoutRoutine>> AllActiveBaseRoutinesAsync() => (
                await ServiceRepository.AllActiveBaseRoutinesAsync()
            ).Select(Mapper.Map<DAL.App.DTO.WorkoutRoutine, BLL.App.DTO.WorkoutRoutine>);
        
        public async Task<IEnumerable<WorkoutRoutine>> AllInactiveBaseRoutinesAsync() => (
                await ServiceRepository.AllInactiveBaseRoutinesAsync()
            ).Select(Mapper.Map<DAL.App.DTO.WorkoutRoutine, BLL.App.DTO.WorkoutRoutine>);

        public async Task<IEnumerable<WorkoutRoutine>> AllUnPublishedBaseRoutinesAsync() => (
                await ServiceRepository.AllUnPublishedBaseRoutinesAsync()
            ).Select(Mapper.Map<DAL.App.DTO.WorkoutRoutine, BLL.App.DTO.WorkoutRoutine>);

        public async Task<WorkoutRoutine> FindBaseRoutineAsync(Guid id) =>
            Mapper.Map<DAL.App.DTO.WorkoutRoutine, BLL.App.DTO.WorkoutRoutine>(
                await ServiceRepository.FindBaseRoutineAsync(id)
            );
    }
}