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
    public class TrainingServiceTest: IDisposable
    {
        private IUnitOfWork uow;
        private BCContext context;
        private TrainingService trainingService;

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        public TrainingServiceTest()
        {
            DbContextOptionsBuilder dbContextOption = new DbContextOptionsBuilder<BCContext>().UseInMemoryDatabase(new Guid().ToString());
            context = new BCContext(dbContextOption.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options);
            context.Database.EnsureCreated();
            uow = new BCUnitOfWork(context);
            trainingService = new TrainingService(uow);
        }

      


        [Fact]
        public void AddingNullValueShouldThrowNullPointerException()
        {

            Assert.Throws<NullReferenceException>(() => trainingService.Create(null));
            Dispose();
        }

    }
}
