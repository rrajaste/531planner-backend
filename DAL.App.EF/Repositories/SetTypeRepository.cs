using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class SetTypeRepository : EFBaseRepository<AppDbContext, Domain.SetType, DTO.SetType>,
        ISetTypeRepository
    {
        public SetTypeRepository(AppDbContext dbContext, IDALMapper<SetType, DTO.SetType> mapper) 
            : base(dbContext, mapper)
        {
            
        }
    }
}