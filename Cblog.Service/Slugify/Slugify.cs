// ----------------------------------------------------------------------
// <copyright file="Slugify.cs" company="cvlad">
//  Slugify
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Service.Slugify
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// The slugify.
    /// </summary>
    public static class Slugify
    {
        /// <summary>
        /// String extension method to generate a SLUG.
        /// </summary>
        /// <param name="phrase">
        /// The phrase.
        /// </param>
        /// <returns>
        /// The slug.
        /// </returns>
        public static string GenerateSlug(this string phrase)
        {
            var str = phrase.RemoveAccent().ToLower();

            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", string.Empty);

            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();

            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        /// <summary>
        /// String extension method to replace accents with simple characters.
        /// </summary>
        /// <param name="txt">
        /// The text to transform.
        /// </param>
        /// <returns>
        /// The transformed string.
        /// </returns>
        public static string RemoveAccent(this string txt)
        {
            var bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
