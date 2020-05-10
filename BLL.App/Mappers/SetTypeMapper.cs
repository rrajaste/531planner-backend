using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.Base.Mappers;

namespace BLL.Mappers
{
    public class SetTypeMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.SetType, SetType>
    {
        public SetTypeMapper(IAppBLLMapperContext context) : base(context)
        {
        }
        
        public SetType MapDALToBLL(DAL.App.DTO.SetType dalObject) =>
            new SetType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };

        public DAL.App.DTO.SetType MapBLLToDAL(SetType bllObject) =>
            new DAL.App.DTO.SetType()
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description
            };
    }
}