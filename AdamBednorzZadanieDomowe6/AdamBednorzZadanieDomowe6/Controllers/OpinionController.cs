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
    /// logika zakładki do przesyłania formularza
    /// </summary>
    public class OpinionController : Controller
    {
        /// <summary>
        /// Opinie
        /// </summary>
        IOpinionsRepository _opinionsRepository;

        /// <summary>
        /// konstruktor parametryczny wykorzystujacy wstrzykiwane zależności
        /// </summary>
        /// <param name="opinionsRepository"></param>
        public OpinionController(IOpinionsRepository opinionsRepository)
        {
            _opinionsRepository = opinionsRepository;
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
            string firstName = userOpinion.FirstName;
            string lastName = userOpinion.LastName;
            string password = userOpinion.Password;
            string email = userOpinion.Email;
            string message = userOpinion.Message;

            if (_opinionsRepository.AddOpinion(firstName, lastName, password, email, message))
            {
                ViewBag.UserName = firstName+ " " + lastName;
                ViewBag.UserContact = "Dziękujemy za przesłanie opinii.";
            }
            else
            {
                ViewBag.UserName = "-";
                ViewBag.UserContact = "Niestety nie udało się, sprawdź czy wpisujesz dobre dane!";
            }
            return View("SentOpinion");
        }
    }
}
