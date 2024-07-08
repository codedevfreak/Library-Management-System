public interface IUserService
{
    string Authenticate(string username, string password);
}

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly string _secret;

    public UserService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _secret = configuration["JwtConfig:Secret"];
    }

    public string Authenticate(string username, string password)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

        if (user == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

