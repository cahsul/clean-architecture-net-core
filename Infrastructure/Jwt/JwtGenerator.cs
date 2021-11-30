using Application.X.Interfaces.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Domain.Entities.Identity;
using Application.X.Interfaces.Identity;
using Application.X.Interfaces.Persistence;
using Shared.X.Classes;
using Infrastructure.X.Settings;
using Microsoft.Extensions.Options;

namespace Infrastructure.Jwt
{
    /// <summary>
    /// proses pembuatan JWT
    /// </summary>
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IIdentityDbContext _identityDbContext;
        private readonly InfrastructureSettings _infrastructureSettings;

        public JwtGenerator(IIdentityDbContext identityDbContext, IOptions<InfrastructureSettings> infrastructureSettings)
        {
            _identityDbContext = identityDbContext;
            _infrastructureSettings = infrastructureSettings.Value;
        }

        public async Task<JwtToken> GetToken(IEnumerable<Claim> claims, string userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_infrastructureSettings.Jwt.Secret));

            // TODO : config
            var token = new JwtSecurityToken(
                issuer: "issuer",
                audience: "audience",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
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
                ExpiryDate = DateTimeOffset.UtcNow.AddMonths(6),
                UserId = userId,
            };
            _identityDbContext.RefreshTokens.Add(refreshToken);
            await _identityDbContext.SaveChangesAsync();


            jwtToken.RefreshToken = refreshToken.Token;


            return jwtToken;
        }
    }
}
