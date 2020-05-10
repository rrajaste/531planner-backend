using BLL.App.DTO;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class MuscleService :
        BaseEntityService<IMuscleRepository, IAppUnitOfWork, DAL.App.DTO.Muscle,
            BLL.App.DTO.Muscle, IBLLMapper<DAL.App.DTO.Muscle,
                BLL.App.DTO.Muscle>>, IMuscleService 
    {
        public MuscleService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.Muscle, Muscle> mapper) 
            : base(unitOfWork, mapper, unitOfWork.Muscles)
        {
        }
    }
}