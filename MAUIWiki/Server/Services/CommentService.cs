using MAUIWiki.Server.Data;
using MAUIWiki.Shared;
using Microsoft.EntityFrameworkCore;

namespace MAUIWiki.Server.Services
{
    public interface ICommentService
    {
        Task<List<CommentContent>> GetCommentList(int number);
        Task<int> PostComment(CommentContent commentContent);
    }
    public class CommentService:ICommentService
    {
        private readonly DataContext _context;
        public CommentService(IDbContextFactory<DataContext> dbContext)
        {
            _context=dbContext.CreateDbContext();
        }
        public async Task<List<CommentContent>> GetCommentList(int number)
        {
            using (_context)
            {
                return await _context.Comments.Where(x=>x.Number==number).ToListAsync();
            }
        }
        public async Task<int> PostComment(CommentContent commentContent)
        {
            using (_context)
            {
                commentContent.CreateDate = DateTime.Now;
                await _context.Comments.AddAsync(commentContent);
                await _context.SaveChangesAsync();
                return commentContent.Id;
            }
        }

    }
}
