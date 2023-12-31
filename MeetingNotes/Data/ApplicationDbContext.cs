﻿using MeetingNotes.Models;
using Microsoft.AspNetCore.Identity;
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
            modelBuilder.Entity<Manager>().ToTable("Manager").HasKey(w=>new {w.ManagerId,w.WorkerId });
            modelBuilder.Entity<Meeting>().ToTable("Meeting");
            modelBuilder.Entity<Notes>().ToTable("Notes");


            base.OnModelCreating(modelBuilder);

            //---------------------------------------------------------------------------------------------------------
            //Roles and Admin seeds ---

            string ADMIN_ID = "22e40406-8a9d-2d82-912c-5d6a640ee696";
            string ADMIN_ROLE_ID = "74d04fa7-36b6-4fa2-ade4-d2a1759e4091";
            string WORKER_ROLE_ID = "012345f0-akl2–42de-afbf-59ccfdaf72cf6";
            string MANAGER_ROLE_ID = "341743f0-a67k–42de-afbf-59asdfac72cf6";

            //Create and Seed Roles
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Worker",
                NormalizedName = "WORKER",
                Id = WORKER_ROLE_ID,
                ConcurrencyStamp = WORKER_ROLE_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Manager",
                NormalizedName = "MANAGER",
                Id = MANAGER_ROLE_ID,
                ConcurrencyStamp = MANAGER_ROLE_ID
            });


            //create Admin
            var AdminUser = new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,

            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            AdminUser.PasswordHash = ph.HashPassword(AdminUser, "Admin123!");

            modelBuilder.Entity<IdentityUser>().HasData(AdminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}