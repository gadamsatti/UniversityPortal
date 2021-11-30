using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySharedDatabase.Models;

namespace GrievanceAndIdeasWebApp.Controllers
{
    [Route("api/[controller][action]")]
  //  [Authorize]
    [ApiController]
    public class UserIdeaController : ControllerBase
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
       
        //User Can LikeorDislike and Can comment on ideas post by the other user.
        [HttpPost]
        public async Task<IActionResult> AddUserIdea([FromBody] UserIdea idea)
        {
            _context.UserIdeas.Add(idea);
            await _context.SaveChangesAsync();
            return Ok(idea);
        }


        //updateing the useridea
        [HttpPut]
        [Route("{ideaId}")]
        public async Task<IActionResult> UpdateUserIdea(int ideaId,UserIdea upComment)
        {
            var userUpdateComment = await _context.UserIdeas.FindAsync(ideaId);
            userUpdateComment.LikeStatus = upComment.LikeStatus;
            userUpdateComment.Comments = upComment.Comments;
              await _context.SaveChangesAsync();
                return Ok(upComment);
            
        }


    }
}
