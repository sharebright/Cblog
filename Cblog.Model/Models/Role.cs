// ----------------------------------------------------------------------
// <copyright file="Role.cs" company="cvlad">
//  Role
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Role model class.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the user profiles.
        /// </summary>
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
