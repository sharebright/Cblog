// ----------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="cvlad">
//  UserProfile
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The user profile.
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }
    }
}
