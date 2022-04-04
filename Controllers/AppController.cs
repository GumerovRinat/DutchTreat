using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            //throw new InvalidProgramException("Bad things happen to good developers");
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContacViewModel model)
        {
            if(ModelState.IsValid)
            {
                //Send
                _mailService.SendMessage("koyen@yandex.ru", model.Subject, $"From : {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Email Sent";
                ModelState.Clear();
            }
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }
    }
}
