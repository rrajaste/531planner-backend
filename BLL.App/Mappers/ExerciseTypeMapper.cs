using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class ExerciseTypeMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.ExerciseType, ExerciseType>
    {
        public ExerciseTypeMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public ExerciseType MapDALToBLL(DAL.App.DTO.ExerciseType dalObject) =>
            new ExerciseType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                TypeCode = dalObject.TypeCode
            };


        public DAL.App.DTO.ExerciseType MapBLLToDAL(ExerciseType bllObject) =>
            new DAL.App.DTO.ExerciseType()
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description,
                TypeCode = bllObject.TypeCode
            };
    }
}