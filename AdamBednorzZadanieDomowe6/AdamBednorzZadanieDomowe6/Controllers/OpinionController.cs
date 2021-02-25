using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdamBednorzZadanieDomowe6.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdamBednorzZadanieDomowe6.Controllers
{
    public class OpinionController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
    }
}
