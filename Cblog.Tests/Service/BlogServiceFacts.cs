// ----------------------------------------------------------------------
// <copyright file="BlogServiceFacts.cs" company="">
//  BlogServiceFacts
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Tests.Service
{
    using System;
    using System.Linq;
    using Cblog.Model;
    using Cblog.Model.Models;
    using Cblog.Service;
    using FluentAssertions;
    using MarkdownSharp;
    using Moq;
    using Xunit;

    public class BlogServiceFacts
    {
        [Fact]
        public void single_should_return_a_single_post()
        {
            // Arrange
            var fakeBlogs = new FakeDbSet<Post>
            {
                new Post { PostId = 1, UserId = 1, CreatedAt = DateTime.Now, Title = "First post", Content = "Content of the First post", User = new UserProfile() { UserName = "cvlad" } },
                new Post { PostId = 2, UserId = 1, CreatedAt = DateTime.Now, Title = "Second post", Content = "Content of the Second post", User = new UserProfile() { UserName = "cvlad" } },
                new Post { PostId = 3, UserId = 1, CreatedAt = DateTime.Now, Title = "Third post", Content = "Content of the Third post", User = new UserProfile() { UserName = "cvlad" } },
                new Post { PostId = 4, UserId = 2, CreatedAt = DateTime.Now, Title = "Fourth post", Content = "Content of the Fourth post", User = new UserProfile() { UserName = "cvlad" } }
            };
            var expected = fakeBlogs.ElementAt(1);

            var context = new Mock<IContext>();
            context.Setup(ctx => ctx.Posts).Returns(fakeBlogs).Verifiable();

            var service = new BlogService(context.Object);

            // Act
            var blog = service.Single(expected.PostId);

            // Assert
            blog.Id.Should().Be(expected.PostId);
            blog.Title.Should().Be(expected.Title);
            blog.Date.Should().NotBeEmpty();
            blog.Content.Should().Be("<p>" + expected.Content + "</p>\n");
            blog.Author.Should().Be(expected.User.UserName);
        }

        [Fact]
        public void all_should_return_all_posts()
        {
            // Arrange
            var fakeBlogs = new FakeDbSet<Post>
            {
                new Post { PostId = 1, UserId = 1, CreatedAt = DateTime.Now, Title = "First post", Content = "Content of the First post", User = new UserProfile() { UserName = "cvlad" } },
                new Post { PostId = 2, UserId = 1, CreatedAt = DateTime.Now, Title = "Second post", Content = "Content of the Second post", User = new UserProfile() { UserName = "cvlad" } },
                new Post { PostId = 3, UserId = 1, CreatedAt = DateTime.Now, Title = "Third post", Content = "Content of the Third post", User = new UserProfile() { UserName = "cvlad" } },
                new Post { PostId = 4, UserId = 2, CreatedAt = DateTime.Now, Title = "Fourth post", Content = "Content of the Fourth post", User = new UserProfile() { UserName = "cvlad" } }
            };

            var context = new Mock<IContext>();
            context.Setup(ctx => ctx.Posts).Returns(fakeBlogs).Verifiable();

            var service = new BlogService(context.Object);

            // Act
            var blogs = service.All();

            // Assert
            blogs.Count().Should().Be(fakeBlogs.Count());
        }

        [Fact]
        public void service_should_interpret_markdown()
        {
            // Arrange
            var markdownString = "## Header here\r\nAnd some list after\r\n*one\r\n*two\r\nDone.";

            var fakeBlogs = new FakeDbSet<Post>
            {
                new Post { PostId = 1, UserId = 1, CreatedAt = DateTime.Now, Title = "First post", Content = markdownString, User = new UserProfile() { UserName = "cvlad" } },
            };

            var markdown = new Markdown();
            var expected = fakeBlogs.ElementAt(0);
            var expectedContent = markdown.Transform(expected.Content);

            var context = new Mock<IContext>();
            context.Setup(ctx => ctx.Posts).Returns(fakeBlogs).Verifiable();

            var service = new BlogService(context.Object);

            // Act
            var actual = service.Single(expected.PostId);

            // Assert
            actual.Content.Should().Be(expectedContent);
        }

        [Fact]
        public void all_should_be_ordered_by_date_descending()
        {
            // Arrange
            var fakeBlogs = new FakeDbSet<Post>
            {
                new Post { PostId = 1, UserId = 1, CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(5)), Title = "First post", Content = "Content of the First post", User = new UserProfile() { UserName = "cvlad" } },
                new Post { PostId = 2, UserId = 1, CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(1)), Title = "Second post", Content = "Content of the Second post", User = new UserProfile() { UserName = "cvlad" } },
                new Post { PostId = 3, UserId = 1, CreatedAt = DateTime.Now, Title = "Third post", Content = "Content of the Third post", User = new UserProfile() { UserName = "cvlad" } },
                new Post { PostId = 4, UserId = 2, CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(2)), Title = "Fourth post", Content = "Content of the Fourth post", User = new UserProfile() { UserName = "cvlad" } }
            };

            var context = new Mock<IContext>();
            context.Setup(ctx => ctx.Posts).Returns(fakeBlogs).Verifiable();

            var service = new BlogService(context.Object);

            // Act
            var actual = service.All();

            // Assert
            // TODO: fix.
            // for some reason, actual.Should().ContainInOrder seems to not work.
            actual.ElementAt(0).Id.Should().Be(3);
            actual.ElementAt(1).Id.Should().Be(2);
            actual.ElementAt(2).Id.Should().Be(4);
            actual.ElementAt(3).Id.Should().Be(1);
        }
    }
}
