using ApiDbContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDbContext.Context
{
    public class ApiDatabaseContext : DbContext
    {
        public ApiDatabaseContext(DbContextOptions<ApiDatabaseContext> options) : base(options)
        {

        }
        public DbSet<TaskSetting> TaskSettings { get; set; }
        public DbSet<TaskParameter> TaskParameters { get; set; }
    }
}
