using Duende.AccessTokenManagement.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web1.Pages;

[Authorize]
public class ApiModel : PageModel
{
    public string Api1Status { get; set; } = default!;
    public string Api3Status { get; set; } = default!;

    public string Api1Result { get; set; } = default!;

    public string AccessToken { get; set; } = default!;

    public async Task OnGet()
    {
        HttpClient apiClient = new();

        var accessToken = await HttpContext.GetUserAccessTokenAsync();
        var tokenType = accessToken.Token!.AccessTokenType.ToString();

        AccessToken = accessToken.Token!.AccessToken;

        apiClient.DefaultRequestHeaders.Authorization = new
            (tokenType!, accessToken.Token!.AccessToken);

        var api1 = await apiClient.GetAsync("https://localhost:5010/api1");
        Api1Status = ((int)api1.StatusCode).ToString();
        Api1Result = await api1.Content.ReadAsStringAsync();

        var api3 = await apiClient.GetAsync("https://localhost:5010/api3");
        Api3Status = ((int)api3.StatusCode).ToString();
    }
}
