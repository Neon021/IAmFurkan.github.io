using Blog.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using My3rdBlog.Data.Comments;
using My3rdBlog.Data.FileManager;
using My3rdBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public HomeController(IRepository repository, IFileManager fileManager)
        {
            _repo = repository;
            _fileManager = fileManager;
        }


        public IActionResult Index(int pageNumber, string category, string search)
        {
            if (pageNumber < 1)
                return RedirectToAction("Index", new { pageNumber = 1, category });

            var vm = _repo.GetAllPosts(pageNumber, category, search);

            return View(vm);
        }

        public IActionResult Post(int id) => View(_repo.GetPost(id));



        [HttpGet("/Image/{image}")]
        [ResponseCache(CacheProfileName = "Monthly")]
        public IActionResult Image(string image) =>
             new FileStreamResult(
                 _fileManager.ImageStream(image),
                 $"image/{image.Substring(image.LastIndexOf('.') + 1)}");


        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new { id = vm.PostId });


            #region ifRegion_for_Main&SubComment_Decleration

            var post = _repo.GetPost(vm.PostId);
            if (vm.MainCommentId == 0)
            {
                post.MainComments = post.MainComments ?? new List<MainComment>();

                post.MainComments.Add(new MainComment
                {
                    Message = vm.Message,
                    Created = DateTime.UtcNow
                });
                _repo.UpdatePost(post);
            }

            else
            {
                var comment = new SubComment
                {
                    MainCommentId = vm.MainCommentId,
                    Message = vm.Message,
                    Created = DateTime.UtcNow
                };
                _repo.AddSubComment(comment);
            }
            #endregion

            await _repo.SaveChangesAsync();
            return RedirectToAction("Post", new { id = vm.PostId });
        }
    }
}
