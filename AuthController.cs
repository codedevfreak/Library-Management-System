[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        var token = _userService.Authenticate(model.Username, model.Password);

        if (token == null)
            return Unauthorized();

        return Ok(new { Token = token });
    }
}
