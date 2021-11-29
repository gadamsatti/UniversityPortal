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
    [Authorize]
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



        //Admin can reply for user Grievance
        [HttpGet]
        [Route("{refrenceId}/{reply}")]
        public async Task<IActionResult> ReplyUserGrievance(int refrenceId,string reply)
        {
            var userGrievanceDetails = await _context.UserGrievances.FindAsync(refrenceId);

            userGrievanceDetails.Reply = reply;

            await _context.SaveChangesAsync();

            return Ok(userGrievanceDetails);
        }


        // Admin Update user Grievance Status
        [HttpGet]
        [Route("{status}/{referenceId}")]
        public async Task<IActionResult> UpdateUserGrievanceStatus(string status,int referenceId)
        {
            var userGrievanceDetails = await _context.UserGrievances.FindAsync(referenceId);
            userGrievanceDetails.StatusId = await _context.StatusFeilds.Where(s => s.Status == status).Select(s => s.StatusId).FirstOrDefaultAsync();
            await _context.SaveChangesAsync();
            return Ok(userGrievanceDetails);
        }
    }
}
