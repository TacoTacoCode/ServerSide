using Microsoft.EntityFrameworkCore;
using PRC_Ass.Models;
using PRC_Ass.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Repositories
{
    public partial interface IAccountRepository : IBaseRepository<Accounts>
    {
    }
    public partial class AccountRepository : BaseRepository<Accounts>, IAccountRepository
    {
        public AccountRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
