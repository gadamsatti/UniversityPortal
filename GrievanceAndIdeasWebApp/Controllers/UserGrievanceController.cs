using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySharedDatabase.Models;

namespace GrievanceAndIdeasWebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class UserGrievanceController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();



        // Grievance can Created By user
        [HttpPost]
        public async Task<IActionResult> CreateUserGrievance([FromBody]UserGrievance userGrievance)
        {
          
             _context.UserGrievances.Add(userGrievance);
            await _context.SaveChangesAsync();

            return Ok(userGrievance);
        }


        //Get All Grievance For Admin

        [HttpGet]
        public async Task<IActionResult> GetAllGrievances()
        {
            var userGrievanceDetails = await _context.UserGrievances.ToListAsync();

            return Ok(userGrievanceDetails);


        }

        [HttpGet]
        public async Task<IActionResult> GetAllGrievanceName()
        {
            var userGrievances = await _context.Grievances.ToListAsync();

            return Ok(userGrievances);


        }
        [HttpGet]
        public async Task<IActionResult> GetAllstatusName()
        {
            var userStatus = await _context.StatusFeilds.ToListAsync();

            return Ok(userStatus);


        }

        //Admin can reply for user Grievance
        [HttpGet]
        [Route("{refrenceId}")]
        public async Task<IActionResult> GetUserGravienceByID(int refrenceId)
        {
            var userGrievanceDetails = await _context.UserGrievances.FindAsync(refrenceId);
            return Ok(userGrievanceDetails);
        }


        // Admin Update user Grievance Status
        [HttpPut]
        [Route("{referenceId}")]
        public async Task<IActionResult> UpdateUserGrievance(UserGrievance userGrievance,int referenceId)
        {
            var userGrievanceDetails = await _context.UserGrievances.FindAsync(referenceId);
            userGrievanceDetails.StatusId = userGrievance.StatusId;
            userGrievanceDetails.Reply = userGrievance.Reply;
            await _context.SaveChangesAsync();
            return Ok(userGrievanceDetails);
        }
    }
}
