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
    public class UserServiceController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        //User Register For Service but No Of volunteers in service can't be Exceed.
        [HttpPost]
        public async Task<IActionResult> CreateUserService(UserService userService)
        {

            var service = await _context.Services.Where(s => s.ServiceId == userService.ServiceId).FirstOrDefaultAsync();


            var userServiceVolunteerCount = _context.UserServices.Where(u => u.ServiceId == userService.ServiceId).Count();

            if (userServiceVolunteerCount < service.VolunteerCount  )
            {
                _context.UserServices.Add(userService);

                await _context.SaveChangesAsync();
                
                return Ok(userService);
                
            }

            return Ok("Volunteer limit Exceed");


        }

    }
}
