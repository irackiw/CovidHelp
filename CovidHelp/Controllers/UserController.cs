using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
using CovidHelp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidHelp.Controllers
{    
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;


        public UserController(IUserRepository userRepository, IMapper mapper, IOfferRepository offerRepository)
        {
            _userRepository = userRepository;
            _offerRepository = offerRepository;
            _mapper = mapper;
        }


        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize("Logged")]
        public IActionResult Detail()
        {
            var userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("Id")).Value);
            var user = _userRepository.GetUser(userId);
            var userModel = _mapper.Map<UserModel>(user);
            userModel.UserOffers = _offerRepository.GetUserOffersByUserId((int) user.Id);
            userModel.UserAppliedOffer = _offerRepository.GetUserAppliedOffersByUserId((int) user.Id);

            return View("Detail", userModel);
        }

        [Authorize("Admin")]
        public IActionResult AdminDetail(int userId)
        {
            var user = _userRepository.GetUser(userId);
            var userModel = _mapper.Map<UserModel>(user);
            return View("Detail", userModel);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRegisterModel userRegisterModel)
        {

            var user = _mapper.Map<User>(userRegisterModel);
            _userRepository.InsertUser(user);

            try
            {
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: UserController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            var userLogin = _mapper.Map<UserLogin>(userLoginModel);

            User user = _userRepository.Login(userLogin);
            if(null == user)
            {
                userLoginModel.validationError = true;
                return View(userLoginModel);
            }
            await Authenticate(user);

            return RedirectToAction("Detail");
        }

        public async Task Authenticate(User user)
        {
            var covidClaims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("Admin",user.IsAdmin.ToString())
            };

            var covidIdentity = new ClaimsIdentity(covidClaims);
            var userPrincipal = new ClaimsPrincipal(new [] {covidIdentity});
            HttpContext.User = userPrincipal;
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

        }

        public async Task<ActionResult> LouOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


        public ActionResult Login()
        {
            return View();
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        [Authorize("Admin")]
        public ActionResult AdminPanel()
        {
            var xd = HttpContext;
            return View("AdminPanel");
        }
       
    }
}
