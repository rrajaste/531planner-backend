using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF;
using Domain;

namespace BLL.Services
{
    public class ExerciseService : BaseEntityService<IExerciseRepository, IAppUnitOfWork, Exercise, Exercise>, IExerciseService 
    {
        public ExerciseService(AppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<Exercise, Exercise>(), unitOfWork.Exercises)
        {
        }
    }
}