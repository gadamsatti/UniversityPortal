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
using UniversityPortal.Helper;
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
        static string baseUrlUserWebApp = "http://localhost:5004/api/";
        static string baseUrlGrievance = "http://localhost:5003/api/";
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

        public async Task<ActionResult> SortBycategory(string Category)
        {
            var categoryEvents = await svc.GetFromJsonAsync<List<Event>>(baseUrlEventWebApp + "Event/GetAllEventsByCategory/" + Category);
            return View("Events", categoryEvents);
        }

        public async Task<ActionResult> Searching(string searching)
        {
            var searchEvent = await svc.GetFromJsonAsync<List<Event>>(baseUrlEventWebApp + "Event/GetEventByName/" + searching);
            return View("Events", searchEvent);
        }
        public async Task<ActionResult> SortByDate(DateTime date1, DateTime date2)
        {
            var datestring1 = date1.ToShortDateString();
            var datestring2  = date2.ToShortDateString();
            var EventsByDate = await svc.GetFromJsonAsync<List<Event>>(baseUrlEventWebApp + "Event/GetEventDate/" + datestring1 + "/" + datestring2);

            return View("Events", EventsByDate);
        }

        public async Task<ActionResult> Eventdetails(int eventId)
        {
            EventDetailsHelper eventDetails = new EventDetailsHelper();
            eventDetails.Event = new Event();
            eventDetails.Event = await svc.GetFromJsonAsync<Event>(baseUrlEventWebApp + "Event/GetEventById/" + eventId);
            var Category = eventDetails.Event.Category;
            eventDetails.SimilarEvents = new List<Event>();
            eventDetails.SimilarEvents = await svc.GetFromJsonAsync<List<Event>>(baseUrlEventWebApp + "Event/GetAllEventsByCategory/" + Category);
            var ListOfUser = await svc.GetFromJsonAsync<List<int>>(baseUrlEventWebApp + "UserEvent/GetAllUsersByEventId/" + eventId);
            eventDetails.AllUserRegister = new List<User>();
            foreach (var userDetails in ListOfUser)
            {
                var user = new User();
                user = await svc.GetFromJsonAsync<User>(baseUrlUserWebApp + "User/GetUserById/" + userDetails);
                eventDetails.AllUserRegister.Add(user);
            }
            return View(eventDetails);
        }

        public IActionResult RegisterForEvent(int eventId)
        {

            string userId = User.FindFirst("UserId").Value.ToString();
            int employeeId = Int32.Parse(userId);
            var model = new UserEventModel();
            model.EventId = eventId;
            model.UserId = employeeId;
            var item = svc.PostAsJsonAsync(baseUrlEventWebApp + "UserEvent/CreateUserEvent", model);
            item.Wait();

            var output = item.Result;
            if (output.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //-------------------------------------------------------Services--------------------------------

        public async Task<ActionResult> AllServices()
        {
            var allServices = await svc.GetFromJsonAsync<List<ServiceModel>>(baseUrlEventWebApp + "Service/GetAllServices");
            return View(allServices);

        }
        public ActionResult CreateServices()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult CreateServices(ServiceModel serviceModel)
        {
           
            if (ModelState.IsValid)
            {
                var item = svc.PostAsJsonAsync<ServiceModel>(baseUrlEventWebApp + "Service/CreateService", serviceModel);
                item.Wait();

                var output = item.Result;
                if (output.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid Deatils");

            return View(serviceModel);
        }


        //-----------------------------------------------------------Suggestions-------------------------
        public async Task<ActionResult> AllSuggestions()
        {
            var allSuggestions = await svc.GetFromJsonAsync<List<SuggestionsModel>>(baseUrlGrievance + "UserGrievance/GetAllGrievances");
            return View(allSuggestions);
        }
        public async Task<ActionResult> CreateSuggestions()
        {
           
            ViewBag.Gravience = await SuggestionsHelper.GetAllGravience();
            return View();
        }
        [HttpPost]
        public ActionResult CreateSuggestions(SuggestionsModel suggestions)
        {
            string userId = User.FindFirst("UserId").Value.ToString();
            int employeeId = Int32.Parse(userId);
            suggestions.UserId = employeeId;
            suggestions.Date = DateTime.Now;
            suggestions.StatusId = 1;
            if (suggestions.GrievanceId == 1)
            {
                suggestions.ResolutionDate = DateTime.Now.AddDays(2);
            }
            else if (suggestions.GrievanceId == 3)
            {
                suggestions.ResolutionDate = DateTime.Now.AddDays(3);
            }
            else
            {
                suggestions.ResolutionDate = DateTime.Now.AddDays(1);
            }



            if (ModelState.IsValid)
            {
                var item = svc.PostAsJsonAsync(baseUrlGrievance + "UserGrievance/CreateUserGrievance", suggestions);
                item.Wait();

                var output = item.Result;
                if (output.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid Deatils");

            return View(suggestions);
        }

        public async Task<ActionResult> EditSuggestions(int referenceID)
        {
            var suggestions =await svc.GetFromJsonAsync<SuggestionsModel>(baseUrlGrievance + "UserGrievance/GetUserGravienceByID/"+ referenceID);
            ViewBag.Suggestions = await SuggestionsHelper.GetAllStatus();
            return View(suggestions);
        }
        [HttpPost]
        public async Task<ActionResult> EditSuggestions(SuggestionsModel suggestionsModel)
        {
             await svc.PutAsJsonAsync(baseUrlGrievance + "UserGrievance/UpdateUserGrievance/" + suggestionsModel.ReferenceId,suggestionsModel);
            return RedirectToAction("Index", "Home");
        }


    }
}
