using ApiDbContext.Entities;
using Microsoft.EntityFrameworkCore;

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
