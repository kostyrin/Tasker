using System;
using NLog;
using TaskerWindowsService.Common;
using TaskerWindowsService.Domain;
using TaskerWindowsService.Infrastructure.Service;

namespace TaskerWindowsService.Services
{
    public class ScheduleProcessService
    {
        private readonly ScheduleProcessesWrapper _wrapper;
        private readonly IScheduleService _scheduleService;
        private readonly ILogger _log = LogManager.GetLogger(typeof(ScheduleProcessService).Name, typeof(ScheduleProcessService));

        public ScheduleProcessService(ScheduleProcessesWrapper wrapper, IScheduleService scheduleService)
        {
            _wrapper = wrapper;
            _scheduleService = scheduleService;
        }

        public void GetAndDoProcess()
        {
            Func<Schedule, bool> processToExec = null;

            var task = _scheduleService.GetAvaibleTask();

            if (task == null)
            {
                _log.Info("Task is not founded");
                return;
            }
            _log.Info($"Task:{task.TaskName} is runing");
            _scheduleService.SetRunning(task);

            switch (task.TaskName)
            {
                case TaskNames.CreateEmptyFileAfter10Seconds:
                    processToExec = _wrapper.CreateEmptyFileAfter10Seconds;
                    break;
                case TaskNames.SendEmail:
                    processToExec = _wrapper.SendEmail;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"You have to implement this process {task.TaskName}");
            }

            try
            {
                ExecuteTask(processToExec, task);
            }
            catch (Exception e)
            {
                _scheduleService.SetFailed(task);
                _log.Error(e);
            }

            
        }

        private void ExecuteTask(Func<Schedule, bool> action, Schedule task)
        {
            if (action(task))
            {
                _scheduleService.SetFinished(task);
                _log.Info($"Task:{task.TaskName} is finished and deleted");
            }
            else
            {
                _scheduleService.SetNotRuning(task);
                _log.Info($"Task:{task.TaskName} is canceled");
            }
        }
    }
}
