using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
using CovidHelp.Models;
using CovidHelp.Models.Offer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CovidHelp.Controllers
{

    public class OfferController : Controller
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OfferController(IOfferRepository offerRepository, IUserRepository userRepository, IMapper mapper)
        {
          _offerRepository = offerRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        // GET: /<controller>/
        [Authorize("Logged")]
        public IActionResult Index()
        {
            var offers = _offerRepository.GetOffers();
            var offerModels = _mapper.Map<List<OfferModel>>(offers);
            return View(offerModels);
        }

        // GET: /<controller>/
        [Authorize("Logged")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("Logged")]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(CreateModel offerCreateModel)
        {
            
            var offer = _mapper.Map<Offer>(offerCreateModel);
            offer.CreatedAt = DateTime.Now;
            //nie bedzie nulla bo przeszedl autoryzacje

            var userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("Id")).Value);

            _offerRepository.InsertOffer(offer, userId);

            return View();

        }

        [HttpPost]
        [Authorize("Logged")]
        public IActionResult ApplyOffer(ApplyOfferModel model)
        {
            var userAppliedOffer = _mapper.Map<UserAppliedOffer>(model);
            _offerRepository.ApplyOffer(userAppliedOffer);
            return View();
        }

       


    }
}
