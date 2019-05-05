using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBAssignemnt.Models;
using Microsoft.AspNetCore.Mvc;

namespace HBAssignemnt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExplorationController : ControllerBase
    {
        
        [HttpPost]
        public async Task<IActionResult> ExploreMars([FromBody] InputModel input)
        {
            try
            { 
            Plateu plateu = new Plateu(input.SizeX, input.SizeY);
            foreach(var commandSet in input.CommandSets)
            {
                Rover rover = new Rover(commandSet.DeployLocation.X, commandSet.DeployLocation.Y, commandSet.DeployLocation.Orientation);
                plateu.DeployRover(rover);
                rover.ProcessCommand(commandSet.Command);
                //Bazı ek kontroller için eklemiştim, assigment ta gerek olmadığı için kapattım. Map kısmı zaten kullanılmayacak.
                //plateu.UpdateMap();
            }

            OutputModel output = new OutputModel();
            foreach(var rover in plateu.Rovers)
            {
                output.statutes.Add(new RoverStatus()
                {
                    X = rover.XLocation,
                    Y = rover.YLocation,
                    orientation = rover.Orientation
                });
            }
            return Ok(output);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

     
    }
}
