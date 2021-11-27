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
    [ApiController]
    public class UserEventController : ControllerBase
    {

        private ApplicationDbContext _context = new ApplicationDbContext();


        //User Can Rigister For EVent By Default Attendence,likeor dislike or comments are null
        [HttpPost]

        public async Task<IActionResult> CreateUserEvent([FromBody] UserEvent userEvent)
        {
            /*var createUserEvent = new UserEvent() { UserId = userId, EventId = eventId };*/

            _context.UserEvents.Add(userEvent);
            await _context.SaveChangesAsync();

            return Ok(userEvent);
        }


        //Update User attendence,like/dislike, comments after register event
        [HttpPut] //DOUT
        public async Task<IActionResult> UpdateUserEvent(int userEventId, [FromBody]UserEvent userEvent)
        {
            var userEventDetails = await _context.UserEvents.FindAsync(userEventId);

            userEventDetails.Suggestion = userEvent.Suggestion;
            userEventDetails.Attendence = true;
            userEventDetails.LikesOrDislike = true; ///DOUT



            await _context.SaveChangesAsync();

            return Ok(userEvent.EventId);

        }

        // Get All UsersBy EventId
        [HttpGet]
        [Route("{eventId}")]
        public async Task<IActionResult> GetAllUsersByEventId(int eventId)
        {
            var usersDetails = await _context.UserEvents.Where(e => e.EventId == eventId).ToListAsync();

            return Ok(usersDetails);
        }

       

    }
}
