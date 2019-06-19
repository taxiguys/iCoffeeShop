using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace iCoffeeShop.Identity.Models
{
    public class User : IdentityUser
    {
        public ICollection<IdentityUserClaim<string>> Claims { get; set; } = new List<IdentityUserClaim<string>>();
    }
}
