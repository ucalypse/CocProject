using System.Data.Entity;

namespace ClashOfClans.Data
{
    public class MemberContext : DbContext
    {
        public DbSet<MemberModel> Members { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<WarPlanModel> WarPlans { get; set; }
    }
}