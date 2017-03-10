using System;
using System.Data.Entity;
using Newtonsoft.Json;
using TaskerWindowsService.Common;
using TaskerWindowsService.Common.Parameters;
using TaskerWindowsService.Domain;

namespace TaskerWindowsService.Infrastructure
{
    public class TaskerDbContextInit : CreateDatabaseIfNotExists<TaskerDbContext>
    {
        protected override void Seed(TaskerDbContext context)
        {
            context.Schedules.Add(new Schedule()
            {
                TaskName = TaskNames.CreateEmptyFileAfter10Seconds,
                Parameters = "file.txt",
            });

            context.Schedules.Add(new Schedule()
            {
                TaskName = TaskNames.SendEmail,
                Parameters = JsonConvert.SerializeObject(new SendEmailParams()
                {
                    EmailRecipient = "kostyrin2@gmail.com",
                    EmailSubject = "Some subject",
                    EmailText = "Some Text"
                }),
            });

            context.Schedules.Add(new Schedule()
            {
                TaskName = TaskNames.CreateEmptyFileAfter10Seconds,
                Parameters = "file_tomorrow.txt",
                StartAt = DateTime.UtcNow.AddDays(1)
            });

            context.SaveChanges();

        }
    }
}
