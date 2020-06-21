using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FastLearning.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the LoginUser class
    public class LoginUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Surname { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Othernames { get; set; }
    }
}
