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
    using Cblog.Web.Filters;

    public class PostController : ApiController
    {
        private IContext db_;

        public PostController() : this(null)
        { }

        public PostController(IContext ctx)
        {
            db_ = ctx ?? new CblogContext();
            db_.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Post
        public IEnumerable<Post> GetPosts()
        {
            return db_.Posts.OrderByDescending(p => p.CreatedAt).AsEnumerable();
        }

        // GET api/Post/5
        public Post GetPost(int id)
        {
            Post post = db_.Posts.Find(id);
            if (post == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return post;
        }

        // PUT api/Post/5
        [Authorize(Roles = "admin")]
        public HttpResponseMessage PutPost(int id, Post post)
        {
            if (ModelState.IsValid && id == post.PostId)
            {
                db_.Entry(post).State = EntityState.Modified;

                try
                {
                    db_.SaveChanges();
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
                post.CreatedAt = DateTime.Now;
                post.UserId = db_.Users.Single(u => u.UserName == this.User.Identity.Name).UserId;

                db_.Posts.Add(post);
                db_.SaveChanges();

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
            Post post = db_.Posts.Find(id);
            if (post == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db_.Posts.Remove(post);

            try
            {
                db_.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, post);
        }

        protected override void Dispose(bool disposing)
        {
            db_.Dispose();
            base.Dispose(disposing);
        }
    }
}