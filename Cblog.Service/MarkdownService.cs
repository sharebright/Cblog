// ----------------------------------------------------------------------
// <copyright file="MarkdownService.cs" company="cvlad">
//  MarkdownService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    using MarkdownSharp;

    /// <summary>
    /// The markdown service.
    /// </summary>
    public class MarkdownService : IMarkdownService
    {
        /// <summary>
        /// The Markdown formatter, powered by MarkdownSharp.
        /// </summary>
        private readonly Markdown markdown_;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownService"/> class.
        /// </summary>
        public MarkdownService()
        {
            this.markdown_ = new Markdown();
        }

        /// <summary>
        /// Transforms a markdown string to its html representation.
        /// </summary>
        /// <param name="md">
        /// The markdown string.
        /// </param>
        /// <returns>
        /// The html representation.
        /// </returns>
        public string Transform(string md)
        {
            return this.markdown_.Transform(md);
        }
    }
}
