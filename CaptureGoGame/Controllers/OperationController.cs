using CaptureGoGame.Domian;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CaptureGoGame.Controllers
{
    [Route("[controller]/[action]")]
    public class OperationController : Controller
    {
        private readonly Game _game;

        public OperationController(Game game)
        {
            _game = game;
        }

        [HttpGet("{player}/{x}/{y}")]
        public IActionResult PlaceStone(Guid player, int x, int y)
        {
            try{
                _game.PlaceStone(player, x, y);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{player}")]
        public IActionResult GameState(Guid player)
        {
            return Ok(_game.GetState(player));
        }
    }
}
