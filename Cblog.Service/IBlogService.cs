// ----------------------------------------------------------------------
// <copyright file="IBlogService.cs" company="">
//  IBlogService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    using System;
    using System.Collections.Generic;

    public interface IBlogService : IDisposable
    {
        IEnumerable<FormattedPost> All();
        FormattedPost Single(string slug);
    }
}
