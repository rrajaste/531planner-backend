using Contracts.BLL.App;
using Contracts.DAL.App;

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