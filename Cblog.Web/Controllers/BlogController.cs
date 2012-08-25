// ----------------------------------------------------------------------
// <copyright file="BlogController.cs" company="cvlad">
//  BlogController
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Cblog.Model.Models;
    using Cblog.Service;

    /// <summary>
    /// The blog controller.
    /// </summary>
    public class BlogController : ApiController
    {
        /// <summary>
        /// The service_.
        /// </summary>
        private IBlogService service_;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogController"/> class.
        /// </summary>
        public BlogController()
            : this(null)
        {
        }

        // TODO: fix the DI stuff here.

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogController"/> class.
        /// </summary>
        /// <param name="bs">
        /// The bs.
        /// </param>
        public BlogController(IBlogService bs)
        {
            this.service_ = bs ?? new BlogService(new CblogContext());
        }

        /// <summary>
        /// The get blogs.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; Cblog.Service.FormattedPost].
        /// </returns>
        public IEnumerable<FormattedPost> GetBlogs()
        {
            return this.service_.All();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.service_ != null)
                {
                    this.service_.Dispose();
                    this.service_ = null;
                }
            }
        }
    }
}
