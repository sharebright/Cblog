// ----------------------------------------------------------------------
// <copyright file="MarkdownService.cs" company="">
//  MarkdownService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    using MarkdownSharp;

    public class MarkdownService : IMarkdownService
    {
        public MarkdownService()
        {
            markdown_ = new Markdown();
        }

        public string Transform(string md)
        {
            return markdown_.Transform(md);
        }

        private Markdown markdown_;
    }
}
