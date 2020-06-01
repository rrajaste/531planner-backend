using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.Services
{
    public class SetTypeService : BaseEntityService<ISetTypeRepository, IAppUnitOfWork,
        SetType, App.DTO.SetType, IBLLMapper<SetType, App.DTO.SetType>>, ISetTypeService
    {
        public SetTypeService(IAppUnitOfWork unitOfWork, IBLLMapper<SetType, App.DTO.SetType> mapper)
            : base(unitOfWork, mapper, unitOfWork.SetTypes)
        {
        }
    }
}