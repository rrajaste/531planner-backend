using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class SetTypeMapper : BLLBaseMapper, IBLLMapper<SetType, App.DTO.SetType>
    {
        public SetTypeMapper(IAppBLLMapperContext context) : base(context)
        {
        }

        public App.DTO.SetType MapDALToBLL(SetType dalObject)
        {
            return new App.DTO.SetType
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                TypeCode = dalObject.TypeCode
            };
        }

        public SetType MapBLLToDAL(App.DTO.SetType bllObject)
        {
            return new SetType
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description,
                TypeCode = bllObject.TypeCode
            };
        }
    }
}