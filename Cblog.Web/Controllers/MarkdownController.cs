// ----------------------------------------------------------------------
// <copyright file="MarkdownController.cs" company="">
//  MarkdownController
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Controllers
{
    using System.Web.Http;
    using Cblog.Service;

    public class MarkdownController : ApiController
    {
        public MarkdownController() : this(null)
        { }

        public MarkdownController(IMarkdownService markdown)
        {
            markdownService_ = markdown ?? new MarkdownService();
        }

        public string GetMarkdown(string md)
        {
            return markdownService_.Transform(md);
        }

        private IMarkdownService markdownService_;
    }
}
