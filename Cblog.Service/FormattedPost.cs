// ----------------------------------------------------------------------
// <copyright file="FormattedPost.cs" company="">
//  FormattedPost
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service
{
    public class FormattedPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }

        public string Author { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }
    }
}
