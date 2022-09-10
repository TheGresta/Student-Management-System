using Core.Entities.Concrete;
using Core.Extensions;
//using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateToken(User user, Role role)
        {
            _accessTokenExpiration = DateTime.Now.AddDays(_tokenOptions.AccessTokenExpiration);
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            JwtSecurityToken jwt = CreateJwtSecurityToken(user, role, signingCredentials, _tokenOptions, _accessTokenExpiration);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            string token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(User user, Role role, SigningCredentials signingCredentials, TokenOptions tokenOptions, DateTime accessTokenExpiration)
        {
            return new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: SetClaims(user, role),
                expires: _accessTokenExpiration);
        }

        private IEnumerable<Claim> SetClaims(User user, Role role)
        {
            List<Claim> claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(new string[] {role.RoleName});
            return claims;
        }
    }
}