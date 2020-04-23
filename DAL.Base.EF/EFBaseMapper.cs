using Contracts.DAL.App;

namespace DAL.Base.EF
{
    public class EFBaseMapper
    {
        protected readonly IAppMapperContext MapperContext;

        public EFBaseMapper(IAppMapperContext mapperContext)
        {
            MapperContext = mapperContext;
        }
    }
}