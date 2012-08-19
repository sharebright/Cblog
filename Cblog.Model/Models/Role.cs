// ----------------------------------------------------------------------
// <copyright file="Role.cs" company="">
//  Role
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models
{
    using System.Collections.Generic;

    public class Role
    {
        public Role()
        {
            this.UserProfiles = new List<UserProfile>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
