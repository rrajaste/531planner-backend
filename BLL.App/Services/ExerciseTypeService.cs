using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class ExerciseTypeService : BaseEntityService<IExerciseTypeRepository, IAppUnitOfWork, DAL.App.DTO.ExerciseType,
        BLL.App.DTO.ExerciseType>, IExerciseTypeService 
    {
        public ExerciseTypeService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.ExerciseType, BLL.App.DTO.ExerciseType>(), unitOfWork.ExerciseTypes)
        {
        }
    }
}