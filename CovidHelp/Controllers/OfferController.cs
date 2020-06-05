using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
using CovidHelp.Models.Offer;
using Microsoft.AspNetCore.Mvc;


namespace CovidHelp.Controllers
{

    public class OfferController : Controller
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public OfferController(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateModel offerCreateModel)
        {

            var offer = _mapper.Map<Offer>(offerCreateModel);
            offer.CreatedAt = DateTime.Now;
            // _offerRepository.InsertOffer(offer);
            return View();

        }
    }
}
