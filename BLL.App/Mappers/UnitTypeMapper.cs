using Contracts.DAL.App;
using BLL.App.DTO;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;

namespace BLL.Mappers
{
    public class UnitTypeMapper : IBLLMapper<DAL.App.DTO.UnitType, UnitType>
    {
        private readonly IAppBLLMapperContext _context;
        public UnitTypeMapper(IAppBLLMapperContext context)
        {
            _context = context;
        }
        
        public UnitType MapDALToBLL(DAL.App.DTO.UnitType dalObject) =>
            new UnitType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };

        public DAL.App.DTO.UnitType MapBLLToDAL(UnitType bllObject) =>
            new DAL.App.DTO.UnitType()
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description
            };
    }
}