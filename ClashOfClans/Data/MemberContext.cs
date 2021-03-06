﻿using System.Data.Entity;
using ClashOfClans.Models;

namespace ClashOfClans.Data
{
    public class MemberContext : DbContext
    {
        public DbSet<MemberModel> Members { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<WarPlanModel> WarPlans { get; set; }
        public DbSet<TargetReservationModel> Reservations { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<TutorialModel> Videos { get; set; }
    }
}