using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Kostuumotheek.Models;

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

        /// <summary>
        /// Some database fixup / model constraints
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Fix asp.net identity 2.0 tables under MySQL
            // Explanations: primary keys can easily get too long for MySQL's 
            // (InnoDB's) stupid 767 bytes limit.
            // With the two following lines we rewrite the generation to keep
            // those columns "short" enough
            modelBuilder.Entity<IdentityRole>()
                        .ToTable("AspNetRoles")
                        .Property(c => c.Id)
                        .HasMaxLength(128)
                        .IsRequired();
            modelBuilder.Entity<IdentityRole>()
                        .ToTable("AspNetRoles")
                        .Property(c => c.NormalizedName)
                        .HasMaxLength(128)
                        .IsRequired();

            // We have to declare the table name here, otherwise IdentityUser 
            // will be created
            modelBuilder.Entity<IdentityUserLogin<string>>()
                        .ToTable("AspNetUserLogins")
                        .Property(c => c.LoginProvider)
                        .HasMaxLength(128)
                        .IsRequired();
            modelBuilder.Entity<IdentityUserLogin<string>>()
                        .ToTable("AspNetUserLogins")
                        .Property(c => c.ProviderKey)
                        .HasMaxLength(128)
                        .IsRequired();

            // We have to declare the table name here, otherwise IdentityUser 
            // will be created
            modelBuilder.Entity<IdentityUserToken<string>>()
                        .ToTable("AspNetUserTokens")
                        .Property(c => c.Name)
                        .HasMaxLength(128)
                        .IsRequired();
            modelBuilder.Entity<IdentityUserToken<string>>()
                        .ToTable("AspNetUserTokens")
                        .Property(c => c.LoginProvider)
                        .HasMaxLength(128)
                        .IsRequired();


            // We have to declare the table name here, otherwise IdentityUser 
            // will be created
            modelBuilder.Entity<ApplicationUser>()
                        .ToTable("AspNetUsers")
                        .Property(c => c.Id)
                        .HasMaxLength(128)
                        .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                        .ToTable("AspNetUsers")
                        .Property(c => c.NormalizedUserName)
                        .HasMaxLength(128)
                        .IsRequired();
            #endregion
        }

        public DbSet<Costume> Costumes { get; set; }
    }
}
