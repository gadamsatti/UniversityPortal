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


        //this is to generate report of the event
        [HttpGet]
        [Route("{filter}")]
        public async Task<IActionResult> GetAllEvents(string filter)
        {
            if (filter == "Montly")
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


        [HttpGet]
        [Route("{eventId}")]
        public async Task<IActionResult> GetEventById(int eventId)
        {

          var eventDetail = await  _context.Events.Where(e => e.EventId == eventId).FirstOrDefaultAsync();
            return Ok(eventDetail);
        }

    }
}
