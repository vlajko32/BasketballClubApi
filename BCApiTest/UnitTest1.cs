using BasketballClub_Rest.Controllers;
using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.iRepository;
using BasketballClub_Rest.Repository.Repository_Impl;
using BasketballClub_Rest.Repository.UnitOfWork;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace BCApiTest
{
    //public class UnitTest1: IDisposable
    //{
    //    private IUnitOfWork uow;
    //    private BCContext context;
    //    private 
    //    public void Dispose()
    //    {
    //        context.Database.EnsureDeleted();
    //    }

    //    [Fact]
    //    public void Test1()
    //    {
    //        var repositoryStub = new Mock<IUnitOfWork>();
    //        repositoryStub.Setup(repo => repo.Selections.FindById(It.IsAny<int>())).Returns((Selection)null);


    //        var controller = new SelectionController(repositoryStub.Object);

    //        var result = controller.GetByID(5);


    //        Assert.IsType<NotFoundResult>(result.result);
    //    }
    //}
}
