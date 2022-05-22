using System;
using System.Collections.Generic;
using System.Reflection;
using DungeonHeros.Models.DataInjector;
using DungeonHeros.Models.ManyToMany;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DungeonHeros.Models
{
    public class DbContext : IdentityDbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Hero>()
                .HasOne(h => h.User)
                .WithOne(u => u.Hero)
                .HasForeignKey<User>(k => k.HeroForeignKey);


            modelBuilder.Entity<Hero>()
                .HasOne(h => h.Race)
                .WithMany(r => r.Heroes)
                .HasForeignKey(k => k.RaceId);

            modelBuilder.Entity<Hero>()
                .HasOne(h => h.Class)
                .WithMany(c => c.Heroes)
                .HasForeignKey(k => k.ClassId);
            
            modelBuilder.ApplyConfiguration(new BestiaryConfigurator());
            modelBuilder.ApplyConfiguration(new ClassConfigurator());
            modelBuilder.ApplyConfiguration(new RaceConfigurator());
        }

        public DbSet<Monster> Monsters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Dungeon> Dungeons { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Hero> Heroes { set; get; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<DungeonTeam> DungeonTeams { set; get; }
        public DbSet<Message> Messages { set; get; }
    }
}