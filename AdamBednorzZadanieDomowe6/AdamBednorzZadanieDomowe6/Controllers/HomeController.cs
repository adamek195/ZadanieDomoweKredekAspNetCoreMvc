using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdamBednorzZadanieDomowe6.Models;
using AdamBednorzZadanieDomowe6.Repositories;
using AdamBednorzZadanieDomowe6.Repositories.Interfaces;

namespace AdamBednorzZadanieDomowe6.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Gry do wyświetlenia 
        /// </summary>
        private IGamesRepository _gamesRepository;

        
        public HomeController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        //logika główengo menu
        public IActionResult Index()
        {
            return View(this._gamesRepository.GetGames());
        }
  

        //logika strony do wyświetlania informacji o fifie
        public IActionResult InformationOfFifa()
        {
            return View();
        }

        //logika strony do wyświetlania informacji o gta
        public IActionResult InformationOfGta()
        {
            return View();
        }

        //logika strony do wyświetlania informacji o gta
        public IActionResult InformationOfMassEffect()
        {
            return View();
        }

        //logika strony do wyświetlania informacji o gta
        public IActionResult InformationOfNba()
        {
            return View();
        }

        //logika strony do wyświetlania informacji o gta
        public IActionResult InformationOfSims()
        {
            return View();
        }

        //logika strony do wyświetlania informacji o gta
        public IActionResult InformationOfStarWars()
        {
            return View();
        }

        //logika strony z opisami gier
        public IActionResult GetListOfNames()
        {
            return View(this._gamesRepository.GetGamesNames());
        }

        //logika strony, ktora wybiera nam konkretny model gry
        public IActionResult GetGameByName(string selectedGame)
        {
            return View((this._gamesRepository.GetGameByName(selectedGame)));
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
