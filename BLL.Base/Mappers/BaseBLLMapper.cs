using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.Base.Mappers
{
    public class BaseBLLMapper<TOutObject, TInObject> : IBaseBLLMapper<TOutObject, TInObject>
        where TOutObject : class, new() 
        where TInObject : class, new()
    {

        private readonly IMapper _mapper;

        public BaseBLLMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<TInObject, TOutObject>();
                config.CreateMap<TOutObject, TInObject>();
            }).CreateMapper();
        }

        public TOutObject Map<TOutObject, TInObject>(TInObject inObject) 
            where TOutObject : class, new() 
            where TInObject : class, new()
        {
            return _mapper.Map<TInObject, TOutObject>(inObject);
        }
    }
}