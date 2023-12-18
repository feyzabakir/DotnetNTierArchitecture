using DotnetNTierArchitecture.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNTierArchitecture.Repository
{
    public class AppDbContext:DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // IEntityTypeConfiguration interface'ini kullanmış olan bütün konfigürasyon dosyalarını dahil etmiş oluruz.

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                
        }
    }
}
