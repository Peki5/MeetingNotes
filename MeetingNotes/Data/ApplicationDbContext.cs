using MeetingNotes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetingNotes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Worker> Workers { get; set; }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<Notes> Notes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().ToTable("Worker");
            modelBuilder.Entity<Manager>().ToTable("Manager");
            modelBuilder.Entity<Meeting>().ToTable("Meeting");
            modelBuilder.Entity<Notes>().ToTable("Notes");

            base.OnModelCreating(modelBuilder);
        }
    }
}