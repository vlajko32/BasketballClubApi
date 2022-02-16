using BasketballClub_Rest.Controllers;
using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.iRepository;
using BasketballClub_Rest.Repository.Repository_Impl;
using BasketballClub_Rest.Repository.UnitOfWork;
using BasketballClubApi.Services;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace BCApiTest
{
    public class PlayerServiceTest : IDisposable
    {
        private IUnitOfWork uow;
        private BCContext context;
        private PlayerService playerService;

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        public PlayerServiceTest()
        {
            DbContextOptionsBuilder dbContextOption = new DbContextOptionsBuilder<BCContext>().UseInMemoryDatabase(new Guid().ToString());
            context = new BCContext(dbContextOption.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options);
            context.Database.EnsureCreated();
            uow = new BCUnitOfWork(context);
            playerService = new PlayerService(uow);
        }

        [Fact]
        public void AddingNullValueShouldThrowNullPointerException()
        {
            Seed();

            Assert.Throws<NullReferenceException>(() => playerService.Create(null));
            Dispose();
        }

        [Fact]
        public void AddingPlayerShouldReturnPlayer()
        {
            Seed();

            Player player = new Player
            {
                Name = "Marko",
                Surname = "Peric",
                BirthDate = new DateTime(1998, 7, 24),
                Weight = 96,
                Height = 190
            };
            Player newPlayer = playerService.Create(player);
            Assert.Equal(player.Name, newPlayer.Name);
            Dispose();
        }

        [Fact]
        public void GetAllShouldReturnAllPlayers()
        {
            Seed();

            List<Player> players = playerService.GetAll();
   
            Assert.Equal(2, players.Count);
            Dispose();
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-10)]
        public void DeleteWithInvalidIDShouldReturnException(int id)
        {
            Seed();

            var ex = Record.Exception(() => playerService.Delete(id));
            Assert.Equal("Invalid id!", ex.Message);
            Dispose();
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void DeletePlayerWhoDoesNotExistShouldReturnException(int id)
        {
            Seed();

            var ex = Record.Exception(() => playerService.Delete(id));
            Assert.Equal("Player with that id does not exist!", ex.Message);
            Dispose();
        }







        private void Seed()
        {
            var s1 = context.Players.Add(new Player
            {
                Name = "Vladislav",
                Surname = "Stojkovic",
                BirthDate = new DateTime(1998,7,24),
                Weight = 96,
                Height = 190
            });
            var s2 = context.Players.Add(new Player
            {
                Name = "Petar",
                Surname = "Peric",
                BirthDate = new DateTime(1998, 7, 24),
                Weight = 96,
                Height = 190
            });

            context.SaveChanges();
        }
    }
}
