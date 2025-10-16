using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web2.Pages;

public class LogoutModel : PageModel
{
    public IActionResult OnPost()
    {
        AuthenticationProperties props = new()
        {
            RedirectUri = "/"
        };

        return SignOut(props, "cookies", "oidc");
    }
}
