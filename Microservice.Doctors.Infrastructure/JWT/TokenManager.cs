using Microservice.Doctors.Application.AppSettings;
using Microservice.Doctors.Application.Interfaces.JWT;
using Microservice.Doctors.Domain.Doctor;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Microservice.Doctors.Infrastructure.JWT
{
    public class TokenManager : IToken
    {
        public string CreateToken(Doctor doctor)
        {
            JwtSecurityTokenHandler handler = new();

            ClaimsIdentity claims = GetClaims(doctor);
            int expire = AppSettings_Helper.Auth.Expire;

            byte[] secretKey = Encoding.ASCII.GetBytes(AppSettings_Helper.Auth.SecretKey);

            SecurityTokenDescriptor token = new()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(365),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
                Issuer = AppSettings_Helper.Auth.Issuer,
                Audience = AppSettings_Helper.Auth.Audience
            };

            var output = handler.CreateToken(token);
            return handler.WriteToken(output);
        }

        public bool? ValidateToken(string token)
        {
            throw new NotImplementedException();
        }


        private ClaimsIdentity GetClaims(Doctor doctor)
        {
            ClaimsIdentity output = new(new[]
            {
                new Claim("credential", doctor.Credential.ToString()),
                new Claim("specialty", doctor.Specialty),
                new Claim("name", doctor.Name),
                new Claim("lastname", doctor.LastName)
            });

            return output;
        }
    }
}
