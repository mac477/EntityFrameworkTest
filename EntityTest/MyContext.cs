using EntityTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }

        public DbSet<Person> PersonColl { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.HasOne(e => e.TeamRel)
                    .WithMany(e => e.PersonColl);
            });
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

        }


        int idPerson = 1;
        public int NextIdPerson => idPerson++;

        int idTeam = 1;
        public int NextIdTeam => idTeam++;
    }
}
