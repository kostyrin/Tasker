using Autofac;
using System;
using System.Configuration;
using Topshelf;
using Topshelf.Autofac;

namespace TaskerWindowsService.Topshelf
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var container = ConfigContainer();

            if (Environment.UserInteractive)
            {
#if DEBUG
                HostFactory.Run(x =>
                {
                    x.Service<TaskerService>(s =>
                    {
                        s.ConstructUsingAutofacContainer();
                        s.WhenStarted((tc, control) => tc.Start(control));
                        s.WhenStopped((tc, control) => tc.Stop(control));
                    });
                    x.SetDescription(ConfigurationManager.AppSettings["ServiceDescription"]);
                    x.SetDisplayName(ConfigurationManager.AppSettings["ServiceDisplayName"]);
                    x.SetServiceName(ConfigurationManager.AppSettings["ServiceName"]);
                    x.OnException(Console.WriteLine);
                    x.UseNLog();
                    x.UseAutofacContainer(container);
                    // Alternatively, you can run the service as a specific user. 
                    // x.RunAs("user","password");                     
                    x.RunAsLocalSystem();
                    
                });
                Console.ReadLine();
#endif
            }
            else
            {
                HostFactory.Run(x =>
                {
                    x.Service<TaskerService>(s =>
                    {
                        s.ConstructUsingAutofacContainer();
                        s.WhenStarted((tc, control) => tc.Start(control));
                        s.WhenStopped((tc, control) => tc.Stop(control));
                    });
                    x.SetDescription(ConfigurationManager.AppSettings["ServiceDescription"]);
                    x.SetDisplayName(ConfigurationManager.AppSettings["ServiceDisplayName"]);
                    x.SetServiceName(ConfigurationManager.AppSettings["ServiceName"]);
                    x.UseAutofacContainer(container);
                    x.RunAsLocalService();
                    // Alternatively, you can run the service as a specific user. 
                    // x.RunAs("user","password");                     
                });
            }

        }

        static IContainer ConfigContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacModule());
            return builder.Build();
        }
    }
}
