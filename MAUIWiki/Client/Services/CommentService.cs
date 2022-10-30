using MAUIWiki.Shared;
using System.Net.Http.Json;

namespace MAUIWiki.Client.Services
{
    public interface ICommentService
    {
        Task<List<CommentContent>> GetCommentList(int number);
        Task<int> PostComment(CommentContent commentContent);
    }
    public class CommentService:ICommentService
    {
        private readonly HttpClient _http;
        public CommentService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<CommentContent>> GetCommentList(int number)
        {
            return await _http.GetFromJsonAsync<List<CommentContent>>($"Comment/{number}");
        }
        public async Task<int> PostComment(CommentContent commentContent)
        {
            var result = await _http.PostAsJsonAsync("Comment", commentContent);
            string id = await result.Content.ReadAsStringAsync();
            return int.Parse(id);
        }
    }
}
