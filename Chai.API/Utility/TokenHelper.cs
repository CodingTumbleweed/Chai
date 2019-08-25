using Chai.API.App_Start;
using Chai.Models.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Chai.API.Utility
{
    internal class TokenHelper
    {
        public TokenDTO CreateToken(AccountDTO auth)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var issuedAt = DateTime.UtcNow;
            int LifeTime = Convert.ToInt32(Helper.GetAppSettings("TokenLifeTimeInDays"));
            var expires = DateTime.UtcNow.AddDays(LifeTime);
            var claimsIdentity = new ClaimsIdentity(new GenericIdentity(auth.Email), new[]
            {
                new Claim("UserId", auth.Id.ToString(), ClaimValueTypes.Integer),
            });

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(JwtConfig.Secret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //create the token
            var token = tokenHandler.CreateJwtSecurityToken(
                JwtConfig.Issuer,
                JwtConfig.Audience,
                claimsIdentity,
                issuedAt,
                expires,
                signingCredentials: signingCredentials);

            return new TokenDTO
            {
                Token = tokenHandler.WriteToken(token),
                Expires = expires,
            };
        }

    }
}