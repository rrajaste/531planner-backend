using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using Contracts.BLL.App.Mappers;

namespace BLL.Mappers
{
    public class SetTypeMapper : IBLLMapper<DAL.App.DTO.SetType, SetType>
    {
        private readonly IAppBLLMapperContext _context;
        public SetTypeMapper(IAppBLLMapperContext context)
        {
            _context = context;
        }
        
        public SetType MapDALToBLL(DAL.App.DTO.SetType dalObject) =>
            new SetType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };

        public DAL.App.DTO.SetType MapBLLToDAL(SetType dalObject) =>
            new DAL.App.DTO.SetType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
    }
}