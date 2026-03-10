using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;
using Inlammnig2API_WEBBUTECKLING.DTO;
using Inlammnig2API_WEBBUTECKLING.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Inlammnig2API_WEBBUTECKLING.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }


        [Authorize]
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostDTO dto)
        {
            
            var result = _postService.CreatePost(dto);

            if (result == null)
                return BadRequest("Failed to create post");

            return Created( $"api/post/{result.Id}",result);
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var result = _postService.GetAllPosts();
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetPost(int id)
        {
            var result = _postService.GetPostById(id);

            if (result == null)
                return NotFound("Post not found");

            return Ok(result);
        }
        [Authorize]
        [HttpPut("UpdatePost/{id}")]
        public IActionResult UpdatePost(int id, [FromBody] PostDTO dto)
        {
            var result = _postService.UpdatePost(id, dto);

            if (result == null)
                return NotFound("Post not found");

            return Ok(result);
        }
        [Authorize]
        [HttpDelete("DeletePost/{id}")]
        public IActionResult DeletePost(int id)
        {
            var result = _postService.DeletePost(id);

            if (!result)
                return NotFound("Post not found");

            return Ok("Post deleted");
        }

        [HttpGet("search")]
        public IActionResult SearchPosts(string keyword)
        {
            var result = _postService.SearchPosts(keyword);

            return Ok(result);
        }
    }
}
