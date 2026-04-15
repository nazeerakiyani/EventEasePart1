using System.ComponentModel.DataAnnotations;
namespace EventEasePart1.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
    }
}