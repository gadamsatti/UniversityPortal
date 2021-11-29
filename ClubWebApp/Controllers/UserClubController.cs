using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySharedDatabase.Models;

namespace ClubWebApp.Controllers
{
    [Route("api/[controller]/[action]")]
   /* [Authorize]*/
    [ApiController]
    public class UserClubController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        //User Can Register For Club.By Default Designation Is NA
        [HttpPost]
        public async Task<IActionResult> AddUserClubDetails([FromBody]UserClub userClub)
        {
            /*userClub.DesgId = 1;*/
             _context.UserClubs.Add(userClub);

            await _context.SaveChangesAsync();

            return Ok(userClub);
        }

        


        //Admin Can Delete User from Club or User Can Leave Club
        [HttpDelete]
        [Route("{clubId}")]
        public async Task<IActionResult> DeleteUserClubDetails([FromRoute]int clubId,int userId)
        {
            try
            {
                var userClubDetails = await _context.UserClubs.Where(c => c.UserId == userId && c.ClubId ==clubId).FirstOrDefaultAsync();
                 _context.UserClubs.Remove(userClubDetails);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception)
            {
                throw new Exception("User not registered for the club");
            }
        }




        //Admin Can See All The Club Members Using ClubId
        [HttpGet]
        [Route("{ClubId}")]
        public async Task<IActionResult> GetAllUsersByClubId([FromRoute] int clubId)
        {
            var clubMembers = await _context.UserClubs.Where(e=>e.ClubId==clubId).ToListAsync();
            return Ok(clubMembers);
        }

    }
}
