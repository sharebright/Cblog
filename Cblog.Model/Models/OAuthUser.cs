using System;
using System.Collections.Generic;

namespace Cblog.Model.Models
{
    public class OAuthUser
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }
    }
}
