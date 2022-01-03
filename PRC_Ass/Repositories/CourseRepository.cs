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
    public partial interface ICourseRepository : IBaseRepository<Courses>
    {
    }
    public partial class CourseRepository : BaseRepository<Courses>, ICourseRepository
    {
        public CourseRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
