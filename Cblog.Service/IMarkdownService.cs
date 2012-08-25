// ----------------------------------------------------------------------
// <copyright file="IMarkdownService.cs" company="cvlad">
//  IMarkdownService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    /// <summary>
    /// The MarkdownService interface.
    /// </summary>
    public interface IMarkdownService
    {
        /// <summary>
        /// Transforms a markdown string to its html representation.
        /// </summary>
        /// <param name="md">
        /// The markdown string.
        /// </param>
        /// <returns>
        /// The html representation.
        /// </returns>
        string Transform(string md);
    }
}
