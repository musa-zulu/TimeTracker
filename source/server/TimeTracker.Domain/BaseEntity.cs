using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
