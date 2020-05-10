using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using BLL.App.DTO;

namespace BLL.Services
{
    public class ExerciseService : BaseEntityService<IExerciseRepository, IAppUnitOfWork, DAL.App.DTO.Exercise,
        BLL.App.DTO.Exercise, IBLLMapper<DAL.App.DTO.Exercise, BLL.App.DTO.Exercise>>, IExerciseService 
    {
        public ExerciseService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.Exercise, Exercise> mapper) 
            : base(unitOfWork, mapper, unitOfWork.Exercises)
        {
        }
    }
}