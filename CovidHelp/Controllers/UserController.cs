using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
using CovidHelp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidHelp.Controllers
{    
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
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
        public ActionResult Login(UserLoginModel userLoginModel)
        {

            User user = _userRepository.Login(userLoginModel);
            if(null == user)
            {
                userLoginModel.validationError = true;
                return View(userLoginModel);
            }

            HttpContext.Session.SetString("UserID", user.Id.ToString());
            HttpContext.Session.SetString("UserFirstname", user.FirstName.ToString());

            return Redirect("/");
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
    }
}
