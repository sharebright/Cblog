using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cblog.Service;

namespace Cblog.Web.Controllers
{
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
