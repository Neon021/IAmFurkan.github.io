using System.Collections.Generic;

namespace My3rdBlog.Data.Comments
{
    public class MainComment : Comment
    {
        public List<SubComment> subComments { get; set; }
    }
}
