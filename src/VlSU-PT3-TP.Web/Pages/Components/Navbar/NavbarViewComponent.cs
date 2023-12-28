using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using VlSU_PT3_TP.Infrastructure.Identity;
using System.Security.Claims;

namespace VlSU_PT3_TP.Web.Pages.Components.Navbar
{
    public class NavbarViewComponent: ViewComponent
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        public NavbarViewComponent(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user == null)
                {
                    
                }
                return View("LoggedIn");
            }
            else
                return View();
        }
    }
}
