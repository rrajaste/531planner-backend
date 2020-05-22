namespace Contracts.BLL.Base.Mappers
{
    public interface IBaseBLLMapper<TInObject, TOutObject> 
        where TOutObject : class, new()
        where TInObject : class, new() 
    {
        TRightObject Map<TLeftObject, TRightObject>(TLeftObject inObject)
            where TRightObject : class, new()
            where TLeftObject : class, new();
    }
}