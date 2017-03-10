using TaskerWindowsService.Common;
using TaskerWindowsService.Domain;
using System;
using System.Data.Entity.Migrations;

namespace TaskerWindowsService.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TaskerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskerDbContext context)
        {
            
        }
    }
}
