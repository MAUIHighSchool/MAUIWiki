using Markdig;
using MAUIWiki.Shared;
using Microsoft.AspNetCore.Components;

namespace MAUIWiki.Client.Pages
{
    public class MarkdownEditorBase : ComponentBase
    {
        public MarkdownPipeline pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UseAutoLinks()
            .UsePipeTables()
            .UseListExtras()
            .UseMediaLinks()
            .UseMathematics()
            .Build();
        public string ArtBody { get; set; } = string.Empty;
        public string Preview => Markdown.ToHtml(ArtBody,pipeline);
    }
}
