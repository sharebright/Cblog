// ----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="cvlad">
//  HomeController
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Controllers
{
    using System.Web.Mvc;
    using Cblog.Service;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The blog service.
        /// </summary>
        private readonly IBlogService blogService_;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="bs">
        /// The blog service implementation.
        /// </param>
        public HomeController(IBlogService bs)
        {
            this.blogService_ = bs ?? DependencyResolver.Current.GetService<IBlogService>();
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Index()
        {
            var blogs = this.blogService_.All();
            return this.View(blogs);
        }

        /// <summary>
        /// The blog.
        /// </summary>
        /// <param name="slug">
        /// The slug.
        /// </param>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Blog(string slug)
        {
            var post = this.blogService_.Single(slug);
            return this.View(post);
        }

        /// <summary>
        /// The about.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return this.View();
        }
    }
}
