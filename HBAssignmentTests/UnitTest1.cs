using FluentAssertions;
using HBAssignemnt.Controllers;
using HBAssignemnt.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace HBAssignmentTests
{
    public class UnitTest1
    {
        ExplorationController _controller;

        [Fact]
        public void Test1()
        {
            _controller = new ExplorationController();
            var input = new InputModel
            {
                SizeX = 5,
                SizeY = 5,
            };
            RoverCommandsModel command1 = new RoverCommandsModel
            {
                DeployLocation = new DeploymentModel { X = 1, Y = 2, Orientation = Orientations.N },
                Command = "LMLMLMLMM"
            };
            RoverCommandsModel command2 = new RoverCommandsModel
            {
                DeployLocation = new DeploymentModel { X = 3, Y = 3, Orientation = Orientations.E },
                Command = "MMRMMRMRRM"
            };
            input.CommandSets = new List<RoverCommandsModel>();
            input.CommandSets.Add(command1);
            input.CommandSets.Add(command2);
            var output = _controller.ExploreMars(input);
            Assert.IsType<OkObjectResult>(output.Result);

            var okObjectResult = output.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var outputModel = okObjectResult.Value as OutputModel;
            Assert.NotNull(outputModel);

            var expectedResult = new OutputModel();
            expectedResult.statutes = new List<RoverStatus>();
            var status1 = new RoverStatus { X = 1, Y = 3, orientation = Orientations.N };
            var status2 = new RoverStatus { X = 5, Y = 1, orientation = Orientations.E };
            expectedResult.statutes.Add(status1);
            expectedResult.statutes.Add(status2);
            Assert.Equal(2, outputModel.statutes.Count);
            expectedResult.Should().BeEquivalentTo(outputModel);
        }
    }
}
