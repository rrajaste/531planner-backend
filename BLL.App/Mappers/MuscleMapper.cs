using Contracts.DAL.App;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.Mappers
{
    public class MuscleMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.Muscle, Muscle>
    {
        public MuscleMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public Muscle MapDALToBLL(DAL.App.DTO.Muscle dalObject) =>
            new Muscle()
            {
                Id = dalObject.Id,
                MuscleGroupId = dalObject.MuscleGroupId,
                Description = dalObject.Description,
                Name = dalObject.Name,
                MuscleGroup = dalObject.MuscleGroup == null 
                    ? null 
                    : BLLMapperContext.MuscleGroupMapper.MapDALToBLL(dalObject.MuscleGroup)
            };

        public DAL.App.DTO.Muscle MapBLLToDAL(Muscle bllObject) => 
            new DAL.App.DTO.Muscle()
            {
                Id = bllObject.Id,
                Description = bllObject.Description,
                Name = bllObject.Name,
                MuscleGroupId = bllObject.MuscleGroupId
            };
    }
}
