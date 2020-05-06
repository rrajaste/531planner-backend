using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class TrainingDayTypeMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.TrainingDayType, TrainingDayType>
    {
        public TrainingDayTypeMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public TrainingDayType MapDALToBLL(DAL.App.DTO.TrainingDayType dalObject) =>
            new TrainingDayType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };

        public DAL.App.DTO.TrainingDayType MapBLLToDAL(TrainingDayType bllObject) =>
            new DAL.App.DTO.TrainingDayType()
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description
            };
    }
}
