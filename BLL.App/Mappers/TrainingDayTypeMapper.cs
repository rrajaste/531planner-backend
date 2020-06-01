using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class TrainingDayTypeMapper : BLLBaseMapper, IBLLMapper<TrainingDayType, App.DTO.TrainingDayType>
    {
        public TrainingDayTypeMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.TrainingDayType MapDALToBLL(TrainingDayType dalObject)
        {
            return new App.DTO.TrainingDayType
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
        }

        public TrainingDayType MapBLLToDAL(App.DTO.TrainingDayType bllObject)
        {
            return new TrainingDayType
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description
            };
        }
    }
}