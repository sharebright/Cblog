// ----------------------------------------------------------------------
// <copyright file="IMarkdownService.cs" company="">
//  IMarkdownService
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    public interface IMarkdownService
    {
        string Transform(string md);
    }
}
