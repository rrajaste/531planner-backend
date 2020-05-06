using BLL.App.DTO;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class SetTypeService : BaseEntityService<ISetTypeRepository, IAppUnitOfWork,
        DAL.App.DTO.SetType, BLL.App.DTO.SetType>, ISetTypeService 
    {
        public SetTypeService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.SetType, SetType> mapper) 
            : base(unitOfWork, mapper, unitOfWork.SetTypes)
        {
        }
    }
}