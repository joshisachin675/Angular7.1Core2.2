using DotNetCore.EntityFrameworkCore;
using IDCardScanning.Model.Entities;

namespace IDCardScanning.Database
{
    public sealed class UserLogRepository : EntityFrameworkCoreRepository<UserLogEntity>, IUserLogRepository
    {
        public UserLogRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
