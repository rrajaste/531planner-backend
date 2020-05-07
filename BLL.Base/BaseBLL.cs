using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base;
using Contracts.DAL.Base;

namespace BLL.Base
{
    public class BaseBLL<TUnitOfWork> : IBaseBLL
    where TUnitOfWork : IBaseUnitOfWork
    {
        protected readonly TUnitOfWork UnitOfWork;
        private readonly Dictionary<Type, object> _serviceCache = new Dictionary<Type, object>();

        public BaseBLL(TUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Task<int> SaveChangesAsync()
        {
            return UnitOfWork.SaveChangesAsync();
        }

        public TService GetService<TService>(Func<TService> serviceCreationMethod)
        {
            if (_serviceCache.TryGetValue(typeof(TService), out var repo))
            {
                return (TService) repo;
            }

            repo = serviceCreationMethod()!;
            _serviceCache.Add(typeof(TService), repo);
            return (TService) repo;
        }
    }
}