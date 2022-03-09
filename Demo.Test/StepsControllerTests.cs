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
    public class StepControllerTests
    {
        private IStepBl BlController { get; }
        private readonly List<Step> mockSteps;

        public StepControllerTests()
        {
            this.BlController = Substitute.For<IStepBl>();
            this.mockSteps = new List<Step>
            {
                new Step{ DemoTaskId=1,Description="Step 1", Id=1, Name="Step"},
                new Step{ DemoTaskId=1,Description="Step 2", Id=2, Name="Step"}
            };
        }

        [Test]
        public async Task CreateAsyncWhenCalled_ReturnOk()
        {
            //Arrange
            var expected = this.mockSteps.First();
            this.BlController.CreateAsync(Arg.Any<Step>()).Returns(default(int));
            var controller = new StepsController(this.BlController);

            //Act
            var result = await controller.CreateAsync(expected);

            //Assert
            ((ObjectResult)result.Result).StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}