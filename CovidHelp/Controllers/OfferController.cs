using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
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
        public IActionResult Index()
        {
            return View();
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

            // @TODO use userId session variable
            _offerRepository.InsertOffer(offer, 3);

            return View();

        }
    }
}
