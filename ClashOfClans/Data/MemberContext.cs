using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClashOfClans.Data
{
    public class MemberContext : DbContext
    {
        public DbSet Members { get; set; }
    }
}