using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Web2.Pages;

[Authorize]
public class SecureModel : PageModel
{
    public SessionData Session { get; set; } = default!;

    public async Task OnGet()
    {
        // retrieve current session
        var authenticateResult = await HttpContext.AuthenticateAsync();

        var userClaims = authenticateResult.Principal!.Claims;
        var metadata = authenticateResult.Properties!.Items;

        Session = new SessionData(userClaims, metadata!);
    }

    public record SessionData(
        IEnumerable<Claim> Claims,
        IDictionary<string, string> Metadata);
}