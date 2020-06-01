using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.Services
{
    public class MuscleGroupService :
        BaseEntityService<IMuscleGroupRepository, IAppUnitOfWork, MuscleGroup,
            App.DTO.MuscleGroup, IBLLMapper<MuscleGroup,
                App.DTO.MuscleGroup>>, IMuscleGroupService
    {
        public MuscleGroupService(IAppUnitOfWork unitOfWork, IBLLMapper<MuscleGroup, App.DTO.MuscleGroup> mapper)
            : base(unitOfWork, mapper, unitOfWork.MuscleGroups)
        {
        }
    }
}