using DotNetCore.Repositories;
using IDCardScanning.Model.Entities;

namespace IDCardScanning.Database
{
    public interface IUserLogRepository : IRelationalRepository<UserLogEntity> { }
}
