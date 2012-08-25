// ----------------------------------------------------------------------
// <copyright file="OAuthMembership.cs" company="cvlad">
//  OAuthMembership
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models
{
    /// <summary>
    /// The o auth membership.
    /// </summary>
    public class OAuthMembership
    {
        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the provider user id.
        /// </summary>
        public string ProviderUserId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }
    }
}
