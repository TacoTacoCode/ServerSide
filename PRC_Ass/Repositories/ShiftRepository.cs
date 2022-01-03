using Microsoft.EntityFrameworkCore;
using PRC_Ass.Models;
using PRC_Ass.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PRC_Ass.Repositories
{
    public partial interface IShiftRepository : IBaseRepository<Shifts>
    {
    }
    public partial class ShiftRepository : BaseRepository<Shifts>, IShiftRepository
    {
        public ShiftRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
