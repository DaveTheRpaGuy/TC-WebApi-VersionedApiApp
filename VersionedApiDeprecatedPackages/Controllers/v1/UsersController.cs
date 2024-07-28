using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersionedApiDeprecatedPackages.Controllers.v1;

[Route("api/v{version:ApiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0", Deprecated = true)]
public class UsersController : ControllerBase
{
    // GET: api/v1/Users
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "Version 1 value1", "Version 1 value2" };
    }

}
