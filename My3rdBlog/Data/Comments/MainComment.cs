using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3rdBlog.Data.Comments
{
    public class MainComment: Comment
    {
        public List<SubComment> subComments { get; set; }
    }
}
