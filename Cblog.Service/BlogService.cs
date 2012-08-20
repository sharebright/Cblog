// ----------------------------------------------------------------------
// <copyright file="BlogService.cs" company="">
//  BlogService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cblog.Model;
    using Cblog.Model.Models;
    using MarkdownSharp;

    public class BlogService : IBlogService
    {
        public BlogService(IContext ctx)
        {
            context_ = ctx;
            markdown_ = new Markdown();
        }

        public FormattedPost Single(string slug)
        {
            var post = context_.Posts.Single(p => p.UrlTitle == slug);
            return FormatPost(post);

        }

        public IEnumerable<FormattedPost> All()
        {
            return context_.Posts.OrderByDescending(p => p.CreatedAt).AsEnumerable().Select(p => FormatPost(p));
        }

        private FormattedPost FormatPost(Post p)
        {
            var fp = new FormattedPost()
            {
                Id = p.PostId,
                Title = p.Title,
                Slug = p.UrlTitle,
                Author = p.User.UserName,
                Date = p.CreatedAt.ToShortDateString(),
                Content = markdown_.Transform(p.Content)
            };
            return fp;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context_ != null)
                {
                    context_.Dispose();
                    context_ = null;
                }
            }
        }

        public void Dispose()
        {
            context_.Dispose();
        }

        private IContext context_;
        private Markdown markdown_;
    }
}
