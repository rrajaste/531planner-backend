using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class PersonalRecordRepository : EFBaseRepository<AppDbContext, PersonalRecord, DTO.PersonalRecord>,
        IPersonalRecordRepository
    {
        public PersonalRecordRepository(AppDbContext dbContext, IDALMapper<PersonalRecord, DTO.PersonalRecord> mapper) 
            : base(dbContext, mapper)
        {
            
        }
    }
}