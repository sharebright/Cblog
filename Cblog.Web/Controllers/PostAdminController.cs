// ----------------------------------------------------------------------
// <copyright file="PostAdminController.cs" company="cvlad">
//  PostAdminController
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The post admin controller.
    /// </summary>
    [Authorize(Roles = "admin")]
    public class PostAdminController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult List()
        {
            return this.View();
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Edit()
        {
            return this.View();
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Create()
        {
            return this.View();
        }
    }
}
