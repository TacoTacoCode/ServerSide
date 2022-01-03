using Microsoft.EntityFrameworkCore;
using PRC_Ass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Data
{
    public class DBContext : DbContext
    {
       public DBContext(DbContextOptions<DBContext> options) : base(options)
       {
            //Database.Migrate();
       }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Attendances> Attendances { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Shifts> Shifts { get; set; }

    }
}
