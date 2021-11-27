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
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        //User Can Share idea to other user using userId and ideaId
        [HttpPost]
        public async Task<IActionResult> CreateSharedDetails(Share userIdeaShare)
        {
            _context.Shares.Add(userIdeaShare);
           await _context.SaveChangesAsync();

            return Ok(userIdeaShare);
        }
    }
}
