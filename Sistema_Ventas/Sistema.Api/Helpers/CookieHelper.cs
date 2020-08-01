namespace Sistema.Api.Helpers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Http;

    public class CookieHelper
    {
        public CookieHelper(HttpResponse response, HttpRequest request, ClaimsPrincipal user)
        {
            this.Response = response;
            this.Request = request;
            this.User = user;
        }

        private ClaimsPrincipal User { get; }

        private HttpResponse Response { get; set; }

        private HttpRequest Request { get; set; }

        /// <summary>
        /// Set the cookie.
        /// </summary>
        /// <param name="key">key (unique indentifier).</param>
        /// <param name="value">value to store in cookie object.</param>
        /// <param name="expireTime">expiration time in minutes.</param>
        public void Set(string key, string value, int? expireTime = 10)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
            {
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            }
            else
            {
                option.Expires = DateTime.Now.AddMilliseconds(10);
            }

            this.Response.Cookies.Append(key, value, option);
        }


        /// <summary>
        /// Delete the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public void Remove(string key)
        {
            this.Response.Cookies.Delete(key);
        }

        /// <summary>
        /// Get the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public string? Get(string key)
        {
            return this.Request.Cookies[key];
        }

        /// <summary>
        /// Get the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public string? GetRequestIP()
        {
            var header = this.Request.Host;
            return header.Value.ToString();
        }

        /// <summary>
        /// Get the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public string? GetFromResponse(string key)
        {
            return this.Response.Cookies.ToString();
        }

        /// <summary>
        /// Get User id from header-token.
        /// </summary>
        public int? GetUserId()
        {
            if (this.User == null)
            {
                return null;
            }

            return int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

        /// <summary>
        /// Get the Header of the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public string? GetHeader(string key)
        {
            return this.Request.Headers.FirstOrDefault(x => x.Key == key).Value.FirstOrDefault();
        }

    }
}
