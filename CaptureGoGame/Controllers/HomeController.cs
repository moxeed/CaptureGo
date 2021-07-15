using CaptureGoGame.Domian;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CaptureGoGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly Game _game;

        public HomeController(Game game)
        {
            _game = game;
        }

        [Route("/")]
        public IActionResult Index()
        {
            try {
                var player = _game.RegisterPlayer();
                return View(player);
            }
            catch(Exception e)
            {
                return View("Error", e.Message);
            }
        }

        [Route("/NewGame")]
        public IActionResult NewGame()
        {
            try {
                _game.NewGame();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View("Error", e.Message);
            }
        }
    }
}
