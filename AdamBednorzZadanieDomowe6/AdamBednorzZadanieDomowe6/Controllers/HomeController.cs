using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdamBednorzZadanieDomowe6.Models;
using AdamBednorzZadanieDomowe6.Repositories;

namespace AdamBednorzZadanieDomowe6.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Gry do wyświetlenia 
        /// </summary>
        GamesRepository gamesRepository;

        public HomeController()
        {
            gamesRepository = new GamesRepository();
        }

        //logika główengo menu
        public IActionResult Index()
        {
            return View();
        }

        //logika strony do wyświetlenia gier
        public IActionResult GetAllGames()
        {
            return View(this.gamesRepository.GetGames());
        }

        //logika strony do wyświetlania informacji o grach
        public IActionResult InformationOfGames()
        {
            return View();
        }

        //logika strony z opisami gier
        public IActionResult GetListOfNames()
        {
            return View(this.gamesRepository.GetGamesNames());
        }

        //logika strony, ktora wybiera nam konkretny model gry
        public IActionResult GetGameByName(string selectedGame)
        {
            return View((this.gamesRepository.GetGameByName(selectedGame)));
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
