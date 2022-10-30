using MAUIWiki.Server.Services;
using MAUIWiki.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MAUIWiki.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("{number}")]
        public async Task<ActionResult<List<CommentContent>>> GetCommentsList(int number)
        {
            return Ok(await _commentService.GetCommentList(number));
        }
        [HttpPost]
        public async Task<ActionResult> PostComment(CommentContent commentContent)
        {
            return Ok(await _commentService.PostComment(commentContent));
        }
    }
}
