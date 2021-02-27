using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdamBednorzZadanieDomowe6.Repositories.Interfaces;
using AdamBednorzZadanieDomowe6.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdamBednorzZadanieDomowe6.Controllers
{
    /// <summary>
    /// logika zakładek związanych z obsługą kont klienta
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// kienci do obslugi 
        /// </summary>
        private IClientsRepository _clientsRepository;

        /// <summary>
        /// konstruktor parametryczny wykorzystujący wstrzykiwanie zależności
        /// </summary>
        /// <param name="clientsRepository"></param>
        public AccountController(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        /// <summary>
        /// logika zakładki do logowania przed logowaniem
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// logika zakładki po logowaniu
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(ClientViewModel clientData)
        {
            string firstName = clientData.FirstName;
            string lastName = clientData.LastName;
            string password = clientData.Password;

            if(_clientsRepository.SignIn(firstName, lastName, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("LoginError");
            }
        }
    }
}
