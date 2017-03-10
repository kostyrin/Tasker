1. Рекомендую, чтобы нормально создалась база(без настройки прав и т.п.), лучше запустить проект TaskerWindowsService.Topshelf из студии.
2. Чтобы установить сервис из папки TaskerWindowsService.Topshelf\Debug(или Release) запусить TaskerWindowsService.Topshelf.exe install. Потом запустить его как сервис
3. Чтобы остановить/удалить сервис запусить TaskerWindowsService.Topshelf.exe uninstall
4. Чтобы расширить задачами нужно:
4.1. Добавить название задачи TaskerWindowsService.Common.TaskNames  
4.2. Добавить сервис в TaskerWindowsService.Services.ProcessServices
4.3. Добавить метод сервиса в TaskerWindowsService.Services.ScheduleProcessService
4.4. Добавить вызов сервиса в TaskerWindowsService.Services.ScheduleProcessesWrapper
4.5. Добавить сервис/интерфейс в IoC Контейнер Autofac TaskerWindowsService.Topshelf.AutofacModule
4.6. Сделать insert в базу задачи с обязательным указанием имени задачи из п. 4.1

