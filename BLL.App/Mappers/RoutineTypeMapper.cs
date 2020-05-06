using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class RoutineTypeMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.RoutineType, RoutineType>
    {
        public RoutineTypeMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public RoutineType MapDALToBLL(DAL.App.DTO.RoutineType dalObject)
        {
            return new RoutineType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                ParentTypeId = dalObject.ParentTypeId,
                SubTypes = dalObject.SubTypes?.Select(MapDALToBLL)
            };
        }

        public DAL.App.DTO.RoutineType MapBLLToDAL(RoutineType bllObject) =>
            new DAL.App.DTO.RoutineType()
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description,
                ParentTypeId = bllObject.ParentTypeId
            };
    }
}