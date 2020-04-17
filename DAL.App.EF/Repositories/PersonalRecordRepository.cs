using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class PersonalRecordRepository : EFBaseRepository<AppDbContext, Domain.PersonalRecord, DAL.App.DTO.PersonalRecord>,
        IPersonalRecordRepository
    {
        public PersonalRecordRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}