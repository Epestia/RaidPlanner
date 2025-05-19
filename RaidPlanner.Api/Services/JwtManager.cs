using Microsoft.IdentityModel.Tokens;
using RaidPlanner.Api.Dto;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.DAL.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RaidPlanner.Api.Services
{
    public class JwtManager
    {
        public static string GenerateToken(JwtOptions jwtoption, UserModel user)
        {
            byte[] skey = Encoding.UTF8.GetBytes(jwtoption.SigningKey);
            SymmetricSecurityKey laCle = new SymmetricSecurityKey(skey);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Sid, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Email, user.Mail),
        new Claim(ClaimTypes.Role, user.RoleId.ToString())
    };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: jwtoption.Issuer,
                audience: jwtoption.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(jwtoption.Expiration),
                signingCredentials: new SigningCredentials(laCle, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public static string GenerateAccessTokenFromRefreshToken(string refreshToken, JwtOptions options, List<Claim>? mesClaims)
        {

            //Générer le token et le renvoyer
            //1- string key vers byte key
            byte[] skey = Encoding.UTF8.GetBytes(options.SigningKey);
            SymmetricSecurityKey laCle = new SymmetricSecurityKey(skey);


            JwtSecurityToken Token = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                claims: mesClaims,
                expires: DateTime.Now.AddMinutes(options.Expiration),
                signingCredentials: new SigningCredentials(laCle, SecurityAlgorithms.HmacSha256)

            );


            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

    }
}
