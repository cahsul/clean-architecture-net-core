using Application._.Interfaces.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Shared._.Jwt;
using System.Security.Cryptography;
using Domain.Entities.Identity;
using Application._.Interfaces.Identity;
using Application._.Interfaces.Persistence;

namespace Infrastructure.Jwt
{
    /// <summary>
    /// proses pembuatan JWT
    /// </summary>
    public class JwtGenerator : IJwtGenerator
    {
        //private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly IIdentityDbContext _identityDbContext;

        public JwtGenerator(IIdentityDbContext identityDbContext)
        {
            //_tokenValidationParameters = tokenValidationParameters;
            _identityDbContext = identityDbContext;
        }

        public async Task<JwtToken> GetToken(IEnumerable<Claim> claims, string userId)
        {
            // TODO : config
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a bb ccc dddd eeeee ffffff ggggggg hhhhhhhh iiiiiiiii"));

            // TODO : config
            var token = new JwtSecurityToken(
                issuer: "issuer",
                audience: "audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            var jwtToken = new JwtToken
            {
                Token = tokenAsString,
                ValidTo = token.ValidTo
            };

            // generate refresh token
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);

            var refreshToken = new RefreshToken
            {
                JwtToken = tokenAsString,
                Token = Convert.ToBase64String(randomBytes),
                ExpiryDate = DateTimeOffset.Now.AddMonths(6),
                UserId = userId,
            };
            _identityDbContext.RefreshTokens.Add(refreshToken);
            await _identityDbContext.SaveChangesAsync();


            jwtToken.RefreshToken = refreshToken.Token;


            return jwtToken;
        }
    }
}
