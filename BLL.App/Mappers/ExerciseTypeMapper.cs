using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class ExerciseTypeMapper : BLLBaseMapper, IBLLMapper<ExerciseType, App.DTO.ExerciseType>
    {
        public ExerciseTypeMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.ExerciseType MapDALToBLL(ExerciseType dalObject)
        {
            return new App.DTO.ExerciseType
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                TypeCode = dalObject.TypeCode
            };
        }


        public ExerciseType MapBLLToDAL(App.DTO.ExerciseType bllObject)
        {
            return new ExerciseType
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description,
                TypeCode = bllObject.TypeCode
            };
        }
    }
}