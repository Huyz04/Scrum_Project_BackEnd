using Microsoft.EntityFrameworkCore;

namespace ScrumBackEnd.Model
{
    public class CampaignContext : DbContext
    {
        public CampaignContext(DbContextOptions options) :base(options) { }
        public DbSet<Userr> Users { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<RegisterCampain> RegisterCampains { get; set; }
    }
}
