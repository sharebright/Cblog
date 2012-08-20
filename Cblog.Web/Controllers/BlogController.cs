// ----------------------------------------------------------------------
// <copyright file="BlogController.cs" company="">
//  BlogController
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Cblog.Model.Models;
    using Cblog.Service;

    public class BlogController : ApiController
    {
        private IBlogService service_;

        public BlogController()
            : this(null)
        { }

        // TODO: fix the DI stuff here.
        public BlogController(IBlogService bs)
        {
            service_ = bs ?? new BlogService(new CblogContext());
        }

        public IEnumerable<FormattedPost> GetBlogs()
        {
            return service_.All();
        }

        //public FormattedPost GetBlog(int id)
        //{
        //    return service_.Single(id);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (service_ != null)
                {
                    service_.Dispose();
                    service_ = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
