using System;
using System.Collections.Generic;

namespace BLL.Base
{
    public class BaseMapperContext
    {
        private readonly Dictionary<Type, object> _mapperCache = new Dictionary<Type, object>();
        
        public TMapper GetMapper<TMapper>(Func<TMapper> mapperCreationMethod)
        {
            if (_mapperCache.TryGetValue(typeof(TMapper), out var mapper))
            {
                return (TMapper) mapper;
            }

            mapper = mapperCreationMethod()!;
            _mapperCache.Add(typeof(TMapper), mapper);
            return (TMapper) mapper;
        }
    }
}