using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using BLL.App.DTO;

namespace BLL.Services
{
    public class UnitTypeService :
        BaseEntityService<IUnitTypesRepository, IAppUnitOfWork, DAL.App.DTO.UnitType,
            BLL.App.DTO.UnitType, IBLLMapper<DAL.App.DTO.UnitType,
                BLL.App.DTO.UnitType>>, IUnitTypeService
    {
        public UnitTypeService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.UnitType, UnitType> mapper) 
            : base(unitOfWork, mapper, unitOfWork.UnitTypes)
        {
        }
    }
}