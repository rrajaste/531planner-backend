using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.Services
{
    public class MuscleService :
        BaseEntityService<IMuscleRepository, IAppUnitOfWork, Muscle,
            App.DTO.Muscle, IBLLMapper<Muscle,
                App.DTO.Muscle>>, IMuscleService
    {
        public MuscleService(IAppUnitOfWork unitOfWork, IBLLMapper<Muscle, App.DTO.Muscle> mapper)
            : base(unitOfWork, mapper, unitOfWork.Muscles)
        {
        }
    }
}