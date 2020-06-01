using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.Services
{
    public class ExerciseService : BaseEntityService<IExerciseRepository, IAppUnitOfWork, Exercise,
        App.DTO.Exercise, IBLLMapper<Exercise, App.DTO.Exercise>>, IExerciseService
    {
        public ExerciseService(IAppUnitOfWork unitOfWork, IBLLMapper<Exercise, App.DTO.Exercise> mapper)
            : base(unitOfWork, mapper, unitOfWork.Exercises)
        {
        }
    }
}