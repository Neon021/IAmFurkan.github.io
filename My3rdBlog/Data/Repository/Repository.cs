﻿using Blog.Helpers;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.EntityFrameworkCore;
using My3rdBlog.Data.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }



        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return _ctx.Posts.ToList();
        }

        public IndexViewModel GetAllPosts(int pageNumber, string category, string search)
        {
            //Func<Post, bool> InCategory = (post) => { return post.Category.ToLower().Equals(category.ToLower()); };

            int pageSize = 5;
            int skipAmount = pageSize * (pageNumber - 1);

            var query = _ctx.Posts.AsNoTracking().AsQueryable();

            if (!String.IsNullOrEmpty(category))
                query = query.Where(x => x.Category.Equals(category));

            if (!String.IsNullOrEmpty(search))
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{search}%")
                                    || EF.Functions.Like(x.Body, $"%{search}%")
                                    || EF.Functions.Like(x.Description, $"%{search}%"));


            int postsCount = query.ToList().Count();
            int pageCount = (int)Math.Ceiling((double)postsCount / pageSize);

            return new IndexViewModel
            {
                PageNumber = pageNumber,
                PageCount = pageCount,
                NextPage = postsCount > skipAmount + pageSize,
                Pages = PageHelper.PageNumbers(pageNumber, pageCount).ToList(),
                Category = category,
                Search = search,
                Posts = query
                    .Skip(skipAmount)
                    .Take(pageSize)
                    .ToList()
            };

        }
        public Post GetPost(int? id)
        {
            return _ctx.Posts
                .Include(p => p.MainComments)
                    .ThenInclude(mc => mc.subComments)
                .FirstOrDefault(p => p.Id == id);

        }

        //public Post GetPost(int id)
        //{
        //    if (_ctx.Posts == null)
        //    { return (Post)Results.NoContent(); }

        //    var result = _ctx.Posts.FirstOrDefault(p => p.Id == id);
        //    if (result == null)
        //    {
        //        return (Post)Results.NotFound(result);
        //    }
        //    return result;

        //}


        public void DeletePost(int? id)
        {
            if (_ctx.Posts != null)
            {
                _ctx.Posts.Remove(GetPost(id));
            }
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void AddSubComment(SubComment comment)
        {
            _ctx.SubComments.Add(comment);
        }

        public FrontPostViewModel GetFrontPost(int id)
        {
            return _ctx.Posts
                   .Include(p => p.MainComments)
                       .ThenInclude(mc => mc.subComments)
                   .Select(x => new FrontPostViewModel
                   {
                       Id = x.Id,
                       Title = x.Title,
                       Description = x.Description,
                       Body = x.Body,

                   })
                   .FirstOrDefault(p => p.Id == id);
        }
    }
}
