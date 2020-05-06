using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

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
                Description = dalObject.Description,
                Name = dalObject.Name,
                MuscleGroup = dalObject.MuscleGroup == null 
                    ? null 
                    : BLLMapperContext.MuscleGroupMapper.MapDALToBLL(dalObject.MuscleGroup)
            };

        public DAL.App.DTO.Muscle MapBLLToDAL(Muscle dalObject) => 
            new DAL.App.DTO.Muscle()
            {
                Id = dalObject.Id,
                Description = dalObject.Description,
                Name = dalObject.Name,
                MuscleGroupId = dalObject.MuscleGroupId
            };
    }
}
