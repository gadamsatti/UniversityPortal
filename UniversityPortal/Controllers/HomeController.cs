using Microsoft.AspNetCore.Authorization;
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

        public HomeController(ILogger<HomeController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        static HttpClient svc = new HttpClient();


        public IActionResult Index()
        {
            //Getting UserId
            var userId = _userService.GetUserId();

            //Cheking User Loged in 

            var isLoggedIn = _userService.IsAuthenticated();



            return View();
        }

       


        public static List<Club> data = new List<Club>()
            {
                new Club{ClubId=3,ClubName="YCM",Details="Games Club",Eligibility="Member Of Student Council"},
                new Club{ClubId=4,ClubName="Spade",Details="Quiz Club",Eligibility="Member Of Student Council"}

            };

        public IActionResult Clubs()
        {





            //await svc.GetFromJsonAsync<List<Club>>("http://localhost:5001/api/Club/GetAllClubDetails");

            //var item = data;
            return View(data);
        }



        /*[Authorize(Roles = "Admin")]*/

        public ViewResult CreateClub()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateClub(Club club)
        {
            if (ModelState.IsValid)
            {
                //Write Code
                var result = await svc.PostAsJsonAsync("http://localhost:5001/api/Club/CreateClubDetails", club);


                return RedirectToAction("Clubs");

            }

            ModelState.AddModelError("", "Invalid Deatils");

            return View(club);
        }


        public async Task<IActionResult> DeleteClub(int clubId)
        {
            var result = await svc.DeleteAsync("http://localhost:5001/api/Club/DeleteClubDeatils/{clubId}");

            return RedirectToAction("Clubs");
        }

        public ViewResult EditClub()
        {

            return View();
        }


        List<Event> events = new List<Event>()
        {
            new Event{EventId =1,EventName="Quiz",StartDate=DateTime.Now,EndDate=new DateTime(2021,12,1),Category="game",ClubId=1,TotalAttendedStudents=10 },
            new Event{EventId =2,EventName="Pubg",StartDate=DateTime.Now,EndDate=new DateTime(2021,12,1),Category="game",ClubId=1,TotalAttendedStudents=20 }
        };



        public ActionResult Events()
        {
            return View(events);
        }


        public ActionResult Event()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Event(Event eventViewModel)
        {
            return View(eventViewModel);
        }

       /* List<Service> services = new List<Service>() { };*/

        public ActionResult Services()
        {
            return View();
        }

    }
}
