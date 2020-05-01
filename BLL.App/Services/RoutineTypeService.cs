using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class RoutineTypeService : BaseEntityService<IRoutineTypeRepository, IAppUnitOfWork,
        DAL.App.DTO.RoutineType, BLL.App.DTO.RoutineType>, IRoutineTypeService 
    {
        public RoutineTypeService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.RoutineType, BLL.App.DTO.RoutineType>(), unitOfWork.RoutineTypes)
        {
        }
    }
}