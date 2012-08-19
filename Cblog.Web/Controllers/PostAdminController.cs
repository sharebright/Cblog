// ----------------------------------------------------------------------
// <copyright file="PostAdminController.cs" company="">
//  PostAdminController
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Controllers
{
    using System.Web.Mvc;
    using Cblog.Web.Filters;

    [Authorize(Roles = "admin")]
    public class PostAdminController : Controller
    {
        //
        // GET: /PostAdmin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
