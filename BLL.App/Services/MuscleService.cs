using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class MuscleService :
        BaseEntityService<IMuscleRepository, IAppUnitOfWork, DAL.App.DTO.Muscle,
            BLL.App.DTO.Muscle>, IMuscleService 
    {
        public MuscleService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Muscle,
                BLL.App.DTO.Muscle>(), unitOfWork.Muscles)
        {
        }
    }
}