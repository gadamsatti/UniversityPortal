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
    [ApiController]
    public class UserGrievanceController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        // Grievance can Created By user
        [HttpPost]
        public async Task<IActionResult> CreateUserGrievance([FromBody]UserGrievance userGrievance)
        {
           

            //userGrievance.Date = DateTime.Now;


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

        //Admin do reply for user Grievance and update status Date resolution time and reply
        [HttpPut]
        [Route("{refrenceId}")]
        public async Task<IActionResult> ReplyUserGrievance(int refrenceId,UserGrievance userGrievance)
        {
            var userGrievanceDetails = await _context.UserGrievances.FindAsync(refrenceId);

            userGrievanceDetails.Reply = userGrievance.Reply;

            userGrievanceDetails.StatusId = userGrievance.StatusId;

            userGrievanceDetails.ResolutionDate = userGrievance.ResolutionDate;

            await _context.SaveChangesAsync();

            return Ok(refrenceId);
        }


        // Admin Update user Grievance Status I think No need
       /* [HttpPut]
        [Route("{status}")]
        public async Task<IActionResult>  UpdateUserGrievanceStatus(string status)
        {
            var userGrievanceDetails = await _context.UserGrievances.FindAsync(refrenceId);
        }*/
    }
}
