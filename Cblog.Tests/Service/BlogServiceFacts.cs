// ----------------------------------------------------------------------
// <copyright file="BlogServiceFacts.cs" company="cvlad">
//  BlogServiceFacts
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Tests.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cblog.Model;
    using Cblog.Model.Models;
    using Cblog.Service;
    using FluentAssertions;
    using MarkdownSharp;
    using Moq;
    using Xunit;

    /// <summary>
    /// The blog service facts.
    /// </summary>
    public class BlogServiceFacts
    {
        /// <summary>
        /// The BlogService.Single should return a single post.
        /// </summary>
        [Fact]
        public void Single_should_return_a_single_post()
        {
            // Arrange
            var fakeBlogs = new FakeDbSet<Post>
            {
                new Post { PostId = 1, UserId = 1, CreatedAt = DateTime.Now, Title = "First post", UrlTitle = "first-post", Content = "Content of the First post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 2, UserId = 1, CreatedAt = DateTime.Now, Title = "Second post", UrlTitle = "second-post", Content = "Content of the Second post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 3, UserId = 1, CreatedAt = DateTime.Now, Title = "Third post", UrlTitle = "third-post", Content = "Content of the Third post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 4, UserId = 2, CreatedAt = DateTime.Now, Title = "Fourth post", UrlTitle = "fourth-post",  Content = "Content of the Fourth post", User = new UserProfile { UserName = "cvlad" } }
            };
            var expected = fakeBlogs.ElementAt(1);

            var context = new Mock<IContext>();
            context.Setup(ctx => ctx.Posts).Returns(fakeBlogs).Verifiable();

            var service = new BlogService(context.Object);

            // Act
            var blog = service.Single(expected.UrlTitle);

            // Assert
            blog.Id.Should().Be(expected.PostId);
            blog.Title.Should().Be(expected.Title);
            blog.Date.Should().NotBeEmpty();
            blog.Content.Should().Be("<p>" + expected.Content + "</p>\n");
            blog.Author.Should().Be(expected.User.UserName);

            context.Verify();
        }

        /// <summary>
        /// The All_should_return_all_posts.
        /// </summary>
        [Fact]
        public void All_should_return_all_posts()
        {
            // Arrange
            var fakeBlogs = new FakeDbSet<Post>
            {
                new Post { PostId = 1, UserId = 1, CreatedAt = DateTime.Now, Title = "First post", UrlTitle = "first-post", Content = "Content of the First post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 2, UserId = 1, CreatedAt = DateTime.Now, Title = "Second post", UrlTitle = "second-post", Content = "Content of the Second post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 3, UserId = 1, CreatedAt = DateTime.Now, Title = "Third post", UrlTitle = "third-post", Content = "Content of the Third post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 4, UserId = 2, CreatedAt = DateTime.Now, Title = "Fourth post", UrlTitle = "fourth-post",  Content = "Content of the Fourth post", User = new UserProfile { UserName = "cvlad" } }
            };

            var context = new Mock<IContext>();
            context.Setup(ctx => ctx.Posts).Returns(fakeBlogs).Verifiable();

            var service = new BlogService(context.Object);

            // Act
            var blogs = service.All();

            // Assert
            blogs.Count().Should().Be(fakeBlogs.Count());
            context.Verify();
        }

        /// <summary>
        /// The service_should_interpret_markdown.
        /// </summary>
        [Fact]
        public void Service_should_interpret_markdown()
        {
            // Arrange
            const string MarkdownString = "## Header here\r\nAnd some list after\r\n*one\r\n*two\r\nDone.";

            var fakeBlogs = new FakeDbSet<Post>
            {
                new Post { PostId = 1, UserId = 1, CreatedAt = DateTime.Now, Title = "First post", UrlTitle = "first-post", Content = MarkdownString, User = new UserProfile { UserName = "cvlad" } },
            };

            var markdown = new Markdown();
            var expected = fakeBlogs.ElementAt(0);
            var expectedContent = markdown.Transform(expected.Content);

            var context = new Mock<IContext>();
            context.Setup(ctx => ctx.Posts).Returns(fakeBlogs).Verifiable();

            var service = new BlogService(context.Object);

            // Act
            var actual = service.Single(expected.UrlTitle);

            // Assert
            actual.Content.Should().Be(expectedContent);
            context.Verify();
        }

        /// <summary>
        /// The All_should_be_ordered_by_date_descending.
        /// </summary>
        [Fact]
        public void All_should_be_ordered_by_date_descending()
        {
            // Arrange
            var fakeBlogs = new FakeDbSet<Post>
            {
                new Post { PostId = 1, UserId = 1, CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(5)), Title = "First post", UrlTitle = "first-post", Content = "Content of the First post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 2, UserId = 1, CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(1)), Title = "Second post", UrlTitle = "second-post", Content = "Content of the Second post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 3, UserId = 1, CreatedAt = DateTime.Now, Title = "Third post", UrlTitle = "third-post", Content = "Content of the Third post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 4, UserId = 2, CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(2)), Title = "Fourth post", UrlTitle = "fourth-post", Content = "Content of the Fourth post", User = new UserProfile { UserName = "cvlad" } }
            };

            var context = new Mock<IContext>();
            context.Setup(ctx => ctx.Posts).Returns(fakeBlogs).Verifiable();

            var service = new BlogService(context.Object);

            // Act
            var actual = service.All();

            // Assert
            // TODO: fix.
            // for some reason, actual.Should().ContainInOrder seems to not work.
            var formattedPosts = actual as List<FormattedPost> ?? actual.ToList();
            formattedPosts.ElementAt(0).Id.Should().Be(3);
            formattedPosts.ElementAt(1).Id.Should().Be(2);
            formattedPosts.ElementAt(2).Id.Should().Be(4);
            formattedPosts.ElementAt(3).Id.Should().Be(1);
            context.Verify();
        }
    }
}
