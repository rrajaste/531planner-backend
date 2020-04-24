using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF;
using Domain;

namespace BLL.Services
{
    public class ExerciseService : BaseEntityService<IExerciseRepository, IAppUnitOfWork, DAL.App.DTO.Exercise,
        BLL.App.DTO.Exercise>, IExerciseService 
    {
        public ExerciseService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Exercise, BLL.App.DTO.Exercise>(), unitOfWork.Exercises)
        {
        }
    }
}