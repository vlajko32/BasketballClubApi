using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Domain
{
    public class BCContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Gym> Gyms { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Selection> Selections { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<SelectionAge> SelectionAges { get; set; }

        public DbSet<Administrator> Operators { get; set; }

        public DbSet<Code> Codes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=basketball-club-api;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
            .HasDiscriminator(r => r.Role);
           


            base.OnModelCreating(builder);

            builder.Entity<SelectionAge>().HasData(
                new SelectionAge { SelectionAgeID = 2, SelectionAgeName = "Under 12" },
                new SelectionAge { SelectionAgeID = 3, SelectionAgeName = "Under 14" },
                new SelectionAge { SelectionAgeID = 4, SelectionAgeName = "Under 16" },
                new SelectionAge { SelectionAgeID = 5, SelectionAgeName = "Juniors" },
                new SelectionAge { SelectionAgeID = 6, SelectionAgeName = "Seniors" }
                

                );

            builder.Entity<Code>().HasData(
                new Code { Id = 1, Value = 240798 },
                new Code { Id = 2, Value = 897042 },
                new Code { Id = 3, Value = 182429 },
                new Code { Id = 4, Value = 292418 }
                );
         

        }
    }

}

