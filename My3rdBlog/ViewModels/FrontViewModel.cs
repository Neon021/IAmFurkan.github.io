﻿using My3rdBlog.Data.Comments;
using My3rdBlog.ViewModels;
using System;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class FrontPostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Image { get; set; } = "";

        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Category { get; set; } = "";

        public DateTime Created { get; set; } = DateTime.Now;

        public List<MainComment> MainComments { get; set; }
        public List<CommentViewModel> CommentViewModels { get; set; }
    }
}