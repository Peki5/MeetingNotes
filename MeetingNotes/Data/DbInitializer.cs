using MeetingNotes.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


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
        }
    }
}