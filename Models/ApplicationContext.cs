using System;
using Microsoft.EntityFrameworkCore;

namespace EventRegistration.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEventRegistration> UserEventRegistrations { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
