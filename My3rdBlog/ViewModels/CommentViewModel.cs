using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace My3rdBlog.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public int MainCommentId { get; set; }
        [Required]
        [AllowHtml]
        public string Message { get; set; }
    }
}
