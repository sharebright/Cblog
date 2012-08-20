// ----------------------------------------------------------------------
// <copyright file="Post.cs" company="">
//  Post
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models
{
    using System;

    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
