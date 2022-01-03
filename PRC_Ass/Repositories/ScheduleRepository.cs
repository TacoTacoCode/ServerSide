using Microsoft.EntityFrameworkCore;
using PRC_Ass.Models;
using PRC_Ass.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Repositories
{
    public partial interface IScheduleRepository : IBaseRepository<Schedule>
    {
    }
    public partial class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
