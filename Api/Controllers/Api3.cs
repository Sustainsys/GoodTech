using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize("api3")]
public class Api3 : ControllerBase
{
    public string OnGet()
        => "Hello Api3!";
}
