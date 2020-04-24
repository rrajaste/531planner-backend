namespace Contracts.DAL.App.Mappers
{
    public interface IDALMapper<TInObject, TOutObject> 
        where TOutObject : class, new()
        where TInObject : class, new()
    {
        TOutObject MapDomainToDAL(TInObject domainObject);
        TInObject MapDALToDomain(TOutObject dalObject);
    }
}
