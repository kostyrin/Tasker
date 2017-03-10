using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RepositoryT.EntityFramework.Interfaces;
using TaskerWindowsService.Domain;

namespace TaskerWindowsService.Infrastructure
{
    public class TaskerDbContext : DbContext, IDbContext
    {
        public TaskerDbContext() : base("TaskerDBContext")
        {
            Database.SetInitializer(new TaskerDbContextInit());
        }

        public DbSet<Schedule> Schedules { get; set; }
        
        private void SetupEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetupEntity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
