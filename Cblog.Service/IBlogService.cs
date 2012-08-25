// ----------------------------------------------------------------------
// <copyright file="IBlogService.cs" company="cvlad">
//  IBlogService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The BlogService interface.
    /// </summary>
    public interface IBlogService : IDisposable
    {
        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <returns>
        /// An IEnumerable containing all the formatted posts.
        /// </returns>
        IEnumerable<FormattedPost> All();

        /// <summary>
        /// Gets a single <see cref="FormattedPost" /> by its slug.
        /// </summary>
        /// <param name="slug">
        /// The slug.
        /// </param>
        /// <returns>
        /// The formatted post.
        /// </returns>
        FormattedPost Single(string slug);
    }
}
