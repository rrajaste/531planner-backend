using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class MuscleGroupService :
        BaseEntityService<IMuscleGroupRepository, IAppUnitOfWork, DAL.App.DTO.MuscleGroup,
            BLL.App.DTO.MuscleGroup>, IMuscleGroupService 
    {
        public MuscleGroupService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.MuscleGroup,
                BLL.App.DTO.MuscleGroup>(), unitOfWork.MuscleGroups)
        {
        }
    }
}