namespace Api.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    public class TokenHelper
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly System.Text.Encoding _encoding = System.Text.Encoding.UTF8;

        public TokenHelper(IConfiguration config)
        {
            this._key = config.GetValue<string>("Jwt:Key") ?? "TokenPorDefecto";
            this._issuer = config.GetValue<string>("Jwt:Issuer") ?? "https://localhost:44303/";
        }

        public string GenerarToken(List<Claim> claims, int duration = 10)
        {
            var secKey = new SymmetricSecurityKey(this._encoding.GetBytes(this._key));
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                this._issuer,
                this._issuer,
                expires: DateTime.Now.AddMinutes(duration),
                signingCredentials: credentials,
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtBearerOptions GetTokenOptions(JwtBearerOptions options)
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = this._issuer,
                ValidAudience = this._issuer,
                IssuerSigningKey = new SymmetricSecurityKey(this._encoding.GetBytes(this._key)),
            };
            return options;
        }
    }
}
