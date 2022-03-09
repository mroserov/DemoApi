using Demo.Contracts.Bl;
using Demo.Contracts.Entities;
using Demo.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Test
{
    public class DemoTaskControllerTests
    {
        private IDemoTaskBl BlController { get; }
        private readonly List<DemoTask> mockDemoTasks;

        public DemoTaskControllerTests()
        {
            this.BlController = Substitute.For<IDemoTaskBl>();
            this.mockDemoTasks = new List<DemoTask>
            {
                new DemoTask{ Id=1,Description="DemoTask 1", Name="DemoTask"},
                new DemoTask{ Id=2,Description="DemoTask 2", Name="DemoTask"}
            };
        }

        [Test]
        public async Task CreateAsyncWhenCalled_ReturnOk()
        {
            //Arrange
            var expected = this.mockDemoTasks.First();
            this.BlController.CreateAsync(Arg.Any<DemoTask>()).Returns(default(int));
            var controller = new DemoTasksController(this.BlController);

            //Act
            var result = await controller.CreateAsync(expected);

            //Assert
            ((ObjectResult)result.Result).StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}