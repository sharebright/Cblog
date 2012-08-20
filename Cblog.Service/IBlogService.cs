// ----------------------------------------------------------------------
// <copyright file="IBlogService.cs" company="">
//  IBlogService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    using System.Collections.Generic;

    public interface IBlogService
    {
        IEnumerable<FormattedPost> All();
        FormattedPost Single(int id);
    }
}
