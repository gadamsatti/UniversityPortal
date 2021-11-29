using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniversityPortal.Models;
using UniversityPortal.Repository;


namespace UniversityPortal.Controllers
{
    public class AccountController : Controller
    {
        //For Object Passing Purpose
        static HttpClient svc = new HttpClient();

        static string baseUrlUserWebApp = "http://localhost:5004/";
        /*"http://localhost:53892"*/

        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {

            if(ModelState.IsValid)
            {
                //Write Code
                var result = await _accountRepository.CreateUserAsync(userModel);

                if(!result.Succeeded)
                {
                   foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(userModel);
                }

                if(result.Succeeded)
                {
                    User user = new User()
                    {
                        UserId = userModel.UserId,
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        UserName = userModel.FirstName +" "+ userModel.LastName,
                        Dob=userModel.DateOfBirth,
                        PhoneNo=userModel.ContactNo.ToString(),
                        Email=userModel.Email,
                        Password=userModel.Password
                    };

                    var item  =await svc.PostAsJsonAsync(baseUrlUserWebApp + "api/User/CreateUser",user);

                    //var data = await svc.GetFromJsonAsync<User>(baseUrlUserWebApp + "api/User/GetUserById/1170");




                }

                ModelState.Clear();
            }
            return View();
        }


        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //Write Code
                var result = await _accountRepository.PasswordSignInAsync(signInModel);

                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }



                ModelState.AddModelError("","Invalid Credentials");
            }
            return View();
        }


        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            await _accountRepository.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }



    }
}
