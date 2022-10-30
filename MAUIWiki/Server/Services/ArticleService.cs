using MAUIWiki.Server.Data;
using MAUIWiki.Shared;
using Microsoft.EntityFrameworkCore;

namespace MAUIWiki.Server.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesList();
        Task<Article> GetArticle(int number);
        Task<int> PostArticle(Article article);
        Task<int> PutArticle(int number,Article article);
    }
    public class ArticleService:IArticleService
    {
        private readonly DataContext _context;
        public ArticleService(IDbContextFactory<DataContext> dbContext)
        {
            _context=dbContext.CreateDbContext();
        }
        public async Task<List<Article>> GetArticlesList()
        {
            using (_context)
            {
                return await _context.Articles.ToListAsync();
            }
        }
        public async Task<Article> GetArticle(int number)
        {
            using(_context)
            {
                return await _context.Articles.FirstOrDefaultAsync(x=> x.Id == number);
            }
        }
        public async Task<int> PostArticle(Article article)
        {
            using (_context)
            {
                DateTime now = DateTime.Now;
                article.CreateDate = now;
                article.UpdateDate = now;
                await _context.Articles.AddAsync(article);
                await _context.SaveChangesAsync();
                return article.Id;
            }
        }
        public async Task<int> PutArticle(int number,Article article)
        {
            using(_context)
            {
                var _entity=_context.Articles.FirstOrDefault(x=>x.Id == number);
                _entity.Title= article.Title;
                _entity.Content = article.Content;
                _entity.UpdateDate=DateTime.Now;
                return await _context.SaveChangesAsync();
            }
        }
    }
}
