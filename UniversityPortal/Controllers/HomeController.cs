using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniversityPortal.Models;
using UniversityPortal.Service;

namespace UniversityPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        //For Object Passing Purpose
       
       private readonly SignInManager<ApplicationUser> _signInManager;





        static HttpClient svc = new HttpClient();

        static string baseUrlEventWebApp = "http://localhost:5002/api/";
        static string baseUrlClubWebApp = "http://localhost:5001/api/";

        public HomeController(ILogger<HomeController> logger,IUserService userService, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userService = userService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            //Getting UserId
            var userId = _userService.GetUserId();

            //Cheking User Loged in 

            var isLoggedIn = _userService.IsAuthenticated();

            return View();
        }

       
     //------------------------------------clubs ----------------------------------------------------------

        public async Task<IActionResult> Clubs()
        { 

            var items = await svc.GetFromJsonAsync<List<Club>>(baseUrlClubWebApp + "Club/GetAllClubDetails");
            return View(items);
        }


        public async Task<IActionResult> ClubStudents(int clubId)
        {

            var items = await svc.GetFromJsonAsync<List<UserClubModel>>(baseUrlClubWebApp + "UserClub/GetAllUsersByClubId/" + clubId);
            return View("ClubStudents",items);
        }
        /*[Authorize(Roles = "Admin")]*/

        public ViewResult CreateClub()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateClub(Club club)
        {
            if (ModelState.IsValid)
            {

                var item = svc.PostAsJsonAsync(baseUrlClubWebApp + "Club/CreateClubDetails", club);
                item.Wait();

                var output = item.Result;
                if (output.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid Deatils");

            return View(club);
        }


        [HttpGet]
        public async Task<IActionResult> RegisterForClub(int clubId)
        {

            string userId = User.FindFirst("UserId").Value.ToString();
            int employeeId = Int32.Parse(userId);
            var model = new UserClubModel();
            model.ClubId = clubId;
            model.UserId = employeeId;
            model.DesgId = await svc.GetFromJsonAsync<int>(baseUrlClubWebApp + "UserClub/GetDesignationId/NA");
            var item = svc.PostAsJsonAsync(baseUrlClubWebApp + "UserClub/AddUserClubDetails", model);
            item.Wait();

            var output = item.Result;
            if (output.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        
        public async Task<IActionResult> DeleteClub(int clubId)
        {
            var result = await svc.DeleteAsync(baseUrlClubWebApp+"Club/DeleteClubDeatils/" + clubId);
            return RedirectToAction("Clubs");
        }

        public  IActionResult RemoveStudent(int UserClubRegId)
        {
            var result = svc.DeleteAsync(baseUrlClubWebApp + "UserClub/DeleteUserClubDetails/" + UserClubRegId);
            result.Wait();

            return RedirectToAction("Clubs");
        }

        public ViewResult EditClub()
        {

            return View();
        }

       // -----------------------------------------------------------event -----------------------------



        public async Task<ActionResult> Events()
        {
           var allEvents= await svc.GetFromJsonAsync<List<Event>>(baseUrlEventWebApp + "Event/GetAllEvents");
            return View(allEvents);
        }

        //worst naming convestion 
        public ActionResult Event()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Event(Event eventViewModel)
        {
            eventViewModel.TotalAttendedStudents = 0;
            if (ModelState.IsValid)
            {
                var item = svc.PostAsJsonAsync(baseUrlEventWebApp + "Event/CreateEvent", eventViewModel);
                item.Wait();

                var output = item.Result;
                if (output.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid Deatils");

            return View(eventViewModel);

        }

       /* List<Service> services = new List<Service>() { };*/

        public ActionResult Services()
        {
            return View();
        }

    }
}
