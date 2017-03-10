using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using Topshelf;
using Topshelf.Logging;
using ThreadState = System.Threading.ThreadState;

namespace TaskerWindowsService.Topshelf
{
    public abstract class BaseService : ServiceControl
    {
        private static readonly LogWriter Log = HostLogger.Get<BaseService>();
        private Thread _thread;
        private bool _stop = true;

        protected BaseService()
        {
            SleepPeriod = new TimeSpan(0, 0, 0, Convert.ToInt32(ConfigurationManager.AppSettings["TimeOutInSeconds"]));
        }

        public TimeSpan SleepPeriod { get; set; }

        public bool IsStopped { get; private set; }
        
        public bool Start(HostControl hostControl)
        {
            Log.Info("INFO TaskerService Starting...");
            _stop = false;

            if (_thread == null || _thread.ThreadState == ThreadState.Stopped)
            {
                _thread = new Thread(this.Run);
            }

            if (_thread.ThreadState != ThreadState.Running)
            {
                _thread.Start();
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return _stop = true;
        }

        private void Run()
        {
            try
            {
                try
                {
                    while (!_stop)
                    {
                        Log.Info("TaskerService is doing the work...");
                        IsStopped = false;
                        DoWork();
                        Log.Info("TaskerService is sleeping...");
                        Thread.Sleep(this.SleepPeriod);
                    }
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                }
                finally
                {
                    _thread = null;
                    this.IsStopped = true;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        protected abstract void DoWork();
    }
}
