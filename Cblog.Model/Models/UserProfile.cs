// ----------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="">
//  UserProfile
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models
{
    using System.Collections.Generic;

    public class UserProfile
    {
        public UserProfile()
        {
            this.Roles = new List<Role>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
