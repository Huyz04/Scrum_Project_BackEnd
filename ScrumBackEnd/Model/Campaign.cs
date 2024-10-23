using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumBackEnd.Model
{
    [Table("Campaign")]
    public class Campaign
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string University { get; set; }
        public DateTime Time { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
     }
}
