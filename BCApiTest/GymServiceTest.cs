using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.UnitOfWork;
using BasketballClubApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BCApiTest
{
    public class GymServiceTest : IDisposable
    {
        private IUnitOfWork uow;
        private BCContext context;
        private GymService gymService;

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        public GymServiceTest()
        {
            DbContextOptionsBuilder dbContextOption = new DbContextOptionsBuilder<BCContext>().UseInMemoryDatabase(new Guid().ToString());
            context = new BCContext(dbContextOption.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options);
            context.Database.EnsureCreated();
            uow = new BCUnitOfWork(context);
            gymService = new GymService(uow);
        }



        [Fact]
        public void GetAllShouldReturnAllGyms()
        {

            List<Gym> gyms = gymService.GetAll();

            Assert.Equal(3, gyms.Count);
            Dispose();
        }
    }
}
