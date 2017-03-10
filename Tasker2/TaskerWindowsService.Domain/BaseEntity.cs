using System.ComponentModel.DataAnnotations;

namespace TaskerWindowsService.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
