using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using CarProject.Business.Abstract;
using CarProject.Data.Concrete.EntityFramework.DatabaseContext;
using CarProject.Entities.Concrete;
using CarProject.Shared.Utilities.Security.Encryption;
using CarProject.Shared.Utilities.Security.Jwt;
using CmnSoftwareBackend.Shared.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CarProject.Business.Concrete
{
    public class JwtHelper : ManagerBase, IJwtHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        private DateTime _refreshTokenExpiration;

        public JwtHelper(IConfiguration configuration, Context dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            //RefreshToken
            _refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration + 100);
            var jwtRefresh = CreateJwtRefreshToken(_tokenOptions, user, signingCredentials);
            var refreshToken = jwtSecurityTokenHandler.WriteToken(jwtRefresh);
            return new AccessToken
            {
                Token = token,
                TokenExpiration = _accessTokenExpiration,
                RefreshToken = refreshToken,
                RefreshTokenExpiration = _refreshTokenExpiration,
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        public JwtSecurityToken CreateJwtRefreshToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _refreshTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.EmailAddress);
            claims.AddName($"{user.FirstName} {user.LastName}");
            //claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }

        public AccessToken CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}

