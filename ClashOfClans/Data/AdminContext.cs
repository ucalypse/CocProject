using System.Data.Entity;

namespace ClashOfClans.Data
{
    public class AdminContext : DbContext
    {
        public DbSet<AdminModel> Admins { get; set; }
    }
}