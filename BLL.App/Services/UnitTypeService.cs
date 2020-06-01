using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.Services
{
    public class UnitTypeService :
        BaseEntityService<IUnitTypesRepository, IAppUnitOfWork, UnitType,
            App.DTO.UnitType, IBLLMapper<UnitType,
                App.DTO.UnitType>>, IUnitTypeService
    {
        public UnitTypeService(IAppUnitOfWork unitOfWork, IBLLMapper<UnitType, App.DTO.UnitType> mapper)
            : base(unitOfWork, mapper, unitOfWork.UnitTypes)
        {
        }
    }
}