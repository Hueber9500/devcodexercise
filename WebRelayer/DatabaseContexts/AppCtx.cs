using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Entities;

namespace WebRelayer.Database_Contexts
{
    public class AppCtx:DbContext
    {
        public AppCtx(DbContextOptions<AppCtx> options)
            :base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<EmployeeTeam> EmployeesTeams { get; set; }

        public DbSet<SubscriptionData> SubscriptionsData { get; set; }

        public DbSet<EmployeeArrival> EmployeeArrival { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeTeam>()
                .HasKey(et => new { et.EmployeeId, et.TeamId});

            modelBuilder.Entity<EmployeeTeam>()
                .HasOne(et => et.Employee)
                .WithMany(e => e.Teams)
                .HasForeignKey(et => et.EmployeeId);

            modelBuilder.Entity<EmployeeTeam>()
                .HasOne(et => et.Team)
                .WithMany(t => t.Employees)
                .HasForeignKey(et => et.TeamId);
        }
    }
}
