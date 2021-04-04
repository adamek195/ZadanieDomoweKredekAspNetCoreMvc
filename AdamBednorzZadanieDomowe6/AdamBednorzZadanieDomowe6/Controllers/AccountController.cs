using AdamBednorzZadanieDomowe6.Repositories.Interfaces;
using AdamBednorzZadanieDomowe6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AdamBednorzZadanieDomowe6.Controllers
{
    /// <summary>
    /// logika zakładek zwiazanych z obsługa kont klienta
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// kienci do obslugi 
        /// </summary>
        private IClientsRepository _clientsRepository;
        /// <summary>
        /// zlożone zamówienia
        /// </summary>
        private IOrdersRepository _ordersRepository;
        /// <summary>
        /// gry w wypożyczalni
        /// </summary>
        private IGamesRepository _gamesRepository;

        /// <summary>
        /// konstruktor parametryczny wykorzystujący wstrzykiwanie zależności
        /// </summary>
        /// <param name="clientsRepository"></param>
        public AccountController(IClientsRepository clientsRepository, IOrdersRepository ordersRepository, IGamesRepository gamesRepository)
        {
            _clientsRepository = clientsRepository;
            _ordersRepository = ordersRepository;
            _gamesRepository = gamesRepository;
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
            List<string> clientGames = new List<string>();
            List<int> gamesIdByClientId = new List<int>();
            int clientId;

            if(_clientsRepository.SignIn(firstName, lastName, password))
            {
                ViewBag.UserName = firstName + " " + lastName;
                clientId = _clientsRepository.GetIdByName(firstName, lastName, password);
                gamesIdByClientId = _ordersRepository.GetGamesIdByClientId(clientId);
                foreach(var id in gamesIdByClientId)
                {
                    clientGames.Add(_gamesRepository.GetGameNameById(id));
                }

                return View("Logged", clientGames);
            }
            else
            {
                return View("LoginError");
            }
        }

        /// <summary>
        /// logika zakladki przed logowaniem
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// logika zakladki po logowaniu
        /// </summary>
        /// <param name="clientData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(ClientViewModel clientData)
        {
            string firstName = clientData.FirstName;
            string lastName = clientData.LastName;
            string password = clientData.Password;
            int phoneNumber = clientData.PhoneNumber;
            if(_clientsRepository.Register(firstName,lastName, password, phoneNumber))
            {
                ViewBag.UserName = firstName + " " + lastName;
                ViewBag.UserRegister = "Rejestracja przebiegła pomyślnie.";
            }
            else
            {
                ViewBag.UserName = firstName + " " + lastName;
                ViewBag.UserRegister = "Nie udało się! Taki użytkownik już istnieje.";
            }
            return View("Registered");
        }

        /// <summary>
        /// logika zakladki do usuniecia
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        /// <summary>
        /// logika zakladki do usuwania
        /// </summary>
        /// <param name="clientData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(ClientViewModel clientData)
        {
            string firstName = clientData.FirstName;
            string lastName = clientData.LastName;
            string password = clientData.Password;
            if (_clientsRepository.Delete(firstName, lastName, password))
            {
                ViewBag.UserName = firstName + " " + lastName;
                ViewBag.UserDelete = "Udało się usunąć konto.";
            }
            else
            {
                ViewBag.UserName = firstName + " " + lastName;
                ViewBag.UserDelete = "Nie udało się! Takiego użytkownika nie ma w naszym sklepie.";
            }
            return View("Deleted");
        }
    }
}
