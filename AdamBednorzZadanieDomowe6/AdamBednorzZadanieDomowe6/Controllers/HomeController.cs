using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdamBednorzZadanieDomowe6.Models;

namespace AdamBednorzZadanieDomowe6.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Gry do wyświetlenia 
        /// </summary>
        List<GameViewModel> allGames;

        public HomeController()
        {
            this.allGames = new List<GameViewModel>();
            allGames.Add(new GameViewModel("Fifa", "EA Sports", 50, "~/images/fifa.png"));
            allGames.Add(new GameViewModel("Gta", "Rockstar Games", 30, "~/images/gta.png"));
            allGames.Add(new GameViewModel("Mass Effect", "BioWare", 35, "~/images/masseffect.png"));
            allGames.Add(new GameViewModel("NBA", "Visual Concepts", 50, "~/images/nba.png"));
            allGames.Add(new GameViewModel("Sims", "Maxis", 25, "~/images/sims.png"));
            allGames.Add(new GameViewModel("Star Wars", "Lucas Arts", 30, "~/images/starwars.png"));
        }

        //logika główengo menu
        public IActionResult Index()
        {
            return View();
        }

        //logika strony do wyświetlenia gier
        public IActionResult GetAllGames()
        {
            return View(this.allGames);
        }

        //logika strony do wyświetlania informacji o grach
        public IActionResult InformationOfGames()
        {
            return View();
        }

        //logika strony z opisami gier
        public IActionResult GetListOfNames()
        {
            List<string> allNames = new List<string>();

            foreach (var game in allGames)
            {
                allNames.Add(game.Name);
            }


            return View(allNames);
        }

        //logika strony, ktora wybiera nam konkretny model gry
        public IActionResult GetGameByName(string selectedGame)
        {
            var game = allGames.Where(a => a.Name.ToLower() == selectedGame.ToLower()).FirstOrDefault();

            return View(game);
        }

        // Strona do wypozyczania przed kliknieciem wypozyczenia
        [HttpGet]
        public IActionResult LendGame()
        {
            return View();
        }

        //strona wyswietlajaca sie po wypozyczeniu
        [HttpPost]
        public IActionResult LendGame(ClientViewModel clientData)
        {
            string fullName = clientData.FirstName + " " + clientData.LastName;
            ViewBag.ClientName = fullName;
            ViewBag.ClientPhone = clientData.PhoneNumber;
            ViewBag.ClientGame = clientData.Game;
            return View("LentGame");
        }

        //strona wyswietlajaca się przed przeslaniem opini
        [HttpGet]
        public IActionResult SendOpinion()
        {
            return View();
        }

        //strona wyswietlajaca sie po przeslaniu opinii
        [HttpPost]
        public IActionResult SendOpinion(ContactFormViewModel userOpinion)
        {
            ViewBag.UserName = userOpinion.FirstName + " " + userOpinion.LastName;
            ViewBag.UserOpinion = userOpinion.Description;
            return View("SentOpinion");
        }

        //wyswietlanie informacji o firmie
        public IActionResult Contact()
        {
            //dane wypozyczalni
            TempData["Name"] = "Wypożyczalnia Optimus";
            TempData["Street"] = "Kwiatkowska 45";
            TempData["PhoneNumber"] = "111222333";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
