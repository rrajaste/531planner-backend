namespace Contracts.BLL.Base.Mappers
{
    public interface IBaseBLLMapper<TInObject, TOutObject> 
        where TOutObject : class, new()
        where TInObject : class, new() 
    {
        TOutObject Map<TOutObject, TInObject>(TInObject inObject)
            where TOutObject : class, new()
            where TInObject : class, new();
    }
}