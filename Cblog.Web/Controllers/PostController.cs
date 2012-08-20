// ----------------------------------------------------------------------
// <copyright file="PostController.cs" company="">
//  PostController
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Cblog.Model;
    using Cblog.Model.Models;
    using Cblog.Service;
    using Cblog.Web.Filters;

    public class PostController : ApiController
    {
        private IPostService postService_;

        public PostController() : this(null)
        { }

        public PostController(IPostService ps)
        {
            postService_ = ps ?? new PostService(new CblogContext());
        }

        // GET api/Post
        public IEnumerable<Post> GetPosts()
        {
            return postService_.GetPosts();
        }

        // GET api/Post/5
        public Post GetPost(int id)
        {
            return postService_.GetPost(id);
        }

        // PUT api/Post/5
        [Authorize(Roles = "admin")]
        public HttpResponseMessage PutPost(int id, Post post)
        {
            if (ModelState.IsValid && id == post.PostId)
            {
                try
                {
                    postService_.Update(id, post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Post
        [Authorize(Roles = "admin")]
        public HttpResponseMessage PostPost(Post post)
        {
            if (ModelState.IsValid)
            {
                postService_.Create(post, this.User.Identity.Name);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, post);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = post.PostId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Post/5
        [Authorize(Roles = "admin")]
        public HttpResponseMessage DeletePost(int id)
        {
            try
            {
                postService_.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            postService_.Dispose();
            base.Dispose(disposing);
        }
    }
}