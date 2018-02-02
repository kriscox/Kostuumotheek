using System;
using Microsoft.EntityFrameworkCore;
using Kostuumotheek.Models;

namespace Kostuumotheek.Data
{
    public class KostuumotheekContext : DbContext
    {   
        public KostuumotheekContext(DbContextOptions<KostuumotheekContext> options)
            : base(options)
        {
        }

        public DbSet<Costume> Costumes { get; set; }
    }
}
