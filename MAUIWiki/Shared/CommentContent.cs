using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIWiki.Shared
{
    public class CommentContent
    {
        public int Id { get; set; }
        public int Number { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? UserName { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Comment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
