using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdamBednorzZadanieDomowe6.Repositories.Interfaces;
using AdamBednorzZadanieDomowe6.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdamBednorzZadanieDomowe6.Controllers
{
    public class LendGameController : Controller
    {
        /// <summary>
        /// Zamowienia 
        /// </summary>
        IOrdersRepository _ordersRepository;

        /// <summary>
        /// kontruktor parametryczny wykorzystujacy wstrzykiwanie zależnosci
        /// </summary>
        /// <param name="ordersRepository"></param>
        public LendGameController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
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
            string firstName = clientData.FirstName;
            string lastName = clientData.LastName;
            string password = clientData.Password;
            string gameName = clientData.Game;

            if(_ordersRepository.AddOrder(firstName,lastName,password,gameName))
            {
                ViewBag.ClientName = firstName + lastName;
                ViewBag.ClientGame = gameName;
                ViewBag.ClientOrder = "Wypożyczyłeś grę. Dziękujemy.";
            }
            else
            {
                ViewBag.ClientName = "-";
                ViewBag.ClientGame = "-";
                ViewBag.ClientOrder = "Niestety nie udało się, sprawdź czy wpisujesz dobre dane!";
            }
            return View("LentGame");
        }
    }
}
