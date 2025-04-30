using Microsoft.IdentityModel.Tokens;
using RaidPlanner.Api.Dto;
using RaidPlanner.DAL.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RaidPlanner.Api.Services
{
    public class JwtManager
    {
        public static string GenerateToken(JwtOptions jwtoption, UserDto u)
        {
            //Générer le token et le renvoyer
            //1- string key vers byte key
            byte[] skey = Encoding.UTF8.GetBytes(jwtoption.SigningKey);
            SymmetricSecurityKey laCle = new SymmetricSecurityKey(skey);


            //2- Quleque claims
            Claim Sid = new Claim(ClaimTypes.Sid, u.Id.ToString());
            Claim infoNom = new Claim(ClaimTypes.Name, u.Username);
            Claim Rols = new Claim(ClaimTypes.Role, u.Username == "Dylan" ? "Boulet" : "Admin");

            List<Claim> mesClaims = new List<Claim>
            {   Sid,
                infoNom,
                Rols
            };

            //3 config et génération
            JwtSecurityToken Token = new JwtSecurityToken(
        issuer: jwtoption.Issuer,
                 audience: jwtoption.Audience,
                 claims: mesClaims,
                 expires: DateTime.Now.AddSeconds(jwtoption.Expiration),
                 signingCredentials: new SigningCredentials(laCle, SecurityAlgorithms.HmacSha256)

             );


            string leTokenArenvoyer = new JwtSecurityTokenHandler().WriteToken(Token);
            u.Access_Token = leTokenArenvoyer;
            u.Refresh_Token = GenerateRefreshToken();
            return leTokenArenvoyer;
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
