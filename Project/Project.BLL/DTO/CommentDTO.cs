using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.DTO
{
    public class CommentDTO
    {
        public int commentid { get; set; }
        public int userid { get; set; }
        public string username { get; set; }
        public string comment { get; set; }
        public DateTime date { get; set; }
    }
}
