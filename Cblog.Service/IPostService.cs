// ----------------------------------------------------------------------
// <copyright file="IPostService.cs" company="cvlad">
//  IPostService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    using System;
    using System.Collections.Generic;
    using Cblog.Model.Models;

    /// <summary>
    /// The PostService interface.
    /// </summary>
    public interface IPostService : IDisposable
    {
        /// <summary>
        /// Gets all the posts.
        /// </summary>
        /// <returns>
        /// An IEnumerable of all posts.
        /// </returns>
        IEnumerable<Post> GetPosts();

        /// <summary>
        /// Gets a single post.
        /// </summary>
        /// <param name="id">
        /// The id of the requested post.
        /// </param>
        /// <returns>
        /// The requested post.
        /// </returns>
        Post GetPost(int id);

        /// <summary>
        /// Updates a post.
        /// </summary>
        /// <param name="id">
        /// The id of the post
        /// </param>
        /// <param name="post">
        /// The post to update.
        /// </param>
        void Update(int id, Post post);

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="post">
        /// The post to create.
        /// </param>
        /// <param name="username">
        /// The username of the post creator.
        /// </param>
        void Create(Post post, string username);

        /// <summary>
        /// Deletes an existing post.
        /// </summary>
        /// <param name="id">
        /// The id of the post to be deleted.
        /// </param>
        void Delete(int id);
    }
}
