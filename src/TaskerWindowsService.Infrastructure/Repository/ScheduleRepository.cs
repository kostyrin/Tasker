using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryT.EntityFramework;
using RepositoryT.Infrastructure;
using TaskerWindowsService.Domain;

namespace TaskerWindowsService.Infrastructure.Repository
{
    public class ScheduleRepository : EntityRepository<Schedule, TaskerDbContext>, IScheduleRepository
    {
        public ScheduleRepository(IServiceLocator serviceLocator): base(serviceLocator)
        {

        }
    }
}
