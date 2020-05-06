using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class MuscleGroupMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.MuscleGroup, MuscleGroup>
    {
        public MuscleGroupMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public MuscleGroup MapDALToBLL(DAL.App.DTO.MuscleGroup dalObject) =>
            new MuscleGroup()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                Muscles = dalObject.Muscles?.Select(BLLMapperContext.MuscleMapper.MapDALToBLL)
            };

        public DAL.App.DTO.MuscleGroup MapBLLToDAL(MuscleGroup bllObject) =>
            new DAL.App.DTO.MuscleGroup()
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description,
            };
    }
}