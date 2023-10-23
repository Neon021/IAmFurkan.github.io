using Blog.Models;
using Blog.ViewModels;
using My3rdBlog.Data.Comments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public interface IRepository
    {
        void AddPost(Post post);
        List<Post> GetAllPosts();
        IndexViewModel GetAllPosts(int pageNumber, string category, string search);
        Post GetPost(int? id);
        void DeletePost(int? id);
        void UpdatePost(Post post);
        void AddSubComment(SubComment comment);
        Task<bool> SaveChangesAsync();
    }
}
