using System.Linq;
using System.Threading.Tasks;
using iCoffeeShop.Identity.Models;
using iCoffeeShop.Identity.Models.Request;
using iCoffeeShop.Server.Shared;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace iCoffeeShop.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            var user = new User
                       {
                               Email = model.Email,
                               UserName = model.Email
                       };
            user.Claims.Add(new IdentityUserClaim<string>
                            {
                                    ClaimType = JwtClaimTypes.GivenName,
                                    ClaimValue = model.Name
                            });
            user.Claims.Add(new IdentityUserClaim<string>
                            {
                                    ClaimType = JwtClaimTypes.PhoneNumber,
                                    ClaimValue = model.PhoneNumber
                            });
            var result = await _userManager.CreateAsync(user,
                                                        model.Password);
            if(result.Succeeded)
            {
                return this.OkResult();
            }

            if(result.Errors.Any(c => c.Code == "DuplicateUserName"))
            {
                return this.ErrorResult(ErrorCode.REGISTER_DUPLICATE_EMAIL);
            }

            return this.ErrorResult(ErrorCode.BAD_REQUEST);
        }
    }
}
