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
    [ApiController]
    public class UserClubController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        //User Can Register For Club.By Default Designation Is NA
        [HttpPost]
        public async Task<IActionResult> AddUserClubDetails([FromBody]UserClub userClub)
        {
            /*userClub.DesgId = 1;*/
            await _context.AddAsync(userClub);

            await _context.SaveChangesAsync();

            return Ok(userClub);
        }

        
        //Admin Can Delete User from Club or User Can Leave Club
        [HttpDelete]
        [Route("{clubId}")]
        public async Task<IActionResult> DeleteUserClubDetails([FromRoute]int clubId)
        {
            try
            {
                var userClubDetails = await _context.UserClubs.FindAsync(clubId);

                 _context.UserClubs.Remove(userClubDetails);

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception)
            {
                throw;
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
