using BLL.App.DTO;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class MuscleGroupService :
        BaseEntityService<IMuscleGroupRepository, IAppUnitOfWork, DAL.App.DTO.MuscleGroup,
            BLL.App.DTO.MuscleGroup, IBLLMapper<DAL.App.DTO.MuscleGroup,
                BLL.App.DTO.MuscleGroup>>, IMuscleGroupService 
    {
        public MuscleGroupService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.MuscleGroup, MuscleGroup> mapper) 
            : base(unitOfWork, mapper, unitOfWork.MuscleGroups)
        {
        }
    }
}