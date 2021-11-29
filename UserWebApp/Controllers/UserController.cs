using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySharedDatabase.Models;

namespace UserWebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        //User Can SignUp 
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok();
        }


        //GetUser by userId
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute]int userId)
        {
           var userDetail = await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();

            return Ok(userDetail);
        }


        //User Can Update Details 
        
        [HttpGet]
        [Route("{userId}/{password}")]
        public async Task<IActionResult> UpdateUserDetails([FromRoute]int userId,[FromRoute]string password)
        {
            var getUserDetails = await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();

            getUserDetails.Password = password;

            await _context.SaveChangesAsync();

            return Ok("Password Reset Sucessfully");

        }

    }
}
