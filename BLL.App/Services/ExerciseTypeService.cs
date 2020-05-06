using BLL.App.DTO;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class ExerciseTypeService : BaseEntityService<IExerciseTypeRepository, IAppUnitOfWork, DAL.App.DTO.ExerciseType,
        BLL.App.DTO.ExerciseType>, IExerciseTypeService 
    {
        public ExerciseTypeService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.ExerciseType, ExerciseType> mapper) 
            : base(unitOfWork, mapper, unitOfWork.ExerciseTypes)
        {
        }
    }
}