namespace Sistema.Api.Helpers
{
    using System;
    using Microsoft.Extensions.Configuration;

    public class PasswordHelper
    {
        private readonly string _key;
        private readonly System.Text.Encoding _encoding = System.Text.Encoding.UTF8;

        public PasswordHelper(IConfiguration config)
        {
            this._key = config.GetValue<string>("Salting:Key") ?? "ValorPorDefecto";
        }

        public void CrearPasswordHash(string password, out byte[] passwordHash)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA256(this._encoding.GetBytes(this._key));
            passwordHash = hmac.ComputeHash(this._encoding.GetBytes(password));
        }

        public bool VerificarPasswordHash(string password, byte[] passwordHashAlmacenado)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(this._encoding.GetBytes(this._key));
            var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
        }
    }
}
