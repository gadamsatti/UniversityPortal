using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySharedDatabase.Models;

namespace EventWebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class EventController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        //creating an event by admin

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody]Event eventData)
        {
            _context.Events.Add(eventData);
            await _context.SaveChangesAsync();
            return Ok(eventData);
        }


        //deleted event by admin using event id
        [HttpDelete]
        [Route("{eventId}")]
        public async Task<IActionResult> DeleteEvent([FromRoute]int eventId)
        {
            var eventObj = await _context.Events.Where(e => e.EventId == eventId).FirstOrDefaultAsync();
            _context.Events.Remove(eventObj);
            await _context.SaveChangesAsync();
            return Ok(eventId);
        }


        //this is to generate report of the event for admin
        [HttpGet]
        [Route("{filter}")]
        public async Task<IActionResult> GetAllEvents(string filter)
        {
            if (filter == "Monthly")
            {
                var thisMonth = DateTime.Now.Month;
                var eventList = await _context.Events.Where(e => e.StartDate.Month == thisMonth).ToListAsync();
                return Ok(eventList);
            }
            else if (filter == "HalfYearly")
            {
                var beforeSixMonths = DateTime.Now.AddMonths(-6).Month;
                var eventList = await _context.Events.Where(e => e.StartDate.Month >= beforeSixMonths).ToListAsync();
                return Ok(eventList);
            }
            else if (filter == "Yearly")
            {
                var beforeOneYear = DateTime.Now.AddMonths(-12).Month;
                var eventList = await _context.Events.Where(e => e.StartDate.Month >= beforeOneYear).ToListAsync();
                return Ok(eventList);
            }
            else {
                return Ok("Invalid Input");
            }



        }


        //Get Event By EventId DOUT
        [HttpGet]
        [Route("{eventId}")]
        public async Task<IActionResult> GetEventById([FromRoute]int eventId)
        {

          var eventDetail = await  _context.Events.Where(e => e.EventId == eventId).FirstOrDefaultAsync();
            return Ok(eventDetail);
        }

        //Search For Event Using EventName
        [HttpGet]
        [Route("{eventName}")]
        public async Task<IActionResult> GetEventByName(string eventName)
        {
            var eventDetail = await _context.Events.Where(e => e.EventName.Contains(eventName)).ToListAsync();

            return Ok(eventDetail);
        }


        //GetEvents Between Given Dates Dates
        [HttpGet]
        [Route("{startDate}/{endDate}")]
        public async Task<IActionResult> GetEventDate(DateTime startDate, DateTime endDate)
        {
            var events=await _context.Events.Where(e => e.StartDate >= startDate && e.StartDate <= endDate).ToListAsync();
            return Ok(events);
        }


        // feature Not Added in Data base 
        //Get All Events By Category
        [HttpGet]
        [Route("{category}")]
        public async Task<IActionResult> GetAllEventsByCategory(string category)
        {
          var eventList = await _context.Events.Where(e => e.Category == category).ToListAsync();
            return Ok(eventList);
        }



        
        //Update Event Attendence
        [HttpGet]
        [Route("{eventId}")]
        public async Task<IActionResult> UpdateAttendes(int eventId)
        {
           var eventObj =await _context.Events.Where(e => e.EventId == eventId).FirstOrDefaultAsync();
            eventObj.TotalAttendedStudents = +1;
           await _context.SaveChangesAsync();
            return Ok(eventObj.TotalAttendedStudents);
        }





    }
}
