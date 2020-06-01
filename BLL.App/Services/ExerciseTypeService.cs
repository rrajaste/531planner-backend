using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.Services
{
    public class ExerciseTypeService : BaseEntityService<IExerciseTypeRepository, IAppUnitOfWork, ExerciseType,
        App.DTO.ExerciseType, IBLLMapper<ExerciseType,
            App.DTO.ExerciseType>>, IExerciseTypeService
    {
        public ExerciseTypeService(IAppUnitOfWork unitOfWork, IBLLMapper<ExerciseType, App.DTO.ExerciseType> mapper)
            : base(unitOfWork, mapper, unitOfWork.ExerciseTypes)
        {
        }
    }
}