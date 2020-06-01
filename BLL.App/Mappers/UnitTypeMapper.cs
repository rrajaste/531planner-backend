using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class UnitTypeMapper : BLLBaseMapper, IBLLMapper<UnitType, App.DTO.UnitType>
    {
        public UnitTypeMapper(IAppBLLMapperContext context) : base(context)
        {
        }

        public App.DTO.UnitType MapDALToBLL(UnitType dalObject)
        {
            return new App.DTO.UnitType
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
        }

        public UnitType MapBLLToDAL(App.DTO.UnitType bllObject)
        {
            return new UnitType
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description
            };
        }
    }
}