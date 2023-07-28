using GetTalim.Domain.Entities.Students;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Interfaces.Students;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GetTalim.Service.Services.Students;

public class TokenStudentService : ITokenStudentService
{
    private readonly IConfiguration _config;
    public TokenStudentService(IConfiguration configuration)
    {
        _config = configuration.GetSection("Jwt");
    }

    public string GenerateToken(Student student)
    {
        var identityClaims = new Claim[]
        {
            new Claim("Id", student.Id.ToString()),
            new Claim("FirstName", student.FirstName),
            new Claim("LastName", student.LastName),
            new Claim(ClaimTypes.Role, student.IdentityRole),
            new Claim(ClaimTypes.Email, student.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]!));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        int expiresHours = int.Parse(_config["Lifetime"]!);
        var token = new JwtSecurityToken(
            issuer: _config["Issuer"],
            audience: _config["Audience"],
            claims: identityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    

}
