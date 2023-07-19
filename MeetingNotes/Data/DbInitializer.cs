using MeetingNotes.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MeetingNotes.Services;
using Microsoft.AspNetCore.Identity;

namespace MeetingNotes.Data
{
    public static class DbInitializer
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            {
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();

                DbInitializer.Initialize(db);

            }
            return app;

        }

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();
            if (!context.Managers.Any())
            {
                foreach (Worker worker in context.Workers)
                {
                    if (worker.IsManager == true)
                    {
                        var manager = new Manager();
                        manager.WorkerId = worker.WorkerId;
                        context.Managers.Add(manager);
                        context.SaveChanges();
                    }
                }
            }
            if (!context.Roles.Any())
            {
                var identityRoles = new List<IdentityRole>
                {
                    new()
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new()
                    {
                        Name = "Worker",
                        NormalizedName = "WORKER"
                    },
                    new()
                    {
                        Name = "Manager",
                        NormalizedName = "MANAGER"
                    }

                };
                context.AddRange(identityRoles);
                context.SaveChanges();
            }
            if (!context.Workers.Any())
            {
                return;   // DB has been seeded
            }
            //var workers = new Worker[]
            //{
            //    new Worker{ LastName="Horvat", FirstName="Ivan", EnrollmentDate= DateTime.Parse("2010-09-01")},
            //    new Worker{ LastName="Marić", FirstName="Marko", EnrollmentDate= DateTime.Parse("2022-02-02")}
            //};
            //foreach (Worker w in workers)
            //{
            //    context.Workers.Add(w);
            //}
            //context.SaveChanges();

            //var meeting = new Meeting[]
            //{
            //    new Meeting{ MeetingDate=DateTime.Parse("2013-04-05")},
            //    new Meeting{ MeetingDate=DateTime.Parse("2014-07-08")}
            //};
            //foreach (Meeting m in meeting)
            //{
            //    context.Meetings.Add(m);
            //}
            //context.SaveChanges();

            //var notes = new Notes[]
            //{
            //    new Notes{ NotesText="Uvodni sastanak u firmi",
            //        MeetingId=meeting.Single(s=>s.MeetingDate.Equals("2013-04-05")).MeetingId}
            //};
            //foreach (Notes n in notes)
            //{
            //    context.Notes.Add(n);
            //}
            //context.SaveChanges();


            if (!context.Managers.Any())
            {
                foreach (Worker worker in context.Workers)
                {
                    if (worker.IsManager == true)
                    {
                        var manager = new Manager();
                        manager.WorkerId = worker.WorkerId;
                        context.Managers.Add(manager);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}