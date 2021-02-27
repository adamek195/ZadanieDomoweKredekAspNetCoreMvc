﻿using AdamBednorzZadanieDomowe6.Repositories.Interfaces;
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
