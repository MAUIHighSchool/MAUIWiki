using MAUIWiki.Shared;
using Microsoft.EntityFrameworkCore;

namespace MAUIWiki.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<CommentContent> Comments { get; set; }
    }
}
