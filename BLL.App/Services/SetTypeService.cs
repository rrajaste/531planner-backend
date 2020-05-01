using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class SetTypeService : BaseEntityService<ISetTypeRepository, IAppUnitOfWork,
        DAL.App.DTO.SetType, BLL.App.DTO.SetType>, ISetTypeService 
    {
        public SetTypeService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.SetType, BLL.App.DTO.SetType>(), unitOfWork.SetTypes)
        {
        }
    }
}