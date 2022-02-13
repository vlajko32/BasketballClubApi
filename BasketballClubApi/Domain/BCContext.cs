using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Domain
{
    /// <summary>
    /// Klasa koja sluzi za pristup podacima u bazi
    /// </summary>
    public class BCContext: DbContext
    {
        /// <summary>
        /// Users tabela u bazi
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gyms tabela u bazi
        /// </summary>
        public DbSet<Gym> Gyms { get; set; }

        /// <summary>
        /// Players tabela u bazi
        /// </summary>
        public DbSet<Player> Players { get; set; }

        /// <summary>
        /// Selections tabela u bazi
        /// </summary>
        public DbSet<Selection> Selections { get; set; }

        /// <summary>
        /// Trainings tabela u bazi
        /// </summary>
        public DbSet<Training> Trainings { get; set; }

        /// <summary>
        /// Coaches tabela u bazi
        /// </summary>
        public DbSet<Coach> Coaches { get; set; }

        /// <summary>
        /// SelectionAges tabela u bazi
        /// </summary>
        public DbSet<SelectionAge> SelectionAges { get; set; }

        /// <summary>
        /// Coes tabela u bazi
        /// </summary>
        public DbSet<Code> Codes { get; set; }

        /// <summary>
        /// Metoda koja sluzi za konfigurisanje pristupa bazi
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=basketball-club-api;");
        }

        /// <summary>
        /// Metoda koja sluzi za konfigurisanje context klase
        /// </summary>
        /// <param name="builder"></param>
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

