using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdamBednorzZadanieDomowe6.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdamBednorzZadanieDomowe6.Controllers
{
    public class LendGameController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
    }
}
