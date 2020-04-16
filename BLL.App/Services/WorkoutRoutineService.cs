using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Domain;

namespace BLL.Services
{
    public class WorkoutRoutineService : BaseEntityService<IWorkoutRoutineRepository, IAppUnitOfWork, WorkoutRoutine, WorkoutRoutine>, IWorkoutRoutineService 
    {
        public WorkoutRoutineService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<WorkoutRoutine, WorkoutRoutine>(), unitOfWork.WorkoutRoutines)
        {
        }
    }
}