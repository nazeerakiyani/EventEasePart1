using System.ComponentModel.DataAnnotations;
namespace EventEasePart1.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int VenueId { get; set; }
        public int EventId { get; set; }
        [Required] public string CustomerName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
    }
}