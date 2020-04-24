using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class PersonalRecordRepository : EFBaseRepository<AppDbContext, Domain.PersonalRecord, DTO.PersonalRecord>,
        IPersonalRecordRepository
    {
        public PersonalRecordRepository(AppDbContext dbContext, IDALMapper<PersonalRecord, DTO.PersonalRecord> mapper) 
            : base(dbContext, mapper)
        {
            
        }
    }
}