using System.Configuration;
using Autofac;
using RepositoryT.EntityFramework;
using RepositoryT.Infrastructure;
using TaskerWindowsService.Infrastructure;
using TaskerWindowsService.Infrastructure.Repository;
using TaskerWindowsService.Infrastructure.Service;
using TaskerWindowsService.Services;
using TaskerWindowsService.Services.ExternalServices;
using TaskerWindowsService.Services.ProcessServices;

namespace TaskerWindowsService.Topshelf
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacServiceLocator>().As<IServiceLocator>().SingleInstance();

            builder.RegisterType<DefaultDataContextFactory<TaskerDbContext>>().As<IDataContextFactory<TaskerDbContext>>().InstancePerLifetimeScope();
            builder.RegisterType<EfUnitOfWork<TaskerDbContext>>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<ScheduleRepository>().As<IScheduleRepository>().SingleInstance();
            builder.RegisterType<ScheduleService>().As<IScheduleService>().SingleInstance();

            builder.RegisterType<TaskerService>();
            builder.RegisterType<ScheduleProcessService>();
            builder.RegisterType<ScheduleProcessesWrapper>();
            builder.RegisterType<EmailService>().As<IEmailService>();

            builder.RegisterType<CreateEmptyFileAfter10SecondsService>().As<ICreateEmptyFileAfter10SecondsService>();
            builder.RegisterType<SendEmailService>().As<ISendEmailService>();
        }
    }
}
