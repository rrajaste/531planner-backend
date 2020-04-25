using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class UnitTypeService :
        BaseEntityService<IUnitTypesRepository, IAppUnitOfWork, DAL.App.DTO.UnitType,
            BLL.App.DTO.UnitType>, IUnitTypeService 
    {
        public UnitTypeService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.UnitType,
                BLL.App.DTO.UnitType>(), unitOfWork.UnitTypes)
        {
        }
    }
}