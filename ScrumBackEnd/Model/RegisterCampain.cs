using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumBackEnd.Model
{
    [Table("RegisterCampain")]
    public class RegisterCampain
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CampaignId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
    }
}
