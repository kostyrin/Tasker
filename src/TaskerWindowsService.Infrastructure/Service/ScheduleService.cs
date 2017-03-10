using System;
using RepositoryT.Infrastructure;
using TaskerWindowsService.Domain;
using TaskerWindowsService.Infrastructure.Repository;

namespace TaskerWindowsService.Infrastructure.Service
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IUnitOfWork unitOfWork, IScheduleRepository scheduleRepository)
        {
            _unitOfWork = unitOfWork;
            _scheduleRepository = scheduleRepository;
        }

        public Schedule GetAvaibleTask()
        {
            var now = DateTime.UtcNow;
            return  _scheduleRepository.Get(s => !s.IsRunning && !s.IsFailed && !s.IsFinished && (s.StartAt <= now || !s.StartAt.HasValue));
        }

        public void SetRunning(Schedule task)
        {
            task.IsRunning = true;
            _unitOfWork.Commit();
        }

        public void SetFinished(Schedule task)
        {
            task.IsRunning = false;
            task.IsFinished = true;
            _scheduleRepository.Update(task);
            _unitOfWork.Commit();
        }

        public void SetNotRuning(Schedule task)
        {
            task.IsRunning = false;
            _scheduleRepository.Update(task);
            _unitOfWork.Commit();
        }

        public void SetFailed(Schedule task)
        {
            task.IsFailed = true;
            task.IsRunning = false;
            _scheduleRepository.Update(task);
            _unitOfWork.Commit();
        }

        public void Delete(Schedule task)
        {
            _scheduleRepository.Delete(task);
            _scheduleRepository.Update(task);
            _unitOfWork.Commit();
        }
    }
}
