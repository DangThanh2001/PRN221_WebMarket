using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private const double EXPIRY_DURATION_MINUTES = 30;
        private byte[] key; 
        public string BuildToken(Account user)
        {
            key =  new byte[16]; // tạo khóa có độ dài 128 bit (16 byte)
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(key); // tạo giá trị ngẫu nhiên cho khóa
            }

            var issuer = _configuration["Jwt:Issuer"];
            var claims = new[] {
                new Claim("uid",user.AccountId.ToString()),
                new Claim(ClaimTypes.Name, user.LastName),
                new Claim(ClaimTypes.Role, user.Type == 0 ? "Admin" : user.Type == 1? "Mod" : "Normal"),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        public bool IsTokenValid(string token)
        {
            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public int DeserializeToken(string jwt)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var mySecret = key;
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal claims = handler.ValidateToken(jwt, 
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, 
                out SecurityToken validatedToken);

            var claimsList = claims.Claims.Skip(2).First();
            var a = claimsList.Value;
            return a.ToString().ToLower().Equals("admin") ? 0 : a.ToString().ToLower().Equals("mod") ? 1 : 2;
        }
        public string GetUserId(string jwt)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var mySecret = key;
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal claims = handler.ValidateToken(jwt,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                },
                out SecurityToken validatedToken);

            var claimsList = claims.Claims.First();
            var a = claimsList.Value;
            return a;
        }
    }
}