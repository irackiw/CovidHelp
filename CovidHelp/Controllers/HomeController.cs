﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CovidHelp.Models;
using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;

namespace CovidHelp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IOfferRepository _offerRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IOfferRepository offerRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _offerRepository = offerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Test()
        {
            var xd = _userRepository.GetUser(1);
            return View("Index");
        }

        public ActionResult InsertTest()
        {
            var user = new User
            {
                CreatedAt = DateTime.Now,
                FirstName = "Adam",
                Email = "asd@dsagf.cas",
                LastName = "wweda",
                Pesel = 1231234
            };
            var xd = _userRepository.InsertUser(user);
            return View("Index");
        }

        public ActionResult GetUserModel()
        {
            var user = _userRepository.GetUser(1);
            var userOffers = _offerRepository.GetOffersByUserId((int) user.Id);
            //Tutaj bedzie mapper, narazie mozesz budowac ten model recznie
            var userModel = new UserModel
            {
                Email = user.Email,
                Id = (int) user.Id,
                Name = $"{user.FirstName} {user.LastName}",
                Pesel = user.Pesel,
                UserOffers = userOffers
            };
            return View("Index");
        }
    }
}
