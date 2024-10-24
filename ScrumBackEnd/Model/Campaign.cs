using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumBackEnd.Model
{
    [Table("Campaign")]
    public class Campaign
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? University { get; set; } = string.Empty;
        public string? Time { get; set; } = string.Empty;
        public int? Quantity { get; set; } = 0;
        public string? Description { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public string? Status { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
    }
}
