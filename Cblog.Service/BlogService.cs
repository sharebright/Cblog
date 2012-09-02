// ----------------------------------------------------------------------
// <copyright file="BlogService.cs" company="cvlad">
//  BlogService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Cblog.Model;
    using Cblog.Model.Models;
    using MarkdownSharp;

    /// <summary>
    /// The blog service.
    /// </summary>
    public class BlogService : IBlogService
    {
        /// <summary>
        /// The Markdown formatter, powered by MarkdownSharp.
        /// </summary>
        private readonly Markdown markdown_;

        /// <summary>
        /// The database context.
        /// </summary>
        private IContext context_;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogService"/> class.
        /// </summary>
        /// <param name="ctx">
        /// The context.
        /// </param>
        public BlogService(IContext ctx)
        {
            this.context_ = ctx;
            this.markdown_ = new Markdown();
        }

        /// <summary>
        /// Gets a single <see cref="FormattedPost" /> by its slug.
        /// </summary>
        /// <param name="slug">
        /// The slug.
        /// </param>
        /// <returns>
        /// The formatted post.
        /// </returns>
        public FormattedPost Single(string slug)
        {
            var post = this.context_.Posts.Include("User").Single(p => p.UrlTitle == slug);
            return this.FormatPost(post);
        }

        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <returns>
        /// An IEnumerable containing all the formatted posts.
        /// </returns>
        public IEnumerable<FormattedPost> All()
        {
            return this.context_.Posts.Include("User").OrderByDescending(p => p.CreatedAt).AsEnumerable().Select(this.FormatPost);
        }

        /// <summary>
        /// Disposes the instance.
        /// </summary>
        public void Dispose()
        {
            this.context_.Dispose();
        }

        /// <summary>
        /// Disposes the instance.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context_ != null)
                {
                    this.context_.Dispose();
                    this.context_ = null;
                }
            }
        }

        /// <summary>
        /// Helper method that formats a single post.
        /// </summary>
        /// <param name="p">
        /// The post.
        /// </param>
        /// <returns>
        /// A formatted post.
        /// </returns>
        private FormattedPost FormatPost(Post p)
        {
            var fp = new FormattedPost
                {
                    Id = p.PostId,
                    Title = p.Title,
                    Slug = p.UrlTitle,
                    Author = p.User.UserName,
                    Date = p.CreatedAt.ToString("f"),
                    Content = this.markdown_.Transform(p.Content)
                };
            return fp;
        }
    }
}
