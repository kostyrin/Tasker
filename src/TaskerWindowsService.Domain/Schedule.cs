using System;
using System.ComponentModel.DataAnnotations;

namespace TaskerWindowsService.Domain
{
    public class Schedule : BaseEntity
    {
        [Required]
        public string TaskName { get; set; }
        public DateTime? StartAt { get; set; }
        public string Parameters { get; set; }
        public bool IsRunning { get; set; }
        public bool IsFailed { get; set; }
        public bool IsFinished { get; set; }
    }
}
