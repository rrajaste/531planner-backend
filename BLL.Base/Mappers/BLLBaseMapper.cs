using Contracts.DAL.App;

namespace BLL.Base.Mappers
{
    public class BLLBaseMapper
    {
        protected readonly IAppBLLMapperContext BLLMapperContext;

        public BLLBaseMapper(IAppBLLMapperContext BLLMapperContext)
        {
            BLLMapperContext = BLLMapperContext;
        }
    
    }
}