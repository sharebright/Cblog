// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostServiceFacts.cs" company="cvlad">
//   Post service facts.
// </copyright>
// <summary>
//   Defines the PostServiceFacts type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Cblog.Tests.Service
{
    using System;
    using System.Linq;
    using Cblog.Model;
    using Cblog.Model.Models;
    using Cblog.Service;

    using Moq;

    using Xunit;

    /// <summary>
    /// The post service facts.
    /// </summary>
    public class PostServiceFacts
    {
        /// <summary>
        /// The get posts_orders_by_date_descending.
        /// </summary>
        [Fact]
        public void GetPosts_orders_by_date_descending()
        {
            // Arrange
            var posts = new FakeDbSet<Post>
            {
                new Post { PostId = 1, UserId = 1, CreatedAt = DateTime.Now, Title = "First post", UrlTitle = "first-post", Content = "Content of the First post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 2, UserId = 1, CreatedAt = DateTime.Now, Title = "Second post", UrlTitle = "second-post", Content = "Content of the Second post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 3, UserId = 1, CreatedAt = DateTime.Now, Title = "Third post", UrlTitle = "third-post", Content = "Content of the Third post", User = new UserProfile { UserName = "cvlad" } },
                new Post { PostId = 4, UserId = 2, CreatedAt = DateTime.Now, Title = "Fourth post", UrlTitle = "fourth-post",  Content = "Content of the Fourth post", User = new UserProfile { UserName = "cvlad" } }
            };

            var context = new Mock<IContext>();
            context.SetupGet(ctx => ctx.Posts).Returns(posts).Verifiable();

            var postService = new PostService(context.Object);

            var expected = posts.OrderByDescending(p => p.CreatedAt);

            // Act
            var result = postService.GetPosts();

            // Assert
            Assert.True(expected.SequenceEqual(result));
            context.Verify();
        }
    }
}
