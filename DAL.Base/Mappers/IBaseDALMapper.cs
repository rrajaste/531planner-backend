namespace DAL.Base.Mappers
{
    public interface IBaseDALMapper<TInObject, TOutObject> 
        where TOutObject : class, new()
        where TInObject : class, new()
    {
        TOutObject MapDomainToDAL(TInObject domainObject);
        TInObject MapDALToDomain(TOutObject dalObject);
    }
}
