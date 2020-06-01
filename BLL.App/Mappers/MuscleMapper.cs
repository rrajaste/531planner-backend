using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class MuscleMapper : BLLBaseMapper, IBLLMapper<Muscle, App.DTO.Muscle>
    {
        public MuscleMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.Muscle MapDALToBLL(Muscle dalObject)
        {
            return new App.DTO.Muscle
            {
                Id = dalObject.Id,
                MuscleGroupId = dalObject.MuscleGroupId,
                Description = dalObject.Description,
                Name = dalObject.Name,
                MuscleGroup = dalObject.MuscleGroup == null
                    ? null
                    : BLLMapperContext.MuscleGroupMapper.MapDALToBLL(dalObject.MuscleGroup)
            };
        }

        public Muscle MapBLLToDAL(App.DTO.Muscle bllObject)
        {
            return new Muscle
            {
                Id = bllObject.Id,
                Description = bllObject.Description,
                Name = bllObject.Name,
                MuscleGroupId = bllObject.MuscleGroupId
            };
        }
    }
}