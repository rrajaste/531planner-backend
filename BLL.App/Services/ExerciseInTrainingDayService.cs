
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
    }
}