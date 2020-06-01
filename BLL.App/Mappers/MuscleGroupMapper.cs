using System.Linq;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class MuscleGroupMapper : BLLBaseMapper, IBLLMapper<MuscleGroup, App.DTO.MuscleGroup>
    {
        public MuscleGroupMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.MuscleGroup MapDALToBLL(MuscleGroup dalObject)
        {
            return new App.DTO.MuscleGroup
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                Muscles = dalObject.Muscles?.Select(BLLMapperContext.MuscleMapper.MapDALToBLL)
            };
        }

        public MuscleGroup MapBLLToDAL(App.DTO.MuscleGroup bllObject)
        {
            return new MuscleGroup
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description
            };
        }
    }
}