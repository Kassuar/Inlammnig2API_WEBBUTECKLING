using Inlammnig2API_WEBBUTECKLING.Core.Services;
using Inlammnig2API_WEBBUTECKLING.DTO;
using Inlammnig2API_WEBBUTECKLING.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlammnig2API_WEBBUTECKLING.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
           _commentService=commentService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateComment([FromBody] CommentDTO dto)
        {
            

            var result = _commentService.CreateComment(dto);
            
            if (result == null)
                return BadRequest("Failed to create comment");
            return Created($"api/comment/{result.Id}", result);
        }

        [HttpGet ("GetByPostId/{postId}")]

        public IActionResult GetCommentsByPostId(int postId)
        {
            var result = _commentService.GetCommentsByPostId(postId);
            return Ok(result);
        }
         

        
        [Authorize]
        [HttpDelete("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id) {
            var result = _commentService.DeleteComment(id);
            if (!result)
                return NotFound("Comment not found");
            return NoContent();
        }
    } 
}



