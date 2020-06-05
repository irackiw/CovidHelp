using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IOfferRepository offerRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _offerRepository = offerRepository;
            _mapper = mapper;
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

        

        //public ActionResult GetUserModel()
        //{
        //    var user = _userRepository.GetUser(1);
        //    var userOffers = _offerRepository.GetUserOffersByUserId((int) user.Id);
        //    var userModel = _mapper.Map<UserModel>(user);
        //  //  userModel.UserOffers = userOffers;

        //    //return View("Index");
        //}

        public ActionResult InsertUserOffer()
        {
            var offer = new Offer
            {
                City = "wwa",
                CreatedAt = DateTime.Now,
                Description = "jadajdadajdajd",
                Title = "raz",
                ValidTo = DateTime.Now
            };
            _offerRepository.InsertOffer(offer, 1);

            return View("Index");
        }

        public ActionResult InsertUserAppliedOffer()
        {

            return View("Index");
        }

        public ActionResult InsertUser()
        {
            var userModel = new UserModel
            {
                Email = "xdxd2@wwp.sd",
                Name = "Adam Wrosd",
                Pesel = 123456,
                CreatedAt = DateTime.Now
            };

            var user = _mapper.Map<User>(userModel);
            _userRepository.InsertUser(user) ;

            return View("Index");
        }

        public ActionResult UpdateUser(UserModel userModel)
        {

            return View("Index");
        }
    }
}
