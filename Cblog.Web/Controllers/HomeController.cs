// ----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="">
//  HomeController
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Controllers
{
    using System.Web.Mvc;
    using Cblog.Model;
using Cblog.Service;

    public class HomeController : Controller
    {
        public HomeController()
            : this(null)
        { }

        public HomeController(IBlogService bs)
        {
            blogService_ = bs ?? DependencyResolver.Current.GetService<IBlogService>();
        }


        public ActionResult Index()
        {
            var blogs = blogService_.All();
            return View(blogs);
        }

        public ActionResult Blog(int id)
        {
            var post = blogService_.Single(id);
            return View(post);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        private IBlogService blogService_;
    }
}
