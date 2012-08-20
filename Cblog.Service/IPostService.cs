// ----------------------------------------------------------------------
// <copyright file="IPostService.cs" company="">
//  IPostService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    using System;
    using System.Collections.Generic;
    using Cblog.Model.Models;

    public interface IPostService : IDisposable
    {
        IEnumerable<Post> GetPosts();
        Post GetPost(int id);
        void Update(int id, Post post);
        void Create(Post post, string username);
        void Delete(int id);
    }
}
