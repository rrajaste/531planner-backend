using Contracts.BLL.App;

namespace BLL.Base.Mappers
{
    public class BLLBaseMapper
    {
        protected readonly IAppBLLMapperContext BLLMapperContext;

        public BLLBaseMapper(IAppBLLMapperContext bllMapperContext)
        {
            BLLMapperContext = bllMapperContext;
        }
    }
}