using MD.JWTApp.Back.Core.Application.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MD.JWTApp.Back.Infrastructure.Tool
{
    public class JWTGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var claims = new List<Claim>();

            if(!string.IsNullOrEmpty(dto.Role))
            claims.Add(new Claim(ClaimTypes.Role, dto.Role));


            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));

            if (!string.IsNullOrEmpty(dto.UserName))
                claims.Add(new Claim(ClaimTypes.Name, dto.UserName));


            var signinKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(JwtSettingsDefault.SigningKey));

            //Etibarnamedir bir nov. Girisin etibaligini yoxlayir
            SigningCredentials Credentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddMinutes(JwtSettingsDefault.ExpireTime);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer:JwtSettingsDefault.ValidIssuer,
                audience:JwtSettingsDefault.ValidAudience,
                claims:claims,
                notBefore:DateTime.UtcNow, //Ne zamandan isleyecek
                expires: expireDate,
                signingCredentials: Credentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return new TokenResponseDto(handler.WriteToken(jwtSecurityToken), expireDate);
        }
    }
}
