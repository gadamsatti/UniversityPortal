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
    [Route("api/[controller][action]")]
    [Authorize]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        //adding idea by enduser
        [HttpPost]
        public async Task<IActionResult> AddIdea([FromBody]Idea idea)
        {

             _context.Ideas.Add(idea);
            await _context.SaveChangesAsync();

            return Ok(idea);
        }


        //Get All Ideas of User using clubId
        [HttpGet]
        [Route("{clubId}")]
        public async Task<IActionResult> GetAllIdeaByClubId([FromRoute]int clubId)
        {
            var clubIdeasDetails = await _context.Ideas.Where(e=>e.ClubId==clubId).ToListAsync();

            return Ok(clubIdeasDetails);
        }
    }
}
