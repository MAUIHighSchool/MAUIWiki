using MAUIWiki.Shared;
using System.Net.Http.Json;

namespace MAUIWiki.Client.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesList();
        Task<Article> GetArticle(int number);
        Task<int> PostArticle(Article article);
        Task<HttpResponseMessage> PutArticle(int number, Article article); 
    }
    public class ArticleService:IArticleService
    {
        private readonly HttpClient _http;
        public ArticleService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<Article>> GetArticlesList()
        {
            return await _http.GetFromJsonAsync<List<Article>>("Article");
        }
        public async Task<Article> GetArticle(int number)
        {
            return await _http.GetFromJsonAsync<Article>($"Article/{number}");
        }
        public async Task<int> PostArticle(Article article)
        {
            var result = await _http.PostAsJsonAsync("Article", article);
            string id =await result.Content.ReadAsStringAsync();
            return int.Parse(id);
        }
        public async Task<HttpResponseMessage>PutArticle(int number,Article article)
        {
            return await _http.PutAsJsonAsync($"Article/{number}", article);
        }
    }
}
