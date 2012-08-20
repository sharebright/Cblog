// ----------------------------------------------------------------------
// <copyright file="PostService.cs" company="">
//  PostService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Cblog.Model;
    using Cblog.Model.Models;
    using Slugify;

    public class PostService : IPostService
    {
        public PostService(IContext ctx)
        {
            context_ = ctx;
            context_.Configuration.ProxyCreationEnabled = false;
        }

        public IEnumerable<Post> GetPosts()
        {
            return context_.Posts.OrderByDescending(p => p.CreatedAt).AsEnumerable();
        }

        public Post GetPost(int id)
        {
            return context_.Posts.Find(id);
        }

        public void Update(int id, Post post)
        {
            context_.Entry(post).State = EntityState.Modified;
            post.UrlTitle = post.Title.GenerateSlug();
            context_.SaveChanges();
        }

        public void Create(Post post, string username)
        {
            post.CreatedAt = DateTime.Now;
            post.UserId = context_.Users.Single(u => u.UserName == username).UserId;
            post.UrlTitle = post.Title.GenerateSlug();

            context_.Posts.Add(post);
            context_.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = context_.Posts.Find(id);
            context_.Posts.Remove(post);
            context_.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context_ != null)
                {
                    context_.Dispose();
                    context_ = null;
                }
            }
        }

        private IContext context_;
    }
}
