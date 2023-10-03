using GetTalim.Service.Interfaces.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;

[Route("api/identity")]
[ApiController]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identity;

    public IdentityController(IIdentityService identity)
    {
        _identity = identity;
    }
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
         return  Ok( new
        {
            _identity.FirstName,
            _identity.LastName,
            _identity.Email,
            _identity.UserId,
            _identity.IdentityRole
        }
        );
    }
}
