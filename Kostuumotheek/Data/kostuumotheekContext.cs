using System;
using Microsoft.EntityFrameworkCore;
using Kostuumotheek.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kostuumotheek.Data
{
    public class KostuumotheekContext : IdentityDbContext<ApplicationUser>
    {   
        public KostuumotheekContext(DbContextOptions<KostuumotheekContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=192.168.252.2;port=3307;database=Kostuumotheek;user=www;password=w8chtw00rd");
        }

        public DbSet<Costume> Costumes { get; set; }
    }
}
