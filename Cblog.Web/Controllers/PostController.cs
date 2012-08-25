// ----------------------------------------------------------------------
// <copyright file="PostController.cs" company="cvlad">
//  PostController
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Cblog.Model.Models;
    using Cblog.Service;

    /// <summary>
    /// The post controller.
    /// </summary>
    public class PostController : CblogApiController
    {
        /// <summary>
        /// The post service_.
        /// </summary>
        private readonly IPostService postService_;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostController"/> class.
        /// </summary>
        public PostController()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostController"/> class.
        /// </summary>
        /// <param name="ps">
        /// The ps.
        /// </param>
        public PostController(IPostService ps)
        {
            this.postService_ = ps ?? this.Resolve<IPostService>();
        }

        /// <summary>
        /// The get posts.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; Cblog.Model.Models.Post].
        /// </returns>
        public IEnumerable<Post> GetPosts()
        {
            return this.postService_.GetPosts();
        }

        /// <summary>
        /// The get post.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The Cblog.Model.Models.Post.
        /// </returns>
        public Post GetPost(int id)
        {
            return this.postService_.GetPost(id);
        }

        /// <summary>
        /// The put post.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="post">
        /// The post.
        /// </param>
        /// <returns>
        /// The System.Net.Http.HttpResponseMessage.
        /// </returns>
        [Authorize(Roles = "admin")]
        public HttpResponseMessage PutPost(int id, Post post)
        {
            if (ModelState.IsValid && id == post.PostId)
            {
                try
                {
                    this.postService_.Update(id, post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return this.Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// The post post.
        /// </summary>
        /// <param name="post">
        /// The post.
        /// </param>
        /// <returns>
        /// The System.Net.Http.HttpResponseMessage.
        /// </returns>
        [Authorize(Roles = "admin")]
        public HttpResponseMessage PostPost(Post post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            this.postService_.Create(post, this.User.Identity.Name);

            var response = this.Request.CreateResponse(HttpStatusCode.Created, post);
            response.Headers.Location = new Uri(this.Url.Link("DefaultApi", new { id = post.PostId }));
            return response;
        }

        /// <summary>
        /// The delete post.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The System.Net.Http.HttpResponseMessage.
        /// </returns>
        [Authorize(Roles = "admin")]
        public HttpResponseMessage DeletePost(int id)
        {
            try
            {
                this.postService_.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            this.postService_.Dispose();
            base.Dispose(disposing);
        }
    }
}