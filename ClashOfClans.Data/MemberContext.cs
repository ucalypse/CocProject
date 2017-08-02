using System.Security.Cryptography.X509Certificates;

namespace ClashOfClans.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MemberContext : DbContext
    {
        public MemberContext()
            : base("name=Members")
        {
            
        }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
