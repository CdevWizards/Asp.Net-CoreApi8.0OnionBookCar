using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentID { get; set; } 
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int BlogID { get; set; }
    }
}