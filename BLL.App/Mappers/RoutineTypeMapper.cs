using System.Linq;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class RoutineTypeMapper : BLLBaseMapper, IBLLMapper<RoutineType, App.DTO.RoutineType>
    {
        public RoutineTypeMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.RoutineType MapDALToBLL(RoutineType dalObject)
        {
            return new App.DTO.RoutineType
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                ParentTypeId = dalObject.ParentTypeId,
                SubTypes = dalObject.SubTypes?.Select(MapDALToBLL)
            };
        }

        public RoutineType MapBLLToDAL(App.DTO.RoutineType bllObject)
        {
            return new RoutineType
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description,
                ParentTypeId = bllObject.ParentTypeId
            };
        }
    }
}