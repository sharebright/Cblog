// ----------------------------------------------------------------------
// <copyright file="PostService.cs" company="cvlad">
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

    /// <summary>
    /// The post service.
    /// </summary>
    public class PostService : IPostService
    {
        /// <summary>
        /// The context_.
        /// </summary>
        private IContext context_;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostService"/> class.
        /// </summary>
        /// <param name="ctx">
        /// The ctx.
        /// </param>
        public PostService(IContext ctx)
        {
            this.context_ = ctx;
            this.context_.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Gets all the posts.
        /// </summary>
        /// <returns>
        /// An IEnumerable of all posts.
        /// </returns>
        public IEnumerable<Post> GetPosts()
        {
            return this.context_.Posts.OrderByDescending(p => p.CreatedAt).AsEnumerable();
        }

        /// <summary>
        /// Gets a single post.
        /// </summary>
        /// <param name="id">
        /// The id of the requested post.
        /// </param>
        /// <returns>
        /// The requested post.
        /// </returns>
        public Post GetPost(int id)
        {
            return this.context_.Posts.Find(id);
        }

        /// <summary>
        /// Updates a post.
        /// </summary>
        /// <param name="id">
        /// The id of the post
        /// </param>
        /// <param name="post">
        /// The post to update.
        /// </param>
        public void Update(int id, Post post)
        {
            this.context_.Entry(post).State = EntityState.Modified;
            post.UrlTitle = post.Title.GenerateSlug();
            this.context_.SaveChanges();
        }

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="post">
        /// The post to create.
        /// </param>
        /// <param name="username">
        /// The username of the post creator.
        /// </param>
        public void Create(Post post, string username)
        {
            post.CreatedAt = DateTime.Now;
            post.UserId = this.context_.Users.Single(u => u.UserName == username).UserId;
            post.UrlTitle = post.Title.GenerateSlug();

            this.context_.Posts.Add(post);
            this.context_.SaveChanges();
        }

        /// <summary>
        /// Deletes an existing post.
        /// </summary>
        /// <param name="id">
        /// The id of the post to be deleted.
        /// </param>
        public void Delete(int id)
        {
            var post = this.context_.Posts.Find(id);
            this.context_.Posts.Remove(post);
            this.context_.SaveChanges();
        }

        /// <summary>
        /// Disposes the instance.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Disposes the instance.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context_ != null)
                {
                    this.context_.Dispose();
                    this.context_ = null;
                }
            }
        }
    }
}
