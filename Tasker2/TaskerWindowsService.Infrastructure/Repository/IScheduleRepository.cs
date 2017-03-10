using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryT.Infrastructure;
using TaskerWindowsService.Domain;

namespace TaskerWindowsService.Infrastructure.Repository
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
    }
}
