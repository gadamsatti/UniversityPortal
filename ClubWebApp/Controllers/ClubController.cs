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
    //Only Admin do work with these controllers.
    [Route("api/[controller]/[action]")]
    /*[Authorize]*/
    [ApiController]
    public class ClubController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        //Club Added By The Admin
        [HttpPost]
        public async Task<IActionResult> CreateClubDetails([FromBody]Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();

            return Ok(club);
        }

        //Delete Club By Admin
        [HttpDelete]
        [Route("{clubId}")]
        public async Task<IActionResult> DeleteClubDeatils([FromRoute]int clubId)
        {
          
            var clubdata = await _context.Clubs.Where(e => e.ClubId == clubId).FirstOrDefaultAsync();

            try
            {
                _context.Remove(clubdata);

                await _context.SaveChangesAsync();

                return Ok(clubdata.ClubId);
            }

            catch(Exception)
            {
                throw new Exception("No clubID found");
            }
            
        }


        //Update Club Details by Admin
        [HttpPut]
        [Route("{clubId}")]
        public async Task<IActionResult> UpdateClubDetails([FromRoute]int clubId, [FromBody]Club club)
        {
            var clubdetails = await _context.Clubs.FindAsync(clubId);

            clubdetails.ClubName = club.ClubName;
            clubdetails.Details = club.Details;
            clubdetails.Eligibility = club.Eligibility;

            await _context.SaveChangesAsync();

            return Ok(club);
        }



        //Get all Club Details For Admin
        [HttpGet]
        public async Task<IActionResult> GetAllClubDetails()
        {
            var clubDetails = await _context.Clubs.ToListAsync();
            return Ok(clubDetails);
        }

    }
}
