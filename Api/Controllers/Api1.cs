using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize("api1")]
public class Api1 : ControllerBase
{
    public string OnGet()
        => "Hello Api1!";
}
