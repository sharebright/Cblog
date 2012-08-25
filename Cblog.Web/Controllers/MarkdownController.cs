// ----------------------------------------------------------------------
// <copyright file="MarkdownController.cs" company="cvlad">
//  MarkdownController
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Controllers
{
    using System.Web.Http;
    using Cblog.Service;

    /// <summary>
    /// The markdown controller.
    /// </summary>
    public class MarkdownController : ApiController
    {
        /// <summary>
        /// The markdown service_.
        /// </summary>
        private readonly IMarkdownService markdownService_;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownController"/> class.
        /// </summary>
        public MarkdownController()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownController"/> class.
        /// </summary>
        /// <param name="markdown">
        /// The markdown.
        /// </param>
        public MarkdownController(IMarkdownService markdown)
        {
            this.markdownService_ = markdown ?? new MarkdownService();
        }

        /// <summary>
        /// The get markdown.
        /// </summary>
        /// <param name="md">
        /// The md.
        /// </param>
        /// <returns>
        /// The System.String.
        /// </returns>
        public string GetMarkdown(string md)
        {
            return this.markdownService_.Transform(md);
        }
    }
}
