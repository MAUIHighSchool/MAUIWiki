using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIWiki.Shared
{
    public class Article
    {
        
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? NameId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Title { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Image { get; set; }
    }
}
