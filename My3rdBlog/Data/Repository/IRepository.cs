using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TechTalk.SpecFlow.CommonModels;
using My3rdBlog.Data.Comments;
using Blog.ViewModels;

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
