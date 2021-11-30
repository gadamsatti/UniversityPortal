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
    //[Authorize]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();



        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
           var ListOfServices =await _context.Services.ToListAsync();
            return Ok(ListOfServices);
        }

        // Create New Service By Admin

        [HttpPost]

        public async Task<IActionResult> CreateService([FromBody]Service service)
        {
            _context.Services.Add(service);

            await _context.SaveChangesAsync();

            return Ok(service);
        }

        // Admin can Update Service Details By serviceId

        [HttpPut]
        [Route("{serviceId}")]
        public async Task<IActionResult> UpdateServiceDetails(int serviceId,Service service)
        {
            var serviceObject = await _context.Services.FindAsync(serviceId);

            serviceObject.ServiceName = service.ServiceName;
            serviceObject.BeginDate = service.BeginDate;
            serviceObject.VolunteerCount = service.VolunteerCount;
            await _context.SaveChangesAsync();

            return Ok(service);
        }

        //Get All Services Monthly,Halfyearly,Yearly

        [HttpGet]
        [Route("{filter}")]
        public async Task<IActionResult> GetAllServices(string filter)
        {
            if (filter == "Montly")
            {
                var thisMonth = DateTime.Now.Month;
                var serviceList = await _context.Services.Where(s => s.BeginDate.Month == thisMonth).ToListAsync();
                return Ok(serviceList);
            }
            else if (filter == "HalfYearly")
            {
                var beforeSixMonths = DateTime.Now.AddMonths(-6).Month;
                var serviceList = await _context.Services.Where(s => s.BeginDate.Month >= beforeSixMonths).ToListAsync();
                return Ok(serviceList);
            }
            else if (filter == "Yearly")
            {
                var beforeOneYear = DateTime.Now.AddMonths(-12).Month;
                var serviceList = await _context.Services.Where(s => s.BeginDate.Month >= beforeOneYear).ToListAsync();
                return Ok(serviceList);
            }
            else
            {
                return Ok("Invalid Input");
            }
        }


    }
}
