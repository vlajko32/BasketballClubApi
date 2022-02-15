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
    public class SelectionServiceTest : IDisposable
    {
        private IUnitOfWork uow;
        private BCContext context;
        private SelectionService selectionService;

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        public SelectionServiceTest()
        {
            DbContextOptionsBuilder dbContextOption = new DbContextOptionsBuilder<BCContext>().UseInMemoryDatabase(new Guid().ToString());
            context = new BCContext(dbContextOption.Options);
            context.Database.EnsureCreated();
            Seed();
            uow = new BCUnitOfWork(context);
            selectionService = new SelectionService(uow);
        }

        [Fact]
        public void AddingNullValueShouldThrowNullPointerException()
        {
            Assert.Throws<NullReferenceException>(() => selectionService.Create(null));
            Dispose();
        }

        [Theory]
        [InlineData(2,"B-team")]
        [InlineData(5, "C-team")]
        public void AddingSelectionShouldReturnSelection(int id, string name)
        {
            Selection selection = new Selection{
                SelectionName = name,
                SelectionAgeID = id
            };
            Selection selection1 = selectionService.Create(selection);
            Assert.Equal(selection.SelectionName, selection1.SelectionName);
            Dispose();
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-10)]
        public void DeleteWithInvalidIDShouldReturnException(int id)
        {
            var ex = Record.Exception(() => selectionService.Delete(id));
            Assert.Equal("Invalid id!", ex.Message);
            Dispose();
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void DeleteSelectionWhichDoesNotExistShouldReturnException(int id)
        {
            var ex = Record.Exception(() => selectionService.Delete(id));
            Assert.Equal("There is no selection with that id", ex.Message);
            Dispose();
        }

      

        [Fact]
        public void GetAllShouldReturnAll()
        {
            List<Selection> selections = selectionService.GetAll();
            Assert.Equal(2, selections.Count);
            Dispose();
        }

        private void Seed()
        {
           
            var s1 = context.Selections.Add(new Selection
            {
               SelectionName = "A-team",
               SelectionAgeID = 6
            });
            var s2 = context.Selections.Add(new Selection
            {
                SelectionName = "B-team",
                SelectionAgeID = 5
            });
            

            context.SaveChanges();
        }
    }
}
