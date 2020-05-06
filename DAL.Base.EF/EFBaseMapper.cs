using Contracts.DAL.App;

namespace DAL.Base.EF
{
    public class EFBaseMapper
    {
        protected readonly IAppDALMapperContext DALMapperContext;

        public EFBaseMapper(IAppDALMapperContext dalMapperContext)
        {
            DALMapperContext = dalMapperContext;
        }
    }
}