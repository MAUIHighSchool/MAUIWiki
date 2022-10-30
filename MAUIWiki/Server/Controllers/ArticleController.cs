using MAUIWiki.Server.Services;
using MAUIWiki.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAUIWiki.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetArticlesList()
        {
            return Ok(await _articleService.GetArticlesList());
        }
        [HttpGet("{number}")]
        public async Task<ActionResult<Article>> GetArticle(int number)
        {
            return Ok(await _articleService.GetArticle(number));
        }
        [HttpPost]
        public async Task<ActionResult<int>> PostArticle(Article article)
        {
            return Ok(await _articleService.PostArticle(article));
        }
        [HttpPut("{number}")]
        public async Task<ActionResult> PutArticle(int number,Article article)
        {
            return Ok(await _articleService.PutArticle(number, article));
        }
    }
}
