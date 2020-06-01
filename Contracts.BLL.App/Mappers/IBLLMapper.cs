using Contracts.BLL.Base;
using Contracts.DAL.Base;

namespace Contracts.BLL.App.Mappers
{
    public interface IBLLMapper<TInObject, TOutObject>
        where TInObject : IDALBaseDTO
        where TOutObject : IBLLBaseDTO
    {
        TOutObject MapDALToBLL(TInObject dalObject);
        TInObject MapBLLToDAL(TOutObject bllObject);
    }
}